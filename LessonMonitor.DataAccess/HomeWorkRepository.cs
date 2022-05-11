using LessonMonitor.Core;
using LessonMonitor.Core.Repositoryes;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess
{
    public class HomeWorkRepository : IHomeWorkRepository
	{
		private readonly string _connectionString;
		public HomeWorkRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task<int> Add(HomeWork newHomeWork)
		{
			if (newHomeWork is null)
				throw new ArgumentNullException(nameof(newHomeWork));

			var newHomeworkEntity = new Entityes.HomeWork
            {
				Title = newHomeWork.Title,
				Link = newHomeWork.Link,
				Description = newHomeWork.Description
            };

			using SqlConnection connection = new(_connectionString);
			await connection.OpenAsync();

			SqlCommand command = new(@"
				INSERT INTO Homeworks (Title, Description, Link, CreatedDate, UpdatedDate)
				VALUES(@Title, @Description, @Link, @CreatedDate, @UpdatedDate)
				SET @HomeworkId = scope_identity()",
			connection);

			command.Parameters.AddWithValue("@Title", newHomeworkEntity.Title);
			command.Parameters.AddWithValue("@Description", newHomeworkEntity.Description);
			command.Parameters.AddWithValue("@Link", newHomeworkEntity.Link);
			command.Parameters.AddWithValue("@CreatedDate", newHomeworkEntity.CreateDate);
			command.Parameters.AddWithValue("@UpdatedDate", newHomeworkEntity.UpdatedDate);

			var resultIdParameter = new SqlParameter
			{
				Direction = System.Data.ParameterDirection.Output,
				ParameterName = "@HomeworkId",
				SqlDbType = System.Data.SqlDbType.Int
			};

			command.Parameters.Add(resultIdParameter);

			await command.ExecuteNonQueryAsync();

			if (command.Parameters["@HomeworkId"].Value is int idParameter)
            {
				return idParameter;
            }
			else
            {
				throw new FormatException($"Value id cannot be converted:" +
                    $" {command.Parameters["@HomeworkId"].Value}");
            }			
		}

		public async Task Delete(int homeworkId)
		{
			if (homeworkId < 0)
				throw new ArgumentException($"The index must not be less than zero: {homeworkId}");			

			using SqlConnection connection = new(_connectionString);
			await connection.OpenAsync();
			SqlCommand command = new(@"
				UPDATE Homeworks
				SET DeletedDate = @DeletedDate
				WHERE Id = @Id",
			connection);

			command.Parameters.AddWithValue("@Id", homeworkId);
			command.Parameters.AddWithValue("@DeletedDate", DateTime.Now);

            await command.ExecuteNonQueryAsync();
		}		

		public async Task Update(HomeWork homeWork)
		{
			if (homeWork is null)
				throw new ArgumentNullException(nameof(homeWork));

			var updateHomeworkEntity = new Entityes.HomeWork
			{
				Id = homeWork.Id,
				Title = homeWork.Title,
				Link = homeWork.Link,
				Description = homeWork.Description
			};

			using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
			SqlCommand command = new(@"
				UPDATE Homeworks
				SET 
					Title = @Title, 
					Description = @Description, 
					Link = @Link,
					UpdatedDate = @UpdateDate
				WHERE Id = @Id AND DeletedDate IS NULL",
			connection);

			command.Parameters.AddWithValue("@Id", updateHomeworkEntity.Id);
			command.Parameters.AddWithValue("@Title", updateHomeworkEntity.Title);
			command.Parameters.AddWithValue("@Description", updateHomeworkEntity.Description);
			command.Parameters.AddWithValue("@Link", updateHomeworkEntity.Link);
			command.Parameters.AddWithValue("@UpdateDate", updateHomeworkEntity.UpdatedDate);

            await command.ExecuteNonQueryAsync();
		}

		public async Task<HomeWork> Get(int homeworkId)
		{
			using SqlConnection connection = new(_connectionString);
			await connection.OpenAsync();

			var command = new SqlCommand(@"
				SELECT * FROM Homeworks
				WHERE Id = @Id AND DeletedDate IS NULL",
			connection);

			command.Parameters.AddWithValue("@Id", homeworkId);

            using SqlDataReader reader = await command.ExecuteReaderAsync();
            
			while (await reader.ReadAsync())
            {
				var result = new HomeWork
                {
					Title = reader.GetString(1),
					Description = reader.GetString(2),
					Link = new Uri(reader.GetString(3))
                };
				return result;
			}
			return null;
		}

		public async Task<HomeWork[]> Get()
		{
			using SqlConnection connection = new(_connectionString);

			await connection.OpenAsync();

			List<HomeWork> result = new();

			var command = new SqlCommand(@"
				SELECT * FROM Homeworks",
			connection);

			using SqlDataReader reader = await command.ExecuteReaderAsync();

			while (await reader.ReadAsync())
			{
				result.Add(new HomeWork
				{
                    Id = (int)reader["Id"],
                    Title = (string)reader["Title"],
					Description = (string)reader["Description"],
					Link = new Uri((string)reader["Link"])
				});
			}
			return result.ToArray();
		}

		public void CleanTable()
        {
			using var connection = new SqlConnection(_connectionString);
			connection.Open();

			var command = new SqlCommand(@"
				DELETE FROM Homeworks",
			connection);

			command.ExecuteNonQuery();
        }
	}
}

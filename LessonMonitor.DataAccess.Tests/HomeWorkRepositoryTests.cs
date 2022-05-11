using AutoFixture;
using LessonMonitor.Core;
using System;
using System.Collections.Generic;
using Xunit;

namespace LessonMonitor.DataAccess.Tests
{
    public class HomeWorkRepositoryTests : IDisposable
    {
        private readonly HomeWorkRepository _repository;
        public HomeWorkRepositoryTests()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=LessonMonitorTestDb;Integrated Security=true;";
            _repository = new HomeWorkRepository(connectionString);
        }

        [Fact]
        public async void Add_ValidHomework_ShouldCreateNewHomework()
        {
            // ARRANGE
            var fixture = new Fixture();
            var homework = fixture.Create<HomeWork>();

            // ACT            
            int homeworkId = await _repository.Add(homework);

            // ASSERT
            Assert.True(homeworkId > 0);
        }

        [Fact]
        public async void Update()
        {
            // ARRANGE
            var fixture = new Fixture();
            var homework = fixture.Create<HomeWork>();
            
            int homeworkId = await _repository.Add(homework);

            var homeworkUpdater = fixture.Create<HomeWork>();
            homeworkUpdater.Id = homeworkId;
            // ACT            
            await _repository.Update(homeworkUpdater);

            // ASSERT
            var homeworkGet = await _repository.Get(homeworkId);
            Assert.NotNull(homeworkGet);
            Assert.Equal(homeworkUpdater.Title, homeworkGet.Title);
            Assert.Equal(homeworkUpdater.Description, homeworkGet.Description);
            Assert.Equal(homeworkUpdater.Link, homeworkGet.Link);
        }

        [Fact]
        public async void Get()
        {
            // ARRANGE
            var fixture = new Fixture();
            var homework = fixture.Create<HomeWork>();
            int homeworkId = await _repository.Add(homework);
            
            // ACT            
            var homeworkGet = _repository.Get(homeworkId);
            
            // ASSERT
            Assert.NotNull(homeworkGet);
        }

        [Fact]
        public async void GetAll()
        {
            // ARRANGE
            var fixture = new Fixture();

            for (int i = 0; i < 10; i++)
            {
                var homework = fixture.Create<HomeWork>();

                await _repository.Add(homework);
            }

            // ACT            
            HomeWork[] homeworksResult = await _repository.Get();


            // ASSERT
            Assert.NotNull(homeworksResult);
            Assert.NotEmpty(homeworksResult);
        }

        [Fact]
        public async void Delete()
        {
            // ARRANGE
            var fixture = new Fixture();
            var homework = fixture.Create<HomeWork>();

            int homeworkId = await _repository.Add(homework);

            // ACT            
            await _repository.Delete(homeworkId);

            // ASSERT
            var homeworkGet = await _repository.Get(homeworkId);
            Assert.Null(homeworkGet);
        }

        public void Dispose()
        {
            _repository.CleanTable();
        }
    }
}

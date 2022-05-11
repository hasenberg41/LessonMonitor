using LessonMonitor.Core;
using LessonMonitor.Core.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class HomeworksRepository : IHomeWorkRepository
    {
        private readonly LessonMonitorDbContext _context;

        public HomeworksRepository(LessonMonitorDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(HomeWork homework)
        {
            if (homework is null)
                throw new ArgumentNullException(nameof(homework));

            var newHomeworkEntity = new Entities.Homework
            {
                Title = homework.Title,
                Link = homework.Link,
                Description = homework.Description
            };

            await _context.Homeworks.AddAsync(newHomeworkEntity);
            await _context.SaveChangesAsync();

            return newHomeworkEntity.Id;
        }

        public async Task Delete(int homeworkId)
        {
            if (homeworkId <= 0)
                throw new ArgumentException(nameof(homeworkId));

            _context.Remove(new Entities.Homework { Id = homeworkId });
            await _context.SaveChangesAsync();
        }

        public Task<HomeWork> Get(int homeworkId)
        {
            throw new NotImplementedException();
        }

        public Task<HomeWork[]> Get()
        {
            throw new NotImplementedException();
        }

        public Task Update(HomeWork homeWork)
        {
            throw new NotImplementedException();
        }
    }
}

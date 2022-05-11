using LessonMonitor.Core;
using LessonMonitor.Core.Exceptions;
using LessonMonitor.Core.Repositoryes;
using LessonMonitor.Core.Services;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic
{
    public class HomeworkService : IHomeWorksService
    {
        public const string HOMEWORK_IS_INVALID = "Homework is invalid";

        private readonly IHomeWorkRepository _homeworkRepository;

        public HomeworkService(IHomeWorkRepository homeworkRepository)
        {
            _homeworkRepository = homeworkRepository;
        }

        public async Task<int> Create(HomeWork homework)
        {
            // validation
            if (homework is null)
            {
                throw new ArgumentNullException(nameof(homework));
            }

            bool invalid = homework.Link == null
                || string.IsNullOrWhiteSpace(homework.Title);

            if (invalid)
            {
                throw new BusinessException(HOMEWORK_IS_INVALID);
            }

            // saving in DataBase
            await _homeworkRepository.Add(homework);

            return homework.Id;
        }

        public async Task<bool> Delete(int homeworkId)
        {
            if (homeworkId <= default(int))
                throw new ArgumentException(nameof(homeworkId));

            await _homeworkRepository.Delete(homeworkId);
            return true;
        }
    }
}

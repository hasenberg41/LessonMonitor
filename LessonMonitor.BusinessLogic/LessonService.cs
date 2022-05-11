using LessonMonitor.Core;
using LessonMonitor.Core.Repositoryes;
using LessonMonitor.Core.Services;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic
{
    public class LessonService : ILessonService
    {
        private readonly ILessonsRepository _repository;

        public LessonService(ILessonsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(Lesson lesson)
        {
            if (lesson is null)
            {
                throw new ArgumentNullException(nameof(lesson));
            }

            var existingLesson = await _repository.Get(lesson.YouTubeBroadcastId);

            if (existingLesson is not null)
            {
                throw new InvalidOperationException("Lesson already exists");
            }

            var createdLessonId = await _repository.Add(lesson);

            return createdLessonId;
        }
    }
}

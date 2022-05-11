using AutoMapper;
using LessonMonitor.Core.Repositoryes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly IMapper _mapper;
        private readonly LessonMonitorDbContext _context;

        public LessonsRepository(LessonMonitorDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Add(Core.Lesson newLesson)
        {
            if (newLesson is null)
            {
                throw new ArgumentNullException(nameof(newLesson));
            }

            var lesson = _mapper.Map<Entities.Lesson>(newLesson);

            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();

            return lesson.Id;
        }

        public async Task<Core.Lesson> Get(string youtubeBroadcastId)
        {
            if (youtubeBroadcastId is null)
            {
                throw new ArgumentNullException(nameof(youtubeBroadcastId));
            }

            var lesson = await _context.Lessons.AsNoTracking()
                .FirstOrDefaultAsync(x => x.YouTubeBroadcastId == youtubeBroadcastId);

            return _mapper.Map<Core.Lesson>(lesson);
        }
    }
}

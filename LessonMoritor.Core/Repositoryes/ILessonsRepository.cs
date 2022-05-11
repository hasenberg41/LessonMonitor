using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositoryes
{
    public interface ILessonsRepository
    {
        Task<int> Add(Lesson newLesson);
        Task<Lesson> Get(string youtubeBroadcastId);
    }
}

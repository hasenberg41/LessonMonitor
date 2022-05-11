using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface ILessonService
    {
        Task<int> Create(Lesson lesson);
    }
}
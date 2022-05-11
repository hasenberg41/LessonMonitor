using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface IHomeWorksService
    {
        Task<int> Create(HomeWork homework);
        Task<bool> Delete(int homeworkId);
    }
}

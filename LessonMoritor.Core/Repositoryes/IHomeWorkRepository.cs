using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositoryes
{
    public interface IHomeWorkRepository
    {
        Task<int> Add(HomeWork homeWork);
        Task Update(HomeWork homeWork);
        Task<HomeWork> Get(int homeworkId);
        Task<HomeWork[]> Get();
        Task Delete(int homeworkId);

    }
}
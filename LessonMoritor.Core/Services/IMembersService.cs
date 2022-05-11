using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface IMembersService
    {
        Task<int> Create(Member member);
        Task<Member[]> Get();
    }
}

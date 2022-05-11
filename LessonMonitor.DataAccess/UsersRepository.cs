using LessonMonitor.Core.Repositoryes;

namespace LessonMonitor.DataAccess
{
    public class UsersRepository : IUsersRepository
    {
        public object[] Get()
        {
            return new[] { new object()};
        }
    }
}

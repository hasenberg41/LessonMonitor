namespace LessonMonitor.Core.Services
{
    public interface IUserService
    {
        object[] Get();
        void Create(object user);
    }
}

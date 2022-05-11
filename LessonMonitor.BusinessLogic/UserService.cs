using LessonMonitor.Core.Repositoryes;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly GitHubClient _gitHubClient;

        public UserService(IUsersRepository usersRepository, GitHubClient gitHubClient)
        {
            _usersRepository = usersRepository;
            _gitHubClient = gitHubClient;
        }

        public object[] Get()
        {
            var users = _usersRepository.Get();

            return users;
        }

        public void Create(object user)
        {
            throw new NotImplementedException();
        }
    }
    public class GitHubClient
    {
        public GitHubUser Get(string nickName)
        {
            return new GitHubUser();
        }
    }

    public class GitHubUser
    {
    }
}

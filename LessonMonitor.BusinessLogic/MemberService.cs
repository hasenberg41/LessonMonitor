using LessonMonitor.BusinessLogic.Validators;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositoryes;
using LessonMonitor.Core.Services;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.BusinessLogic
{
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _repository;

        public MembersService(IMembersRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Create(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            var validator = new MemberValidator();
            var validationResult = await validator.ValidateAsync(member);

            if (! validationResult.IsValid)
            {
                throw new InvalidOperationException(validationResult.ToString(", "));
            }

            var existedMember = await _repository.Get(member.YouTubeUserId);
            if (existedMember != null)
            {
                throw new InvalidOperationException("Member already exists");
            }

            var result = await _repository.Add(member);
            return result;
        }

        public async Task<Member[]> Get()
        {
            return await _repository.Get();
        }
    }
}

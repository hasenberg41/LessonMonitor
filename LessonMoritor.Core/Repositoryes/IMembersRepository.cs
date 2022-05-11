﻿using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositoryes
{
    public interface IMembersRepository
    {
        Task<int> Add(Member newMember);
        Task<Member[]> Get();
        Task<Member> Get(string youTubeUserId);
    }
}

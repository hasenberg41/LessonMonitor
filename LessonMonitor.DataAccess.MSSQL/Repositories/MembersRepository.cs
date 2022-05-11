using LessonMonitor.Core.Repositoryes;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public MembersRepository(LessonMonitorDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Add(Core.Member newMember)
        {
            if (newMember is null)
            {
                throw new ArgumentNullException(nameof(newMember));
            }

            var newMemberEntity = _mapper.Map<Entities.Member>(newMember);

            await _context.Members.AddAsync(newMemberEntity);
            await _context.SaveChangesAsync();

            return newMemberEntity.Id;
        }

        public async Task<Core.Member[]> Get()
        {
            var members = await _context.Members
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<Core.Member[]>(members);
        }

        public async Task<Core.Member> Get(string youTubeUserId)
        {
            if (youTubeUserId is null)
            {
                throw new ArgumentNullException(nameof(youTubeUserId));
            }

            var member = await _context.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.YoutubeUserId == youTubeUserId);

            return _mapper.Map<Core.Member>(member);
        }
    }
}

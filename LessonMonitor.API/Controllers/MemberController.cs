using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMembersService _memberService;
        private readonly IMapper _mapper;

        public MemberController(IMembersService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Member[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var membersCore = await _memberService.Get();
            var membersResult = _mapper.Map<Member[]>(membersCore);

            return Ok(membersResult);
        }

        [HttpPost]
        [ProducesResponseType(typeof(NewMember), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Member newMember)
        {
            var member = _mapper.Map<Core.Member>(newMember);

            var memberId = await _memberService.Create(member);

            return Ok(new { MemberId = memberId });
        }
    }
}

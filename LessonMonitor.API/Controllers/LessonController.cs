using AutoMapper;
using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILessonService _service;

        public LessonController(IMapper mapper, ILessonService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(NewLesson), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> Create(NewLesson newLesson)
        {
            var lesson = _mapper.Map<Core.Lesson>(newLesson);

            var lessonId = await _service.Create(lesson);

            return Ok(new { LessonId = lessonId });
        }
    }
}

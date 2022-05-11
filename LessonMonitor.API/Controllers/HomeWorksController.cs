using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeWorksController : ControllerBase
    {
        private readonly IHomeWorksService _homeWorksService;

        public HomeWorksController(IHomeWorksService homeWorksService)
        {
            _homeWorksService = homeWorksService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewHomework request)
        {
            var homework = new Core.HomeWork
            {
                Title = request.Title,
                Description = request.Description,
                Link = request.Link
            };

            var result = await _homeWorksService.Create(homework);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int homeworkId)
        {
            var result = await _homeWorksService.Delete(homeworkId);

            return Ok(result);
        }
    }
}

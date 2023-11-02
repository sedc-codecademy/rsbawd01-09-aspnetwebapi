using EF.DatabaseFirst.Example.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF.DatabaseFirst.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private AcademyExampleContext _academyExampleContext;

        public CoursesController(AcademyExampleContext academyExampleContext)
        {
            _academyExampleContext = academyExampleContext;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = _academyExampleContext.Courses.ToList();

            return Ok(response);
        }
    }
}

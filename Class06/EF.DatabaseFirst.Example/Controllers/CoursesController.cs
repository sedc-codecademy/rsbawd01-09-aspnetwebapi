using EF.DatabaseFirst.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<Course> response = _academyExampleContext
                .Courses
                .Include(c => c.Teacher)
                //.Where(c => c.Teacher.FirstName == "Zoran")
                .ToList();

            return Ok(response);
        }
    }
}

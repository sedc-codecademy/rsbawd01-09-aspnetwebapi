using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurFirstWebApi.Models;

namespace OurFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController() { }

        [HttpGet("students")]
        public IEnumerable<Student> GetAllStudents() 
        {
            Student student1 = new Student()
            {
                Age = 20,
                FName = "John",
                LName = "Doe",
                HomeTown = "New York",
                StudentId = 10
            };

            Student student2 = new Student()
            {
                Age = 35,
                FName = "Cristiano",
                LName = "Ronaldo",
                HomeTown = "Porto",
                StudentId = 20
            };

            List<Student> list = new List<Student>();

            list.Add(student1);
            list.Add(student2);

            return list;
        }

        [HttpPost("create")]
        public Student CreateStudent([FromBody] Student student) 
        {
            if (student == null)
                throw new Exception("The provided value is null");

            // Do some work in the database

            return student;
        }
    }
}

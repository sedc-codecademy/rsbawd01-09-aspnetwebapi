using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.NotesAndTagsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // https://localhost:7261/api/notes/queryString?index=1212&userId=99
        [HttpGet("queryString")]
        public ActionResult<string> GetByQueryString(int? index, int? userId) 
        {
            if (userId == null) 
                return BadRequest("The userId value is NULL");

            if (index == null)
                return BadRequest("The index value is NULL");

            string response = "This end-point is based on query string parameters" +
                $" and the values of parameter called index is {index} and parameter userId {userId}";

            return response;
        }

        // https://localhost:7261/api/notes/102
        [HttpGet("{index}")]
        public ActionResult<string> GetByIndex(int index) 
        {
            string response = "This end-point is based on parameters" +
                    $" and the values of parameter called index is {index}";

            return response;
        }

        // https://localhost:7261/api/notes/{someValue}/priority/{somePriorityValue}
        [HttpGet("{category}/priority/{priority}")]
        public ActionResult<string> GetByCategoryAndPriority(string category, int priority)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest("The category filed is required!!!");

            string response = "This end-point is based on multiple parameters with custom route" +
                    $" and the values of parameter called category is {category} and priority is {priority}";

            // This is for testing only
            // we are returing
            // the passed values
            // to see the result
            return response;
        }

    }
}

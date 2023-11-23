using InterfaceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Services;
using Configurations;

namespace NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : Controller
    {
        private readonly INoteService _noteService;
        private readonly HttpClient _client;
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;
        public ExternalController(INoteService noteService,
            IOptions<AppSettings> options, IUserService userService)
        {
            _client = new HttpClient();
            _noteService = noteService;
            _userService = userService;
            _appSettings = options.Value;
        }

        // This is called from the console app
        [HttpGet("performance/getnote")]
        public ActionResult<long> GetNotePerformance()
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                _noteService.GetUserNotes(1);
            }
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            return elapsed;
        }
        [HttpGet("registertestuser")]
        public ActionResult<RegisterDto> RegisterTestUser()
        {
            HttpResponseMessage response = _client
                .GetAsync(_appSettings.TestDataApi).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            RegisterDto model = JsonConvert
                .DeserializeObject<RegisterDto>(responseBody);
            _userService.Register(model);

            return model;
        }
    }
}

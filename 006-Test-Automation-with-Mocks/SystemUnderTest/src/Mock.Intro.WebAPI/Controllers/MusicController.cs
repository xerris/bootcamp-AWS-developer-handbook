using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mock.Intro.Services;
using Mock.Intro.Services.Domain;
using Serilog;

namespace Mock.Intro.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService service;

        public MusicController(IMusicService service)
        {
            this.service = service;
        }

        [HttpGet("hello")]
        public async Task<IActionResult> SayHello()
        {
            Log.Debug("Saying Hello from HelloService");
            return Ok(await service.SayHello());
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> AddSong([FromBody]Song song)
        {
            Log.Debug("adding song {@Song}", song);
            return Ok(await service.AddSongAsync(song));
        }
        
        [HttpGet("messages")]
        public async Task<IActionResult> GetMusicMessages()
        {
            Log.Debug("Getting outstanding messages");
            return Ok(await service.GetMusicMessages());
        }
    }
}
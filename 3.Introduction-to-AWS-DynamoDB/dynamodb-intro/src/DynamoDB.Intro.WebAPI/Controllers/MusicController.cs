using System.Threading.Tasks;
using DynamoDB.Intro.Services;
using DynamoDB.Intro.Services.Domain;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DynamoDB.Intro.WebAPI.Controllers
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
    }
}
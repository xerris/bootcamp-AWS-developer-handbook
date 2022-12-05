using System.Threading.Tasks;
using DynamoDB.Intro.Services.Domain;
using DynamoDB.Intro.Services.Repositories;

namespace DynamoDB.Intro.Services
{
    public interface IMusicService
    {
        Task<string> SayHello();
        Task<Song> AddSongAsync(Song song);
    }

    public class MusicService : IMusicService
    {
        private readonly IApplicationConfig config;
        private readonly IMusicRepository musicRepository;

        public MusicService(IApplicationConfig config, IMusicRepository musicRepository)
        {
            this.config = config;
            this.musicRepository = musicRepository;
        }

        public async Task<string> SayHello()
        {
            return await Task.FromResult(config.HelloMessage);
        }

        public async Task<Song> AddSongAsync(Song song)
        {
            var saved = await musicRepository.AddSong(song);
            return song;
        }
    }
}
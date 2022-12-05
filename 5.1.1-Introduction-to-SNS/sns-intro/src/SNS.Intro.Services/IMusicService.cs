using System.Collections.Generic;
using System.Threading.Tasks;
using SNS.Intro.Services.Domain;
using SNS.Intro.Services.Repositories;

namespace SNS.Intro.Services
{
    public interface IMusicService
    {
        Task<string> SayHello();
        Task<Song> AddSongAsync(Song song);
        Task<IEnumerable<Song>> GetMusicMessages();
    }

    public class MusicService : IMusicService
    {
        private readonly IApplicationConfig config;
        private readonly IMusicRepository musicRepository;
        private readonly IMusicMailbox musicMailbox;
        private readonly INotificationService notificationService;

        public MusicService(IApplicationConfig config, IMusicRepository musicRepository, IMusicMailbox musicMailbox,
            INotificationService notificationService)
        {
            this.config = config;
            this.musicRepository = musicRepository;
            this.musicMailbox = musicMailbox;
            this.notificationService = notificationService;
        }

        public async Task<string> SayHello()
        {
            return await Task.FromResult(config.HelloMessage);
        }

        public async Task<Song> AddSongAsync(Song song)
        {
            var saved = await musicRepository.AddSong(song);
            await notificationService.PublishSongAdded(saved);
            return song;
        }

        public async Task<IEnumerable<Song>> GetMusicMessages()
        {
            var songMessages = await musicMailbox.ReceiveMailAsync();
            return songMessages;
        }
    }
}
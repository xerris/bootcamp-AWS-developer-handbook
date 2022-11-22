using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Serilog;
using SNS.Intro.Services.Domain;
using Xerris.DotNet.Core.Time;

namespace SNS.Intro.Services
{
    public interface INotificationService
    {
        Task PublishSongAdded(Song song);
    }

    public class NotificationService : INotificationService
    {
        private readonly IApplicationConfig config;
        private readonly IAmazonSimpleNotificationService snsClient;

        public NotificationService(IApplicationConfig config, IAmazonSimpleNotificationService snsClient)
        {
            this.config = config;
            this.snsClient = snsClient;
        }

        public async Task PublishSongAdded(Song song)
        {
            var request = new PublishRequest
            {
                Message = $"Song: {song.SongTitle} was added {Clock.MountainStandardTime.Now.ToLongDateString()}",
                TopicArn = config.SongAddedTopic
            };
            
            var response = await snsClient.PublishAsync(request);
            Log.Debug("Publish song added response {@Response}", response.HttpStatusCode);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Mock.Intro.Services.Domain;
using Xerris.DotNet.Core.Extensions;

namespace Mock.Intro.Services
{
    public interface IMusicMailbox
    {
        Task<IEnumerable<Song>> ReceiveMailAsync();
    }

    public class MusicMailbox : IMusicMailbox
    {
        private readonly IApplicationConfig config;
        private readonly IAmazonSQS client;

        public MusicMailbox(IApplicationConfig config)
        {
            this.config = config;
            client = new AmazonSQSClient(config.AwsRegion);
        }

        public async Task<IEnumerable<Song>> ReceiveMailAsync()
        {
            var request = MakeReceiveRequest();
            var response = await client.ReceiveMessageAsync(request);
            return response.Messages.Select(x => x.Body.FromJson<Song>());
        }

        private ReceiveMessageRequest MakeReceiveRequest()
        {
            return new ReceiveMessageRequest
            {
                QueueUrl = config.SongAddedQueueUrl,
                MaxNumberOfMessages = 5
            };
        }
    }
}
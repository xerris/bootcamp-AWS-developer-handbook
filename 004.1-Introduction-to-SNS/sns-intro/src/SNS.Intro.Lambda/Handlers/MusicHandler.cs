using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using SNS.Intro.Services;
using SNS.Intro.Services.Domain;
using Xerris.DotNet.Core;
using Xerris.DotNet.Core.Aws.Api;

namespace SNS.Intro.Lambda.Handlers
{
    public class MusicHandler
    {
        private readonly IMusicService service;

        public MusicHandler() : this(IoC.Resolve<IMusicService>())
        {
        }
        
        public MusicHandler(IMusicService service)
        {
            this.service = service;
        }

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public async Task<APIGatewayProxyResponse> SayHello(APIGatewayProxyRequest request)
        {
            var serviceResponse = await service.SayHello();
            return serviceResponse.Ok();
        }

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public async Task<APIGatewayProxyResponse> AddSong(APIGatewayProxyRequest request)
        {
            var song = request.Parse<Song>();
            var serviceResponse = await service.AddSongAsync(song);
            return serviceResponse.Ok();
        }
    }
}
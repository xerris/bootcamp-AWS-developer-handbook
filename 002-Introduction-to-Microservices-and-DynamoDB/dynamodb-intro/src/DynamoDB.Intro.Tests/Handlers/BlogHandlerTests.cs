using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using DynamoDB.Intro.Lambda.Handlers;
using DynamoDB.Intro.Services;
using Moq;
using Xerris.DotNet.Core.Validations;
using Xerris.DotNet.TestAutomation;
using Xunit;

namespace DynamoDB.Intro.Tests.Handlers
{
    public class BlogHandlerTests : MockBase
    {
        private Mock<IMusicService> service;
        private readonly MusicHandler handler;

        public BlogHandlerTests()
        {
            service = Strict<IMusicService>();
            handler = new MusicHandler(service.Object);
        }

        [Fact]
        public async Task SayHello()
        {
            var responseFromService = "hi from the mock";
            service.Setup(x => x.SayHello())
                   .ReturnsAsync(responseFromService);

            var response = await handler.SayHello(new APIGatewayProxyRequest());
            var helloMessage = response.Body;
            Validate.Begin()
                    .IsNotNull(helloMessage, "helloMessage").Check()
                    .IsEqual(helloMessage, responseFromService, "response from Service is wrong")
                    .Check();
        }
    }
}
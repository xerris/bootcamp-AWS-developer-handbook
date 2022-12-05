using FluentAssertions;
using Mock.Intro.Services;
using Xerris.DotNet.Core;
using Xerris.DotNet.Core.Validations;
using Xunit;

namespace Mock.Intro.Tests
{
    public class IoCTests
    {
        [Fact]
        public void AppConfig()
        {
            var config = IoC.Resolve<IApplicationConfig>();
            Validate.Begin()
                    .IsNotNull(config, "config").Check()
                    .IsEqual(config.HelloMessage, "Hello from Hello.Lambda project", "HelloMessage")
                    .Check();
        }

        [Fact]
        public void HelloService() => Has<IMusicService>();

        private static void Has<T>() => IoC.Resolve<T>().Should().NotBeNull();
        
    }
}
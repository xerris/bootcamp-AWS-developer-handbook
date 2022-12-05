using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Newtonsoft.Json;
using Xerris.DotNet.Core;
using Xerris.DotNet.Core.Aws.Secrets;

namespace SNS.Intro.Services
{
    public interface IApplicationConfig
    {
        SecretConfigCollection SecretConfigurations { get; }
        string HelloMessage { get; set; }
        string Region { get; set; }
        RegionEndpoint AwsRegion { get; }
        string SongAddedQueueUrl { get; }
        string SongAddedTopic { get; }
    }

    public class ApplicationConfig : IApplicationConfig, IApplicationConfigBase
    {
        public SecretConfigCollection SecretConfigurations { get; set; }
        public AWSOptions AwsOptions { get; set; }
        public string HelloMessage { get; set; }
        public string Region { get; set; }
        public string SongAddedQueueUrl { get; set; }
        public string SongAddedTopic { get; set; }

        [JsonIgnore]
        public RegionEndpoint AwsRegion => RegionEndpoint.GetBySystemName(Region);
    }
}
using System.Threading.Tasks;
using DynamoDB.Intro.Services.Domain;

namespace DynamoDB.Intro.Services.Repositories
{
    public interface IMusicRepository
    {
        Task<Song> AddSong(Song toAdd);
    }
    
    public class MusicRepository : IMusicRepository
    {
        private readonly IDynamoDbContextProvider dynamoDbContextProvider;
        private readonly IApplicationConfig config;

        public MusicRepository(IDynamoDbContextProvider dynamoDbContextProvider, IApplicationConfig config)
        {
            this.dynamoDbContextProvider = dynamoDbContextProvider;
            this.config = config;
        }

        public async Task<Song> AddSong(Song toSave)
        {
            using var context = dynamoDbContextProvider.Create();
            await context.SaveAsync(toSave);
            return toSave;
        }
    }
}
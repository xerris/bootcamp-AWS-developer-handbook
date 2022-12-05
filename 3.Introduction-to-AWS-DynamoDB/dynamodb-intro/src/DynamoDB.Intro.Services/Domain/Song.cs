using Amazon.DynamoDBv2.DataModel;

namespace DynamoDB.Intro.Services.Domain
{
    [DynamoDBTable("Music")]
    public class Song
    {
        [DynamoDBHashKey("Artist")]
        public string Artist { get; set; }
        
        [DynamoDBRangeKey("SongTitle")]
        public string SongTitle { get; set; }

        [DynamoDBProperty("AlbumTitle")]
        public string AlbumTitle { get; set; }

        [DynamoDBProperty("Awards")]
        public int Awards { get; set; }
    }
}
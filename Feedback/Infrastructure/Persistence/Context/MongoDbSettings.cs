using Feedback.Core.Application.Interfaces;

namespace Feedback.Infrastructure.Persistence.Context
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string CommentsCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}

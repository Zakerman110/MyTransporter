using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MongoDB.Driver;

namespace Feedback.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoCollection<Comment> Comments { get; set; }

        public ApplicationDbContext(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            Comments = database.GetCollection<Comment>(settings.CommentsCollectionName);
        }

        public IEnumerable<Comment> FindWithSpecificationPattern(ISpecification<Comment> specification = null)
        {
            return SpecificationEvaluator<Comment>.GetQuery(Comments.Find(x => true).ToList().AsQueryable(), specification);
        }
    }
}

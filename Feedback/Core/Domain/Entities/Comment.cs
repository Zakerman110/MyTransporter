using Feedback.Core.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Feedback.Core.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        [BsonElement("CommentDate")]
        public DateTime Date { get; set; } = DateTime.Now;
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}

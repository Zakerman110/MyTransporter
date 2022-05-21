namespace Feedback.Core.Application.Interfaces
{
    public interface IMongoDbSettings
    {
        string CommentsCollectionName { get; set; }
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}

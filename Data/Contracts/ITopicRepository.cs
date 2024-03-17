using Models;

namespace Data.Contracts
{
    public interface ITopicRepository
    {
        Task CreateTopic(TopicModelRequest requestForTopicCreation);
    }
}

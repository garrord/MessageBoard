using Models;

namespace Data.Contracts
{
    public interface ITopicRepositoryManager
    {
        Task CreateTopic(TopicModelRequest requestForTopicCreation);
    }
}

using Models;

namespace Data.Contracts
{
    public interface ITopicQueryRepositoryManager
    {
        Task<List<TopicModel>> Get();
    }
}

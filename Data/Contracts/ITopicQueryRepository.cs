using Models;

namespace Data.Contracts
{
    public interface ITopicQueryRepository
    {
        Task<IEnumerable<IGrouping<string, TopicGroupJoinModel>>> Get();
    }
}

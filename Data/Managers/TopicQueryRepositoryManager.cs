using Data.Contracts;
using Models;

namespace Data.Managers
{
    public class TopicQueryRepositoryManager : ITopicQueryRepositoryManager
    {
        private readonly ITopicQueryRepository _topicQueryRepository;

        public TopicQueryRepositoryManager(ITopicQueryRepository topicQueryRepository)
        {
            _topicQueryRepository = topicQueryRepository;
        }

        public async Task<List<TopicModel>> Get()
        {
            IEnumerable<IGrouping<string, TopicGroupJoinModel>> groupedTopics = await _topicQueryRepository.Get();
            List<TopicModel> topicModels = new();
            foreach (var groupedTopic in groupedTopics)
            {
                int count = groupedTopic.Count(x => x.MessageText != null);
                string topicName = groupedTopic.Key;
                TopicModel topicModel = new()
                {
                    TopicName = topicName,
                    PostCount = count
                };
                topicModels.Add(topicModel);
            }

            return topicModels;
        }
    }
}

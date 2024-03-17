using Data.Contracts;
using Models;

namespace Data.Managers
{
    public class TopicRepositoryManager : ITopicRepositoryManager
    {
        private readonly ITopicRepository _topicRepository;

        public TopicRepositoryManager(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task CreateTopic(TopicModelRequest requestForTopicCreation)
        {
            await _topicRepository.CreateTopic(requestForTopicCreation);
        }
    }
}

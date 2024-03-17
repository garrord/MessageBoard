using Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.QueyRepositories
{
    public class TopicQueryRepository : ITopicQueryRepository
    {
        private readonly MessageBoardContext _context;

        public TopicQueryRepository(MessageBoardContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IGrouping<string, TopicGroupJoinModel>>> Get()
        {
            IEnumerable<IGrouping<string, TopicGroupJoinModel>> groupedTopics = await _context.Topic
                .SelectMany(
                    topic => _context.Threads.Where(thread => topic.TopicId == thread.TopicId).DefaultIfEmpty(),
                    (topic, thread) => new
                    {
                        TopicId = topic.TopicId,
                        TopicName = topic.TopicName,
#pragma warning disable CS8602
                        ThreadId = thread.ThreadId,
#pragma warning restore CS8602
                        ThreadName = thread.ThreadName
                    }
                )
                .SelectMany(
                    topicThread => _context.Messages.Where(messages => topicThread.ThreadId == messages.ThreadId).DefaultIfEmpty(),
                    (topicThread, message) => new TopicGroupJoinModel()
                    {
                        TopicId = topicThread.TopicId,
                        TopicName = topicThread.TopicName,
                        ThreadId = topicThread.ThreadId,
                        ThreadName = topicThread.ThreadName,
#pragma warning disable CS8602
                        MessageText = message.ThreadMessage
#pragma warning restore CS8602
                    }
                )
                .GroupBy(x => x.TopicName).ToListAsync();

            return groupedTopics;
        }
    }
}

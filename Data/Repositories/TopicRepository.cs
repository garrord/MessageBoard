using Data.Contracts;
using Data.Entities;
using Models;

namespace Data.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly MessageBoardContext _context;

        public TopicRepository(MessageBoardContext context)
        {
            _context = context;
        }

        public async Task CreateTopic(TopicModelRequest requestForTopicCreation)
        {
            Topic entityToUpdate = new();
            entityToUpdate.TopicName = requestForTopicCreation.TopicName;
            entityToUpdate.DateTimeCreated = DateTime.Now;

            _context.Topic.Add(entityToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
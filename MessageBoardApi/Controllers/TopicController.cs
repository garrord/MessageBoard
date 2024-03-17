using Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MessageBoardApi.Controllers
{
    [ApiController]
    [Route("api/topic")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicQueryRepositoryManager _topicQueryRepositoryManager;
        private readonly ITopicRepositoryManager _topicRepositoryManager;

        public TopicController(
            ITopicQueryRepositoryManager topicQueryRepositoryManager,
            ITopicRepositoryManager topicRepositoryManager
        )
        {
            _topicQueryRepositoryManager = topicQueryRepositoryManager;
            _topicRepositoryManager = topicRepositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TopicModel> topics = await _topicQueryRepositoryManager.Get();
            return new JsonResult(topics);
        }

        [HttpPut]
        public async Task<IActionResult> Create(TopicModelRequest requestForTopicCreation)
        {
            await _topicRepositoryManager.CreateTopic(requestForTopicCreation);
            return Ok();
        }

    }
}
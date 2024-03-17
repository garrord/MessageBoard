namespace Models
{
    public class TopicGroupJoinModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int? ThreadId { get; set; }
        public string? ThreadName { get; set; }
        public int? MessageId { get; set; }
        public string? MessageText { get; set; }
    }
}
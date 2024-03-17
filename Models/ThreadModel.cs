namespace Models
{
    public class ThreadModel
    {
#pragma warning disable CS8618
        public string ThreadName { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int ReplyCount { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Topic
    {
#pragma warning disable CS8618
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public List<Thread> Threads { get; set; }
    }
}
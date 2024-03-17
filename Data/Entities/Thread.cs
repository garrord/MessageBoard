using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Thread
    {
#pragma warning disable CS8618
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ThreadId { get; set; }
        public string ThreadName { get; set; }
        public User UserCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public List<Message> Messages { get; set; }
        public Topic Topic { get; set; }
        [ForeignKey("TopicId")]
        public int TopicId { get; set; }
    }
}
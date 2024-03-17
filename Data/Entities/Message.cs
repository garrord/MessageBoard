using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Message
    {
#pragma warning disable CS8618
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string ThreadMessage { get; set; }
        public User UserCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public Thread Thread { get; set; }
        [ForeignKey("ThreadId")]
        public int ThreadId { get; set; }
    }
}
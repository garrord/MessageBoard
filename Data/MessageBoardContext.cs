using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Thread = Data.Entities.Thread;

namespace Data
{
    public class MessageBoardContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topic { get; set; }

        public MessageBoardContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.UserCreated)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
using BusinessLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MessageAppDbContext : IdentityDbContext<User>
    {
        public MessageAppDbContext() : base()
        {

        }

        public MessageAppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=TIMI-PC;Database=MessageApp;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}

using System;
using System.IO;
using ChatApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ChatApp.Infrastructure
{
    public class ChatAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        public string ConnectionString { get; private set; }

        public ChatAppContext(DbContextOptions<ChatAppContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Conversation>().ToTable("Conversation");
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ChatAppContext>
    {
        public ChatAppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../ChatApp.UI/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ChatAppContext>();
            var connectionString = configuration.GetConnectionString("ChatAppContext");
            builder.UseSqlServer(connectionString);
            return new ChatAppContext(builder.Options);
        }
    }
}
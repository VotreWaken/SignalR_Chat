using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace SignalR_Chat.Models
{
    public class ChatContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public async void SaveMessage(string Username, string message, string conId)
        {
            Message Mes = new Message
            {
                Content = message,
                UserName = Username
            };

            if (Mes != null)
                await Messages.AddAsync(Mes);
            SaveChanges();
        }
    }
}

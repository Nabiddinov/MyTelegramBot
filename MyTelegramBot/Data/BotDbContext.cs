using Microsoft.EntityFrameworkCore;
using MyTelegramBot.Entity;

namespace MyTelegramBot.Data
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

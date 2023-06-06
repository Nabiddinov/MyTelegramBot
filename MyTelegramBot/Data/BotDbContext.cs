using Microsoft.EntityFrameworkCore;
using MyTelegramBot.Entity;

namespace MyTelegramBot.Data
{
    public class BotDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options) { }
    }
}

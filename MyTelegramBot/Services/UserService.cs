using MyTelegramBot.Data;
using MyTelegramBot.Entity;

namespace MyTelegramBot.Services
{
    public class UserService
    {
        private readonly BotDbContext _context;

        public UserService(BotDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(BotDbContext));
        }

        public async Task<User> GetUserAsync(long? userId)
        {
            ArgumentNullException.ThrowIfNull((userId));
            ArgumentNullException.ThrowIfNull(_context.Users);


            return await _context.Users.FindAsync(userId);

        }

        public async Task<(bool isSucsess, string ErrorMessage)> UpdateLanguageCodeAsync(long? userId, string LanguageCode)
        {
            ArgumentNullException.ThrowIfNull(LanguageCode);

            var user = await GetUserAsync(userId);

            if (user is null)
                return (false, "User not found");

            user.LanguageCode = LanguageCode;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return (true, null);
        }


        public async Task<string?> GetLanguageCodeAsync(long? userId)
        {
            var user = await GetUserAsync(userId);

            return user?.LanguageCode;
        }

    }
}

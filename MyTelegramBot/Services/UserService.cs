using MyTelegramBot.Entity;

namespace MyTelegramBot.Services
{
    public class UserService
    {
        public UserService()
        {

        }

        public async Task<User> GetUserAsync(long accountId)
        {
            return new User() { LanguageCode = "en" };

        }
    }
}

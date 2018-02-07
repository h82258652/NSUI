using NSUI.Sample.Models;

namespace NSUI.Sample.Services
{
    public class UserService
    {
        public User GetUser()
        {
            return new User()
            {
                Username = "mario"
            };
        }
    }
}
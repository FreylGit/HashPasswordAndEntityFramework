using System.Security.Cryptography;

namespace ConsoleApp1
{
    public class UserData
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }



        public void ParseUser(User user)
        {
            Username = user.Username;
            CreatePasswordHash(user.Password);
        }
        public void Show()
        {
            Console.WriteLine($"Username:{Username}");


        }
        private void CreatePasswordHash(string password)
        {
            using (var hmc = new HMACSHA512())
            {
                PasswordKey = hmc.Key;
                PasswordHash = hmc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }

}

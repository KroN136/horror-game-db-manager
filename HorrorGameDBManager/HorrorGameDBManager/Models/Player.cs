using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Player : ModelWithStringId
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDateTime { get; }
        public uint Xp { get; set; }
        public bool IsOnline { get; set; }
        public bool EnableAnalytics { get; set; }

        public Player(string username, string email, string password, bool enableAnalytics) : base(8)
        {
            Username = username;
            Email = email;
            Password = password;
            RegistrationDateTime = DateTime.UtcNow;
            Xp = 0;
            IsOnline = false;
            EnableAnalytics = enableAnalytics;
        }
    }
}

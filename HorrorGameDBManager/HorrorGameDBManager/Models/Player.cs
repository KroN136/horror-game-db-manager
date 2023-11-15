using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Player : ModelWithStringId
    {
        private static readonly List<object> existingIds = new();

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDateTime { get; }
        public uint Xp { get; set; }
        public bool IsOnline { get; set; }
        public bool EnableAnalytics { get; set; }

        public Player(string username, string email, string password, bool enableAnalytics) : base(8)
        {
            Id = GenerateId(existingIds);
            existingIds.Add(Id);

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

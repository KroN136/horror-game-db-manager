using System;

namespace HorrorGameDBManager.Models
{
    internal class Player
    {
        public string Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDateTime { get; }
        public uint Xp { get; set; }
        public bool IsOnline { get; set; }
        public bool EnableAnalytics { get; set; }

        public Player(string username, string email, string password, bool enableAnalytics)
        {
            Id = Database.GeneratePlayerId();
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

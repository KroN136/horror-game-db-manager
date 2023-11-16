using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Player : ModelWithStringId
    {
        private static readonly List<object> existingIds = new();

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDateTime { get; private set; }
        public uint Xp { get; set; }
        public bool IsOnline { get; set; }
        public bool EnableDataCollection { get; set; }

        public Player(string username, string email, string password, bool enableDataCollection, bool generateId = true) : base(8)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            Username = username;
            Email = email;
            Password = password;
            RegistrationDateTime = DateTime.UtcNow;
            Xp = 0;
            IsOnline = false;
            EnableDataCollection = enableDataCollection;
        }

        public override Player Clone() => new(Username, Email, Password, EnableDataCollection, false) { Id = Id, RegistrationDateTime = RegistrationDateTime, Xp = Xp, IsOnline = IsOnline };
    }
}

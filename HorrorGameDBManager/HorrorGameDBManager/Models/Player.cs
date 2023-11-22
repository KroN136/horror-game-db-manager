using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class Player : ModelWithStringId
    {
        private static readonly List<object> existingIds = new();

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDateTime { get; private set; }
        public byte ExperienceLevelId { get; set; }
        public ushort ExperiencePoints { get; set; }
        public byte AbilityPoints { get; set; }
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
            ExperienceLevelId = (byte) Database.ExperienceLevels.Entries.First().Id;
            ExperiencePoints = 0;
            AbilityPoints = 0;
            IsOnline = false;
            EnableDataCollection = enableDataCollection;
        }

        [JsonConstructor]
        public Player(object id, string username, string email, string password, DateTime registrationDateTime, byte experienceLevelId, ushort experiencePoints, byte abilityPoints, bool isOnline, bool enableDataCollection) : base(8)
        {
            id = id.ToString()!;
            Id = id;
            existingIds.Add(Id);

            Username = username;
            Email = email;
            Password = password;
            RegistrationDateTime = registrationDateTime;
            ExperienceLevelId = experienceLevelId;
            ExperiencePoints = experiencePoints;
            AbilityPoints = abilityPoints;
            IsOnline = isOnline;
            EnableDataCollection = enableDataCollection;
        }

        [JsonIgnore]
        public ExperienceLevel ExperienceLevel => Database.ExperienceLevels.Get(ExperienceLevelId);
        [JsonIgnore]
        public IEnumerable<AcquiredAbility> AcquiredAbilities => Database.AcquiredAbilities.Entries.Where(acquiredAbility => acquiredAbility.PlayerId.Equals(Id));
        [JsonIgnore]
        public IEnumerable<PlayerSession> PlayerSessions => Database.PlayerSessions.Entries.Where(playerSession => playerSession.PlayerId.Equals(Id));

        public override Player Clone() => new(Username, Email, Password, EnableDataCollection, false) { Id = Id, RegistrationDateTime = RegistrationDateTime, ExperienceLevelId = ExperienceLevelId, ExperiencePoints = ExperiencePoints, AbilityPoints = AbilityPoints, IsOnline = IsOnline };
    }
}

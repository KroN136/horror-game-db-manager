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
            ExperienceLevelId = (byte) Database.ExperienceLevels.GetAll().First().Id;
            ExperiencePoints = 0;
            AbilityPoints = 0;
            IsOnline = false;
            EnableDataCollection = enableDataCollection;
        }

        public ExperienceLevel ExperienceLevel => Database.ExperienceLevels.Get(ExperienceLevelId);
        public IEnumerable<AcquiredAbility> AcquiredAbilities => Database.AcquiredAbilities.GetAll().Where(acquiredAbility => acquiredAbility.PlayerId.Equals(Id));
        public IEnumerable<CollectedArtifact> CollectedArtifacts => Database.CollectedArtifacts.GetAll().Where(collectedArtifact => collectedArtifact.PlayerId.Equals(Id));
        public IEnumerable<PlayerSession> PlayerSessions => Database.PlayerSessions.GetAll().Where(playerSession => playerSession.PlayerId.Equals(Id));

        public override Player Clone() => new(Username, Email, Password, EnableDataCollection, false) { Id = Id, RegistrationDateTime = RegistrationDateTime, ExperienceLevelId = ExperienceLevelId, ExperiencePoints = ExperiencePoints, AbilityPoints = AbilityPoints, IsOnline = IsOnline };
    }
}

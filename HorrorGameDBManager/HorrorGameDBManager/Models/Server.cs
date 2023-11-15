using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Server : ModelWithUShortId
    {
        private static readonly List<object> existingIds = new();

        public string IpAddress { get; }
        public ushort PlayerCapacity { get; set; }
        public bool IsActive { get; set; }

        public Server(string ipAddress, ushort playerCapacity, bool isActive)
        {
            Id = GenerateId(existingIds);
            existingIds.Add(Id);

            IpAddress = ipAddress;
            PlayerCapacity = playerCapacity;
            IsActive = isActive;
        }
    }
}

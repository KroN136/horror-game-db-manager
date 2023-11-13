namespace HorrorGameDBManager.Models
{
    internal class Server
    {
        public ushort Id { get; }
        public string IpAddress { get; }
        public ushort PlayerCapacity { get; set; }
        public bool IsActive { get; set; }

        public Server(string ipAddress, ushort playerCapacity, bool isActive)
        {
            Id = Database.GenerateServerId();
            IpAddress = ipAddress;
            PlayerCapacity = playerCapacity;
            IsActive = isActive;
        }
    }
}

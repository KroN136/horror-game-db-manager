﻿namespace HorrorGameDBManager.Models
{
    internal class Server
    {
        public string IpAddress { get; }
        public ushort PlayerCapacity { get; set; }
        public bool IsActive { get; set; }

        public Server(string ipAddress, ushort playerCapacity, bool isActive)
        {
            IpAddress = ipAddress;
            PlayerCapacity = playerCapacity;
            IsActive = isActive;
        }
    }
}

namespace HorrorGameDBManager
{
    internal static class IdReader
    {
        public static byte ReadAbilityId(string message)
        {
            byte id = 0;
            while (!Database.Abilities.Exists(id))
            {
                id = ValueReader.ReadByte(message);
                if (!Database.Abilities.Exists(id))
                    Console.WriteLine($"Способность {id} не существует.");
            }
            return id;
        }

        public static byte ReadArtifactId(string message)
        {
            byte id = 0;
            while (!Database.Artifacts.Exists(id))
            {
                id = ValueReader.ReadByte(message);
                if (!Database.Artifacts.Exists(id))
                    Console.WriteLine($"Артефакт {id} не существует.");
            }
            return id;
        }

        public static byte? ReadNullableEntityId(string message)
        {
            byte? id = 0;
            while (id.HasValue && !Database.Artifacts.Exists(id))
            {
                id = ValueReader.ReadNullableByte(message);
                if (id.HasValue && !Database.Artifacts.Exists(id))
                    Console.WriteLine($"Артефакт {id} не существует.");
            }
            return id;
        }

        public static byte ReadExperienceLevelId(string message)
        {
            byte id = 0;
            while (!Database.ExperienceLevels.Exists(id))
            {
                id = ValueReader.ReadByte(message);
                if (!Database.ExperienceLevels.Exists(id))
                    Console.WriteLine($"Уровень опыта {id} не существует.");
            }
            return id;
        }

        public static byte ReadGameModeId(string message)
        {
            byte id = 0;
            while (!Database.GameModes.Exists(id))
            {
                id = ValueReader.ReadByte(message);
                if (!Database.GameModes.Exists(id))
                    Console.WriteLine($"Режим игры {id} не существует.");
            }
            return id;
        }

        public static ulong ReadGameSessionId(string message)
        {
            ulong id = 0;
            while (!Database.GameSessions.Exists(id))
            {
                id = ValueReader.ReadULong(message);
                if (!Database.GameSessions.Exists(id))
                    Console.WriteLine($"Игровая сессия {id} не существует.");
            }
            return id;
        }

        public static string ReadPlayerId(string message)
        {
            string id = "";
            while (!Database.Players.Exists(id))
            {
                id = ValueReader.ReadString(message);
                if (!Database.Players.Exists(id))
                    Console.WriteLine($"Игрок {id} не существует.");
            }
            return id;
        }

        public static ulong ReadPlayerSessionId(string message)
        {
            ulong id = 0;
            while (!Database.PlayerSessions.Exists(id))
            {
                id = ValueReader.ReadULong(message);
                if (!Database.PlayerSessions.Exists(id))
                    Console.WriteLine($"Сессия игрока {id} не существует.");
            }
            return id;
        }

        public static byte ReadRarityLevelId(string message)
        {
            byte id = 0;
            while (!Database.RarityLevels.Exists(id))
            {
                id = ValueReader.ReadByte(message);
                if (!Database.RarityLevels.Exists(id))
                    Console.WriteLine($"Уровень редкости {id} не существует.");
            }
            return id;
        }

        public static ushort? ReadNullableServerId(string message)
        {
            ushort? id = 0;
            while (id.HasValue && !Database.Servers.Exists(id))
            {
                id = ValueReader.ReadNullableUShort(message);
                if (id.HasValue && !Database.Servers.Exists(id))
                    Console.WriteLine($"Сервер {id} не существует.");
            }
            return id;
        }
    }
}

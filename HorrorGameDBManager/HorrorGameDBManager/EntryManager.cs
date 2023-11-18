using HorrorGameDBManager.Models;

namespace HorrorGameDBManager
{
    internal static class EntryManager
    {
        private const string ADD_SUCCESS = "Запись успешно добавлена.";
        private const string EDIT_SUCCESS = "Запись успешно отредактирована.";
        private const string REMOVE_SUCCESS = "Запись успешно удалена.";

        #region User Input Handling

        private static byte ReadByte(string message, string errorMessage = $"Введите целое число в диапазоне от 0 до 255.")
        {
            byte output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !byte.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        private static byte? ReadNullableByte(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 255 (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            byte parseOutput = 0;

            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !byte.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }

        private static ushort ReadUShort(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 65 535.")
        {
            ushort output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !ushort.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        private static ushort? ReadNullableUShort(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 65 535 (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            ushort parseOutput = 0;

            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !ushort.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }

        private static uint ReadUInt(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 4 294 967 295.")
        {
            uint output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !uint.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        private static ulong ReadULong(string message, string errorMessage = "Введите целое число в диапазоне от 0 до 18 446 744 073 709 551 615.")
        {
            ulong output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !ulong.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        private static string ReadString(string message, string errorMessage = "Введите непустую строку.")
        {
            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || input.ToLower().Equals("null"))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input;
        }

        private static bool ReadBool(string message, string errorMessage = "Возможные формы ответа: true, yes, y, false, no, n, истина, да, д, ложь, нет, н.")
        {
            string[] trueOptions = new string[] { "true", "yes", "y", "истина", "да", "д" };
            string[] falseOptions = new string[] { "false", "no", "n", "ложь", "нет", "н" };

            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!trueOptions.Contains(input) && !falseOptions.Contains(input)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return trueOptions.Contains(input);
        }

        private static bool? ReadNullableBool(string message, string errorMessage = "Возможные формы ответа: true, yes, y, false, no, n, истина, да, д, ложь, нет, н (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            string[] trueOptions = new string[] { "true", "yes", "y", "истина", "да", "д" };
            string[] falseOptions = new string[] { "false", "no", "n", "ложь", "нет", "н" };

            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !trueOptions.Contains(input) && !falseOptions.Contains(input)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : trueOptions.Contains(input);
        }

        private static DateTime ReadDateTime(string message, string errorMessage = "Введите значение типа DateTime.")
        {
            DateTime output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !DateTime.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        private static DateTime? ReadNullableDateTime(string message, string errorMessage = "Введите значение типа DateTime (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            DateTime parseOutput = new(0);

            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !DateTime.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }

        private static float ReadFloat(string message, string errorMessage = "Введите значение типа float.")
        {
            float output;
            while (true)
            {
                Console.Write($"{message} ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || !float.TryParse(input, out output))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return output;
        }

        private static float? ReadNullableFloat(string message, string errorMessage = "Введите значение типа float (для присвоения NULL введите слово NULL заглавными буквами).")
        {
            float parseOutput = float.NaN;

            string input;
            while (true)
            {
                Console.Write($"{message} ");
                input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input) || (!input.Equals("NULL") && !float.TryParse(input, out parseOutput)))
                    Console.WriteLine(errorMessage);
                else
                    break;
            }
            return input.Equals("NULL") ? null : parseOutput;
        }

        #endregion

        #region Reading Valid IDs

        private static byte ReadAbilityId(string message)
        {
            byte id = 0;
            while (!Database.Abilities.Exists(id))
            {
                id = ReadByte(message);
                if (!Database.Abilities.Exists(id))
                    Console.WriteLine($"Способность {id} не существует.");
            }
            return id;
        }

        private static byte ReadArtifactId(string message)
        {
            byte id = 0;
            while (!Database.Artifacts.Exists(id))
            {
                id = ReadByte(message);
                if (!Database.Artifacts.Exists(id))
                    Console.WriteLine($"Артефакт {id} не существует.");
            }
            return id;
        }

        private static byte? ReadNullableEntityId(string message)
        {
            byte? id = 0;
            while (id.HasValue && !Database.Artifacts.Exists(id))
            {
                id = ReadNullableByte(message);
                if (id.HasValue && !Database.Artifacts.Exists(id))
                    Console.WriteLine($"Артефакт {id} не существует.");
            }
            return id;
        }

        private static byte ReadExperienceLevelId(string message)
        {
            byte id = 0;
            while (!Database.ExperienceLevels.Exists(id))
            {
                id = ReadByte(message);
                if (!Database.ExperienceLevels.Exists(id))
                    Console.WriteLine($"Уровень опыта {id} не существует.");
            }
            return id;
        }

        private static byte? ReadNullableGameModeId(string message)
        {
            byte? id = 0;
            while (id.HasValue && !Database.GameModes.Exists(id))
            {
                id = ReadNullableByte(message);
                if (id.HasValue && !Database.GameModes.Exists(id))
                    Console.WriteLine($"Режим игры {id} не существует.");
            }
            return id;
        }

        private static ulong ReadNullableGameSessionId(string message)
        {
            ulong id = 0;
            while (!Database.GameSessions.Exists(id))
            {
                id = ReadULong(message);
                if (!Database.GameSessions.Exists(id))
                    Console.WriteLine($"Игровая сессия {id} не существует.");
            }
            return id;
        }

        private static string ReadPlayerId(string message)
        {
            string id = "";
            while (!Database.Players.Exists(id))
            {
                id = ReadString(message);
                if (!Database.Players.Exists(id))
                    Console.WriteLine($"Игрок {id} не существует.");
            }
            return id;
        }

        private static ulong ReadNullablePlayerSessionId(string message)
        {
            ulong id = 0;
            while (!Database.PlayerSessions.Exists(id))
            {
                id = ReadULong(message);
                if (!Database.PlayerSessions.Exists(id))
                    Console.WriteLine($"Сессия игрока {id} не существует.");
            }
            return id;
        }

        private static byte ReadRarityLevelId(string message)
        {
            byte id = 0;
            while (!Database.RarityLevels.Exists(id))
            {
                id = ReadByte(message);
                if (!Database.RarityLevels.Exists(id))
                    Console.WriteLine($"Уровень редкости {id} не существует.");
            }
            return id;
        }

        private static ushort? ReadNullableServerId(string message)
        {
            ushort? id = 0;
            while (id.HasValue && !Database.Servers.Exists(id))
            {
                id = ReadNullableUShort(message);
                if (id.HasValue && !Database.Servers.Exists(id))
                    Console.WriteLine($"Сервер {id} не существует.");
            }
            return id;
        }

        #endregion

        #region Entry Adders

        public static void AddAbility()
        {
            bool activatedAbility = ReadBool("Активируемая способность?");
            string assetName = ReadString("Название ассета:");
            if (activatedAbility)
            {
                float duration = ReadFloat("Длительность:");
                float cooldown = ReadFloat("Кулдаун:");

                Database.Abilities.Add(new ActivatedAbility(assetName, duration, cooldown));
            }
            else
            {
                Database.Abilities.Add(new Ability(assetName));
            }

            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddAcquiredAbility()
        {
            if (Database.Players.GetAll().Count == 0)
                throw new Exception("Невозможно создать приобретённую способность, пока в базе данных нет игроков.");
            if (Database.Abilities.GetAll().Count == 0)
                throw new Exception("Невозможно создать приобретённую способность, пока в базе данных нет способностей.");

            string playerId = ReadPlayerId("ID игрока:");
            byte abilityId = ReadAbilityId("ID способности:");

            Database.AcquiredAbilities.Add(new AcquiredAbility(playerId, abilityId));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddArtifact()
        {
            if (Database.RarityLevels.GetAll().Count == 0)
                throw new Exception("Невозможно создать артефакт, пока в базе данных нет уровней редкости.");

            string assetName = ReadString("Название ассета:");
            byte rarityLevelId = ReadRarityLevelId("ID уровня редкости:");

            Database.Artifacts.Add(new Artifact(assetName, rarityLevelId));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddCollectedArtifact()
        {
            if (Database.Players.GetAll().Count == 0)
                throw new Exception("Невозможно создать подобранный артефакт, пока в базе данных нет игроков.");
            if (Database.Artifacts.GetAll().Count == 0)
                throw new Exception("Невозможно создать подобранный артефакт, пока в базе данных нет артефактов.");
            if (Database.PlayerSessions.GetAll().Count == 0)
                throw new Exception("Невозможно создать подобранный артефакт, пока в базе данных нет сессий игроков.");

            string playerId = ReadPlayerId("ID игрока:");
            byte artifactId = ReadArtifactId("ID артефакта:");
            ulong? playerSessionId = ReadNullablePlayerSessionId("ID сессии игрока:");

            Database.CollectedArtifacts.Add(new CollectedArtifact(playerId, artifactId, playerSessionId));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddEntity()
        {
            if (Database.ExperienceLevels.GetAll().Count == 0)
                throw new Exception("Невозможно создать сущность, пока в базе данных нет уровней опыта.");

            string assetName = ReadString("Название ассета:");
            float health = ReadFloat("Здоровье:");
            float movementSpeed = ReadFloat("Скорость передвижения:");
            byte requiredExperienceLevelId = ReadExperienceLevelId("ID требуемого уровня опыта:");

            Database.Entities.Add(new Entity(assetName, health, movementSpeed, requiredExperienceLevelId));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddExperienceLevel()
        {
            byte number = ReadByte("Номер:");
            ushort requiredExperiencePoints = ReadUShort("Требуемый опыт:");

            Database.ExperienceLevels.Add(new ExperienceLevel(number, requiredExperiencePoints));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddGameMode()
        {
            string assetName = ReadString("Название ассета:");
            byte playerCount = ReadByte("Количество игроков:");
            float? timeLimit = ReadNullableFloat("Лимит времени (в секундах):");

            Database.GameModes.Add(new GameMode(assetName, playerCount, timeLimit));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddGameSession()
        {
            if (Database.Servers.GetAll().Count == 0)
                throw new Exception("Невозможно создать игровую сессию, пока в базе данных нет серверов.");
            if (Database.GameModes.GetAll().Count == 0)
                throw new Exception("Невозможно создать игровую сессию, пока в базе данных нет игровых режимов.");

            ushort? serverId = ReadNullableServerId("ID сервера:");
            byte? gameModeId = ReadNullableGameModeId("ID игрового режима:");

            Database.GameSessions.Add(new GameSession(serverId, gameModeId));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddPlayer()
        {
            string username = ReadString("Никнейм:");
            string email = ReadString("Email:");
            string password = ReadString("Пароль:");
            bool enableDataCollection = ReadBool("Сбор данных:");

            Database.Players.Add(new Player(username, email, password, enableDataCollection));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddPlayerSession()
        {
            if (Database.GameSessions.GetAll().Count == 0)
                throw new Exception("Невозможно создать сессию игрока, пока в базе данных нет игровых сессий.");
            if (Database.Players.GetAll().Count == 0)
                throw new Exception("Невозможно создать сессию игрока, пока в базе данных нет игроков.");

            ulong? gameSessionId = ReadNullableGameSessionId("ID игровой сессии:");
            string playerId = ReadPlayerId("ID игрока:");

            Database.PlayerSessions.Add(new PlayerSession(gameSessionId, playerId));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddRarityLevel()
        {
            string assetName = ReadString("Название ассета:");
            float probability = ReadFloat("Вероятность:");

            Database.RarityLevels.Add(new RarityLevel(assetName, probability));
            Console.WriteLine(ADD_SUCCESS);
        }

        public static void AddServer()
        {
            string ipAddress = ReadString("IP-адрес:");
            ushort playerCapacity = ReadUShort("Вместимость:");
            bool isActive = ReadBool("Активен:");

            Database.Servers.Add(new Server(ipAddress, playerCapacity, isActive));
            Console.WriteLine(ADD_SUCCESS);
        }

        #endregion

        #region Entry Editors

        public static void EditAbility(byte id)
        {
            var ability = Database.Abilities.Get(id);

            ability.AssetName = ReadString($"Название ассета: {ability.AssetName} ->");
            if (ability is ActivatedAbility activatedAbility)
            {
                activatedAbility.Duration = ReadFloat($"Длительность: {activatedAbility.Duration} ->");
                activatedAbility.Cooldown = ReadFloat($"Кулдаун: {activatedAbility.Cooldown} ->");

                Database.Abilities.Edit(id, activatedAbility);
            }
            else
            {
                Database.Abilities.Edit(id, ability);
            }

            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditArtifact(byte id)
        {
            var artifact = Database.Artifacts.Get(id);

            artifact.AssetName = ReadString($"Название ассета: {artifact.AssetName} ->");
            artifact.RarityLevelId = ReadRarityLevelId($"ID уровня редкости: {artifact.RarityLevelId} ->");

            Database.Artifacts.Edit(id, artifact);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditCollectedArtifact(ulong id)
        {
            var collectedArtifact = Database.CollectedArtifacts.Get(id);

            collectedArtifact.PlayerSessionId = ReadNullablePlayerSessionId("ID сессии игрока:");

            Database.CollectedArtifacts.Edit(id, collectedArtifact);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditEntity(byte id)
        {
            var entity = Database.Entities.Get(id);

            entity.AssetName = ReadString($"Название ассета: {entity.AssetName} ->");
            entity.Health = ReadFloat($"Здоровье: {entity.Health} ->");
            entity.MovementSpeed = ReadFloat($"Скорость передвижения: {entity.MovementSpeed} ->");
            entity.RequiredExperienceLevelId = ReadExperienceLevelId($"ID требуемого уровня опыта: {entity.RequiredExperienceLevelId} ->");

            Database.Entities.Edit(id, entity);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditExperienceLevel(byte id)
        {
            var experienceLevel = Database.ExperienceLevels.Get(id);

            experienceLevel.RequiredExperiencePoints = ReadUShort($"Требуемый опыт: {experienceLevel.RequiredExperiencePoints} ->");

            Database.ExperienceLevels.Edit(id, experienceLevel);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditGameMode(byte id)
        {
            var gameMode = Database.GameModes.Get(id);

            gameMode.AssetName = ReadString($"Название ассета: {gameMode.AssetName} ->");
            gameMode.PlayerCount = ReadByte($"Количество игроков: {gameMode.PlayerCount} ->");
            gameMode.TimeLimit = ReadNullableFloat($"Лимит времени (в секундах): {gameMode.TimeLimit} ->");

            Database.GameModes.Edit(id, gameMode);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditGameSession(ulong id)
        {
            var gameSession = Database.GameSessions.Get(id);

            gameSession.ServerId = ReadNullableServerId($"ID сервера: {gameSession.ServerId} ->");
            gameSession.GameModeId = ReadNullableGameModeId($"ID игрового режима: {gameSession.GameModeId} ->");
            gameSession.EndDateTime = ReadNullableDateTime($"Дата и время окончания: {gameSession.EndDateTime} ->");

            Database.GameSessions.Edit(id, gameSession);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditPlayer(string id)
        {
            var player = Database.Players.Get(id);

            player.Username = ReadString($"Никнейм: {player.Username} ->");
            player.Email = ReadString($"Email: {player.Email} ->");
            player.Password = ReadString($"Пароль: {player.Password} ->");
            player.ExperienceLevelId = ReadExperienceLevelId($"ID уровня опыта: {player.ExperienceLevelId} ->");
            player.ExperiencePoints = ReadUShort($"Опыт: {player.ExperiencePoints} ->");
            player.AbilityPoints = ReadByte($"Очки способностей: {player.AbilityPoints} ->");
            player.IsOnline = ReadBool($"В сети: {player.IsOnline} ->");
            player.EnableDataCollection = ReadBool($"Сбор данных: {player.EnableDataCollection} ->");

            Database.Players.Edit(id, player);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditPlayerSession(ulong id)
        {
            var playerSession = Database.PlayerSessions.Get(id);

            playerSession.GameSessionId = ReadNullableGameSessionId($"ID игровой сессии: {playerSession.GameSessionId} ->");
            
            if (playerSession.Player.EnableDataCollection)
            {
                playerSession.IsFinished = ReadNullableBool($"Завершена: {playerSession.IsFinished} ->");
                playerSession.IsWon = ReadNullableBool($"Выиграна: {playerSession.IsWon} ->");
                playerSession.TimeAlive = ReadNullableFloat($"Время жизни (в секундах): {playerSession.TimeAlive} ->");
                playerSession.PlayedAsEntity = ReadNullableBool($"Использована сущность: {playerSession.PlayedAsEntity} ->");
                playerSession.UsedEntityId = ReadNullableEntityId($"ID использованной сущности: {playerSession.UsedEntityId} ->");
            }

            Database.PlayerSessions.Edit(id, playerSession);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditRarityLevel(byte id)
        {
            var rarityLevel = Database.RarityLevels.Get(id);

            rarityLevel.AssetName = ReadString($"Название ассета: {rarityLevel.AssetName} ->");
            rarityLevel.Probability = ReadFloat($"Вероятность: {rarityLevel.Probability} ->");

            Database.RarityLevels.Edit(id, rarityLevel);
            Console.WriteLine(EDIT_SUCCESS);
        }

        public static void EditServer(ushort id)
        {
            var server = Database.Servers.Get(id);

            server.IpAddress = ReadString($"IP-адрес: {server.IpAddress} ->");
            server.PlayerCapacity = ReadUShort($"Вместимость: {server.PlayerCapacity} ->");
            server.IsActive = ReadBool($"Активен: {server.IsActive} ->");
            server.PlayerCount = ReadUShort($"Количество игроков: {server.PlayerCount} ->");

            Database.Servers.Edit(id, server);
            Console.WriteLine(EDIT_SUCCESS);
        }

        #endregion

        #region Entry Removers

        private static bool ConfirmRemoval() => ReadBool("Данное действие невозможно отменить. Удалить указанную запись? ");

        public static void RemoveAbility(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var ability = Database.Abilities.Get(id);

            foreach (var acquiredAbility in ability.AcquiredAbilities)
                RemoveAcquiredAbility((ulong) acquiredAbility.Id, true);

            Database.Abilities.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveAcquiredAbility(ulong id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var acquiredAbility = Database.AcquiredAbilities.Get(id);

            var player = acquiredAbility.Player;
            player.AbilityPoints++;
            Database.Players.Edit(player.Id, player);

            Database.AcquiredAbilities.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveArtifact(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var artifact = Database.Artifacts.Get(id);

            foreach (var collectedArtifact in artifact.CollectedArtifacts)
                RemoveCollectedArtifact((ulong) collectedArtifact.Id, true);

            Database.Artifacts.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveCollectedArtifact(ulong id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            Database.CollectedArtifacts.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveEntity(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var entity = Database.Entities.Get(id);

            foreach (var playerSession in entity.PlayerSessions)
            {
                playerSession.UsedEntityId = null;
                Database.PlayerSessions.Edit(playerSession.Id, playerSession);
            }

            Database.Entities.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveExperienceLevel(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var experienceLevel = Database.ExperienceLevels.Get(id);

            var experienceLevelIds = Database.ExperienceLevels.GetAll().Select(experienceLevel => experienceLevel.Id).ToList();
            int index = experienceLevelIds.IndexOf(id);
            byte nextId = (byte) Database.ExperienceLevels.GetAll().ElementAt(index + 1).Id;
            byte previousId = (byte) Database.ExperienceLevels.GetAll().ElementAt(index - 1).Id;

            foreach (var entity in experienceLevel.RequiringEntities)
            {
                entity.RequiredExperienceLevelId = nextId;
                Database.Entities.Edit(entity.Id, entity);
            }

            foreach (var player in experienceLevel.Players)
            {
                player.ExperienceLevelId = previousId;
                Database.Players.Edit(player.Id, player);
            }

            Database.ExperienceLevels.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveGameMode(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var gameMode = Database.GameModes.Get(id);

            foreach (var gameSession in gameMode.GameSessions)
            {
                gameSession.GameModeId = null;
                Database.GameSessions.Edit(gameSession.Id, gameSession);
            }

            Database.GameModes.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveGameSession(ulong id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var gameSession = Database.GameSessions.Get(id);

            foreach (var playerSession in gameSession.PlayerSessions)
            {
                playerSession.GameSessionId = null;
                Database.PlayerSessions.Edit(playerSession.Id, playerSession);
            }

            Database.GameSessions.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemovePlayer(string id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var player = Database.Players.Get(id);

            foreach (var acquiredAbility in player.AcquiredAbilities)
                RemoveAcquiredAbility((ulong) acquiredAbility.Id, true);

            foreach (var collectedArtifact in player.CollectedArtifacts)
                RemoveCollectedArtifact((ulong) collectedArtifact.Id, true);

            foreach (var playerSession in player.PlayerSessions)
                RemovePlayerSession((ulong) playerSession.Id, true);

            Database.Players.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemovePlayerSession(ulong id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var playerSession = Database.PlayerSessions.Get(id);

            foreach (var collectedArtifact in playerSession.CollectedArtifacts)
            {
                collectedArtifact.PlayerSessionId = null;
                Database.CollectedArtifacts.Edit(collectedArtifact.Id, collectedArtifact);
            }

            Database.PlayerSessions.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveRarityLevel(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var rarityLevel = Database.RarityLevels.Get(id);

            var rarityLevelIds = Database.RarityLevels.GetAll().Select(rarityLevel => rarityLevel.Id).ToList();
            int index = rarityLevelIds.IndexOf(id);
            byte nextId = (byte) Database.RarityLevels.GetAll().ElementAt(index + 1).Id;

            foreach (var artifact in rarityLevel.Artifacts)
            {
                artifact.RarityLevelId = nextId;
                Database.Artifacts.Edit(artifact.Id, artifact);
            }

            Database.RarityLevels.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        public static void RemoveServer(ushort id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            var server = Database.Servers.Get(id);

            foreach (var gameSession in server.GameSessions)
            {
                gameSession.ServerId = null;
                Database.GameSessions.Edit(gameSession.Id, gameSession);
            }    

            Database.Servers.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
        }

        #endregion
    }
}

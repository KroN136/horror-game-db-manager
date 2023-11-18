using HorrorGameDBManager.Models;
using System.Data;

namespace HorrorGameDBManager
{
    internal static class EntryManager
    {
        private const string ADD_SUCCESS = "Запись успешно добавлена.";
        private const string EDIT_SUCCESS = "Запись успешно отредактирована.";
        private const string REMOVE_SUCCESS = "Запись успешно удалена.";

        #region Entry Adders

        public static void AddAbility()
        {
            bool activatedAbility = InputManager.ReadBool("Активируемая способность?");
            string assetName = InputManager.ReadString("Название ассета:");
            if (activatedAbility)
            {
                float duration = InputManager.ReadFloat("Длительность:");
                float cooldown = InputManager.ReadFloat("Кулдаун:");

                Database.Abilities.Add(new ActivatedAbility(assetName, duration, cooldown));
            }
            else
            {
                Database.Abilities.Add(new Ability(assetName));
            }

            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddAcquiredAbility()
        {
            if (!Database.Players.Entries.Any())
                throw new ConstraintException("Невозможно создать приобретённую способность, пока в базе данных нет игроков.");
            if (!Database.Abilities.Entries.Any())
                throw new ConstraintException("Невозможно создать приобретённую способность, пока в базе данных нет способностей.");

            string playerId = InputManager.ReadPlayerId("ID игрока:");
            byte abilityId = InputManager.ReadAbilityId("ID способности:");

            Database.AcquiredAbilities.Add(new AcquiredAbility(playerId, abilityId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddArtifact()
        {
            if (!Database.RarityLevels.Entries.Any())
                throw new ConstraintException("Невозможно создать артефакт, пока в базе данных нет уровней редкости.");

            string assetName = InputManager.ReadString("Название ассета:");
            byte rarityLevelId = InputManager.ReadRarityLevelId("ID уровня редкости:");

            Database.Artifacts.Add(new Artifact(assetName, rarityLevelId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddCollectedArtifact()
        {
            if (!Database.Players.Entries.Any())
                throw new ConstraintException("Невозможно создать подобранный артефакт, пока в базе данных нет игроков.");
            if (!Database.Artifacts.Entries.Any())
                throw new ConstraintException("Невозможно создать подобранный артефакт, пока в базе данных нет артефактов.");
            if (!Database.PlayerSessions.Entries.Any())
                throw new ConstraintException("Невозможно создать подобранный артефакт, пока в базе данных нет сессий игроков.");

            string playerId = InputManager.ReadPlayerId("ID игрока:");
            byte artifactId = InputManager.ReadArtifactId("ID артефакта:");
            ulong? playerSessionId = InputManager.ReadNullablePlayerSessionId("ID сессии игрока:");

            Database.CollectedArtifacts.Add(new CollectedArtifact(playerId, artifactId, playerSessionId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddEntity()
        {
            if (!Database.ExperienceLevels.Entries.Any())
                throw new ConstraintException("Невозможно создать сущность, пока в базе данных нет уровней опыта.");

            string assetName = InputManager.ReadString("Название ассета:");
            float health = InputManager.ReadFloat("Здоровье:");
            float movementSpeed = InputManager.ReadFloat("Скорость передвижения:");
            byte requiredExperienceLevelId = InputManager.ReadExperienceLevelId("ID требуемого уровня опыта:");

            Database.Entities.Add(new Entity(assetName, health, movementSpeed, requiredExperienceLevelId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddExperienceLevel()
        {
            byte number = InputManager.ReadByte("Номер:");
            ushort requiredExperiencePoints = InputManager.ReadUShort("Требуемый опыт:");

            Database.ExperienceLevels.Add(new ExperienceLevel(number, requiredExperiencePoints));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddGameMode()
        {
            string assetName = InputManager.ReadString("Название ассета:");
            byte playerCount = InputManager.ReadByte("Количество игроков:");
            float? timeLimit = InputManager.ReadNullableFloat("Лимит времени (в секундах):");

            Database.GameModes.Add(new GameMode(assetName, playerCount, timeLimit));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddGameSession()
        {
            if (!Database.Servers.Entries.Any())
                throw new ConstraintException("Невозможно создать игровую сессию, пока в базе данных нет серверов.");
            if (!Database.GameModes.Entries.Any())
                throw new ConstraintException("Невозможно создать игровую сессию, пока в базе данных нет игровых режимов.");

            ushort? serverId = InputManager.ReadNullableServerId("ID сервера:");
            byte? gameModeId = InputManager.ReadNullableGameModeId("ID игрового режима:");

            Database.GameSessions.Add(new GameSession(serverId, gameModeId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddPlayer()
        {
            if (!Database.ExperienceLevels.Entries.Any())
                throw new ConstraintException("Невозможно создать игрока, пока в базе данных нет уровней опыта.");

            string username = InputManager.ReadString("Никнейм:");
            string email = InputManager.ReadString("Email:");
            string password = InputManager.ReadString("Пароль:");
            bool enableDataCollection = InputManager.ReadBool("Сбор данных:");

            Database.Players.Add(new Player(username, email, password, enableDataCollection));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddPlayerSession()
        {
            if (!Database.GameSessions.Entries.Any())
                throw new ConstraintException("Невозможно создать сессию игрока, пока в базе данных нет игровых сессий.");
            if (!Database.Players.Entries.Any())
                throw new ConstraintException("Невозможно создать сессию игрока, пока в базе данных нет игроков.");

            ulong? gameSessionId = InputManager.ReadNullableGameSessionId("ID игровой сессии:");
            string playerId = InputManager.ReadPlayerId("ID игрока:");

            Database.PlayerSessions.Add(new PlayerSession(gameSessionId, playerId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddRarityLevel()
        {
            string assetName = InputManager.ReadString("Название ассета:");
            float probability = InputManager.ReadFloat("Вероятность:");

            Database.RarityLevels.Add(new RarityLevel(assetName, probability));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddServer()
        {
            string ipAddress = InputManager.ReadString("IP-адрес:");
            ushort playerCapacity = InputManager.ReadUShort("Вместимость:");
            bool isActive = InputManager.ReadBool("Активен:");

            Database.Servers.Add(new Server(ipAddress, playerCapacity, isActive));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        #endregion

        #region Entry Editors

        public static void EditAbility(byte id)
        {
            var ability = Database.Abilities.Get(id);

            ability.AssetName = InputManager.ReadString($"Название ассета: {ability.AssetName} ->");
            if (ability is ActivatedAbility activatedAbility)
            {
                activatedAbility.Duration = InputManager.ReadFloat($"Длительность: {activatedAbility.Duration} ->");
                activatedAbility.Cooldown = InputManager.ReadFloat($"Кулдаун: {activatedAbility.Cooldown} ->");

                Database.Abilities.Edit(id, activatedAbility);
            }
            else
            {
                Database.Abilities.Edit(id, ability);
            }

            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditArtifact(byte id)
        {
            var artifact = Database.Artifacts.Get(id);

            artifact.AssetName = InputManager.ReadString($"Название ассета: {artifact.AssetName} ->");
            artifact.RarityLevelId = InputManager.ReadRarityLevelId($"ID уровня редкости: {artifact.RarityLevelId} ->");

            Database.Artifacts.Edit(id, artifact);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditCollectedArtifact(ulong id)
        {
            var collectedArtifact = Database.CollectedArtifacts.Get(id);

            collectedArtifact.PlayerSessionId = InputManager.ReadNullablePlayerSessionId("ID сессии игрока:");

            Database.CollectedArtifacts.Edit(id, collectedArtifact);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditEntity(byte id)
        {
            var entity = Database.Entities.Get(id);

            entity.AssetName = InputManager.ReadString($"Название ассета: {entity.AssetName} ->");
            entity.Health = InputManager.ReadFloat($"Здоровье: {entity.Health} ->");
            entity.MovementSpeed = InputManager.ReadFloat($"Скорость передвижения: {entity.MovementSpeed} ->");
            entity.RequiredExperienceLevelId = InputManager.ReadExperienceLevelId($"ID требуемого уровня опыта: {entity.RequiredExperienceLevelId} ->");

            Database.Entities.Edit(id, entity);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditExperienceLevel(byte id)
        {
            var experienceLevel = Database.ExperienceLevels.Get(id);

            experienceLevel.RequiredExperiencePoints = InputManager.ReadUShort($"Требуемый опыт: {experienceLevel.RequiredExperiencePoints} ->");

            Database.ExperienceLevels.Edit(id, experienceLevel);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditGameMode(byte id)
        {
            var gameMode = Database.GameModes.Get(id);

            gameMode.AssetName = InputManager.ReadString($"Название ассета: {gameMode.AssetName} ->");
            gameMode.PlayerCount = InputManager.ReadByte($"Количество игроков: {gameMode.PlayerCount} ->");
            gameMode.TimeLimit = InputManager.ReadNullableFloat($"Лимит времени (в секундах): {gameMode.TimeLimit} ->");

            Database.GameModes.Edit(id, gameMode);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditGameSession(ulong id)
        {
            var gameSession = Database.GameSessions.Get(id);

            gameSession.ServerId = InputManager.ReadNullableServerId($"ID сервера: {gameSession.ServerId} ->");
            gameSession.GameModeId = InputManager.ReadNullableGameModeId($"ID игрового режима: {gameSession.GameModeId} ->");
            gameSession.EndDateTime = InputManager.ReadNullableDateTime($"Дата и время окончания: {gameSession.EndDateTime} ->");

            Database.GameSessions.Edit(id, gameSession);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditPlayer(string id)
        {
            var player = Database.Players.Get(id);

            player.Username = InputManager.ReadString($"Никнейм: {player.Username} ->");
            player.Email = InputManager.ReadString($"Email: {player.Email} ->");
            player.Password = InputManager.ReadString($"Пароль: {player.Password} ->");
            player.ExperienceLevelId = InputManager.ReadExperienceLevelId($"ID уровня опыта: {player.ExperienceLevelId} ->");
            player.ExperiencePoints = InputManager.ReadUShort($"Опыт: {player.ExperiencePoints} ->");
            player.AbilityPoints = InputManager.ReadByte($"Очки способностей: {player.AbilityPoints} ->");
            player.IsOnline = InputManager.ReadBool($"В сети: {player.IsOnline} ->");
            player.EnableDataCollection = InputManager.ReadBool($"Сбор данных: {player.EnableDataCollection} ->");

            Database.Players.Edit(id, player);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditPlayerSession(ulong id)
        {
            var playerSession = Database.PlayerSessions.Get(id);

            playerSession.GameSessionId = InputManager.ReadNullableGameSessionId($"ID игровой сессии: {playerSession.GameSessionId} ->");
            
            if (playerSession.Player.EnableDataCollection)
            {
                playerSession.IsFinished = InputManager.ReadNullableBool($"Завершена: {playerSession.IsFinished} ->");
                playerSession.IsWon = InputManager.ReadNullableBool($"Выиграна: {playerSession.IsWon} ->");
                playerSession.TimeAlive = InputManager.ReadNullableFloat($"Время жизни (в секундах): {playerSession.TimeAlive} ->");
                playerSession.PlayedAsEntity = InputManager.ReadNullableBool($"Использована сущность: {playerSession.PlayedAsEntity} ->");
                playerSession.UsedEntityId = InputManager.ReadNullableEntityId($"ID использованной сущности: {playerSession.UsedEntityId} ->");
            }

            Database.PlayerSessions.Edit(id, playerSession);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditRarityLevel(byte id)
        {
            var rarityLevel = Database.RarityLevels.Get(id);

            rarityLevel.AssetName = InputManager.ReadString($"Название ассета: {rarityLevel.AssetName} ->");
            rarityLevel.Probability = InputManager.ReadFloat($"Вероятность: {rarityLevel.Probability} ->");

            Database.RarityLevels.Edit(id, rarityLevel);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditServer(ushort id)
        {
            var server = Database.Servers.Get(id);

            server.IpAddress = InputManager.ReadString($"IP-адрес: {server.IpAddress} ->");
            server.PlayerCapacity = InputManager.ReadUShort($"Вместимость: {server.PlayerCapacity} ->");
            server.IsActive = InputManager.ReadBool($"Активен: {server.IsActive} ->");
            server.PlayerCount = InputManager.ReadUShort($"Количество игроков: {server.PlayerCount} ->");

            Database.Servers.Edit(id, server);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        #endregion

        #region Entry Removers

        private static bool ConfirmRemoval() => InputManager.ReadBool("Данное действие невозможно отменить. Удалить указанную запись? ");

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
            Database.Save();
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
            Database.Save();
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
            Database.Save();
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
            Database.Save();
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
            Database.Save();
        }

        public static void RemoveExperienceLevel(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            if (Database.ExperienceLevels.Entries.Count == 1 && (Database.Entities.Entries.Any() || Database.Players.Entries.Any()))
                throw new ConstraintException("Невозможно удалить единственный уровень опыта, так как к нему привязана одна или несколько сущностей и/или игроков.");

            var experienceLevel = Database.ExperienceLevels.Get(id);

            var experienceLevelIds = Database.ExperienceLevels.Entries.Select(experienceLevel => experienceLevel.Id).ToList();
            int index = experienceLevelIds.IndexOf(id);
            byte nextId = (byte) Database.ExperienceLevels.Entries.ElementAt(index + 1).Id;
            byte previousId = (byte) Database.ExperienceLevels.Entries.ElementAt(index - 1).Id;

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
            Database.Save();
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
            Database.Save();
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
            Database.Save();
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
            Database.Save();
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
            Database.Save();
        }

        public static void RemoveRarityLevel(byte id, bool force = false)
        {
            if (!force)
            {
                if (!ConfirmRemoval())
                    return;
            }

            if (Database.RarityLevels.Entries.Count == 1 && Database.Artifacts.Entries.Any())
                throw new ConstraintException("Невозможно удалить единственный уровень редкости, так как к нему привязан один или несколько артефактов.");

            var rarityLevel = Database.RarityLevels.Get(id);

            var rarityLevelIds = Database.RarityLevels.Entries.Select(rarityLevel => rarityLevel.Id).ToList();
            int index = rarityLevelIds.IndexOf(id);
            byte nextId = (byte) Database.RarityLevels.Entries.ElementAt(index + 1).Id;

            foreach (var artifact in rarityLevel.Artifacts)
            {
                artifact.RarityLevelId = nextId;
                Database.Artifacts.Edit(artifact.Id, artifact);
            }

            Database.RarityLevels.Remove(id);
            Console.WriteLine(REMOVE_SUCCESS);
            Database.Save();
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
            Database.Save();
        }

        #endregion
    }
}

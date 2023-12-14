using HorrorGameDBManager.Models;
using System.Data;

namespace HorrorGameDBManager
{
    internal class Program
    {
        private static bool loop = true;

        private const string HELP_COMMAND = "help";
        private const string TABLES_COMMAND = "tables";
        private const string VIEW_COMMAND = "view";
        private const string ADD_COMMAND = "add";
        private const string EDIT_COMMAND = "edit";
        private const string REMOVE_COMMAND = "remove";
        private const string EXIT_COMMAND = "exit";

        private const string EMPTY_COMMAND_MESSAGE = "Введена пустая команда.";
        private const string UNKNOWN_COMMAND_MESSAGE = "Команда не распознана.";
        private const string WRONG_ARGUMENT_COUNT_MESSAGE = "Введено неверное число аргументов.";

        private const string ADD_SUCCESS = "Запись успешно добавлена.";
        private const string EDIT_SUCCESS = "Запись успешно отредактирована.";
        private const string REMOVE_SUCCESS = "Запись успешно удалена.";

        #region Command Actions

        private static void Help()
        {
            Help(HELP_COMMAND);
            Help(TABLES_COMMAND);
            Help(VIEW_COMMAND);
            Help(ADD_COMMAND);
            Help(EDIT_COMMAND);
            Help(REMOVE_COMMAND);
            Help(EXIT_COMMAND);
        }

        private static void Help(string command)
        {
            switch (command)
            {
                case HELP_COMMAND:
                    Console.WriteLine("help [cmd] - просмотр справки по всем командам / просмотр справки по команде cmd");
                    break;
                case TABLES_COMMAND:
                    Console.WriteLine("tables - просмотр списка всех таблиц");
                    break;
                case VIEW_COMMAND:
                    Console.WriteLine("view * - просмотр всех записей во всех таблицах");
                    Console.WriteLine("view <table> [id] - просмотр всех записей в таблице table / просмотр записи с идентификатором id в таблице table");
                    break;
                case ADD_COMMAND:
                    Console.WriteLine("add <table> - добавление записи в таблицу table");
                    break;
                case EDIT_COMMAND:
                    Console.WriteLine("edit <table> <id> - редактирование записи с идентификатором id в таблице table");
                    break;
                case REMOVE_COMMAND:
                    Console.WriteLine("remove <table> <id> - удаление записи с идентификатором id в таблице table");
                    break;
                case EXIT_COMMAND:
                    Console.WriteLine("exit - выход");
                    break;
                default:
                    throw new ArgumentException($"Команда {command} не существует.");
            }
        }

        private static void Tables()
        {
            Console.WriteLine(Database.Abilities.Name);
            Console.WriteLine(Database.AcquiredAbilities.Name);
            Console.WriteLine(Database.Artifacts.Name);
            Console.WriteLine(Database.CollectedArtifacts.Name);
            Console.WriteLine(Database.Entities.Name);
            Console.WriteLine(Database.ExperienceLevels.Name);
            Console.WriteLine(Database.GameModes.Name);
            Console.WriteLine(Database.GameSessions.Name);
            Console.WriteLine(Database.Players.Name);
            Console.WriteLine(Database.PlayerSessions.Name);
            Console.WriteLine(Database.RarityLevels.Name);
            Console.WriteLine(Database.Servers.Name);
        }

        private static void View(string tableName)
        {
            if (tableName.Equals("*"))
            {
                TablePrinter.PrintAbilities(Database.Abilities.Entries);
                TablePrinter.PrintAcquiredAbilities(Database.AcquiredAbilities.Entries);
                TablePrinter.PrintArtifacts(Database.Artifacts.Entries);
                TablePrinter.PrintCollectedArtifacts(Database.CollectedArtifacts.Entries);
                TablePrinter.PrintEntities(Database.Entities.Entries);
                TablePrinter.PrintExperienceLevels(Database.ExperienceLevels.Entries);
                TablePrinter.PrintGameModes(Database.GameModes.Entries);
                TablePrinter.PrintGameSessions(Database.GameSessions.Entries);
                TablePrinter.PrintPlayers(Database.Players.Entries);
                TablePrinter.PrintPlayerSessions(Database.PlayerSessions.Entries);
                TablePrinter.PrintRarityLevels(Database.RarityLevels.Entries);
                TablePrinter.PrintServers(Database.Servers.Entries);
                return;
            }

            if (tableName.Equals(Database.Abilities.Name))
                TablePrinter.PrintAbilities(Database.Abilities.Entries);
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                TablePrinter.PrintAcquiredAbilities(Database.AcquiredAbilities.Entries);
            else if (tableName.Equals(Database.Artifacts.Name))
                TablePrinter.PrintArtifacts(Database.Artifacts.Entries);
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                TablePrinter.PrintCollectedArtifacts(Database.CollectedArtifacts.Entries);
            else if (tableName.Equals(Database.Entities.Name))
                TablePrinter.PrintEntities(Database.Entities.Entries);
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                TablePrinter.PrintExperienceLevels(Database.ExperienceLevels.Entries);
            else if (tableName.Equals(Database.GameModes.Name))
                TablePrinter.PrintGameModes(Database.GameModes.Entries);
            else if (tableName.Equals(Database.GameSessions.Name))
                TablePrinter.PrintGameSessions(Database.GameSessions.Entries);
            else if (tableName.Equals(Database.Players.Name))
                TablePrinter.PrintPlayers(Database.Players.Entries);
            else if (tableName.Equals(Database.PlayerSessions.Name))
                TablePrinter.PrintPlayerSessions(Database.PlayerSessions.Entries);
            else if (tableName.Equals(Database.RarityLevels.Name))
                TablePrinter.PrintRarityLevels(Database.RarityLevels.Entries);
            else if (tableName.Equals(Database.Servers.Name))
                TablePrinter.PrintServers(Database.Servers.Entries);
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void View(string tableName, string id)
        {
            if (tableName.Equals(Database.Abilities.Name))
                TablePrinter.PrintAbilities(new List<Ability>() { Database.Abilities.Get(byte.Parse(id)) });
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                TablePrinter.PrintAcquiredAbilities(new List<AcquiredAbility>() { Database.AcquiredAbilities.Get(ulong.Parse(id)) });
            else if (tableName.Equals(Database.Artifacts.Name))
                TablePrinter.PrintArtifacts(new List<Artifact>() { Database.Artifacts.Get(byte.Parse(id)) });
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                TablePrinter.PrintCollectedArtifacts(new List<CollectedArtifact>() { Database.CollectedArtifacts.Get(ulong.Parse(id)) });
            else if (tableName.Equals(Database.Entities.Name))
                TablePrinter.PrintEntities(new List<Entity>() { Database.Entities.Get(byte.Parse(id)) });
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                TablePrinter.PrintExperienceLevels(new List<ExperienceLevel>() { Database.ExperienceLevels.Get(byte.Parse(id)) });
            else if (tableName.Equals(Database.GameModes.Name))
                TablePrinter.PrintGameModes(new List<GameMode>() { Database.GameModes.Get(byte.Parse(id)) });
            else if (tableName.Equals(Database.GameSessions.Name))
                TablePrinter.PrintGameSessions(new List<GameSession>() { Database.GameSessions.Get(ulong.Parse(id)) });
            else if (tableName.Equals(Database.Players.Name))
                TablePrinter.PrintPlayers(new List<Player>() { Database.Players.Get(id) });
            else if (tableName.Equals(Database.PlayerSessions.Name))
                TablePrinter.PrintPlayerSessions(new List<PlayerSession>() { Database.PlayerSessions.Get(ulong.Parse(id)) });
            else if (tableName.Equals(Database.RarityLevels.Name))
                TablePrinter.PrintRarityLevels(new List<RarityLevel>() { Database.RarityLevels.Get(byte.Parse(id)) });
            else if (tableName.Equals(Database.Servers.Name))
                TablePrinter.PrintServers(new List<Server>() { Database.Servers.Get(ushort.Parse(id)) });
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void Add(string tableName)
        {
            if (tableName.Equals(Database.Abilities.Name))
                AddAbility();
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                AddAcquiredAbility();
            else if (tableName.Equals(Database.Artifacts.Name))
                AddArtifact();
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                AddCollectedArtifact();
            else if (tableName.Equals(Database.Entities.Name))
                AddEntity();
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                AddExperienceLevel();
            else if (tableName.Equals(Database.GameModes.Name))
                AddGameMode();
            else if (tableName.Equals(Database.GameSessions.Name))
                AddGameSession();
            else if (tableName.Equals(Database.Players.Name))
                AddPlayer();
            else if (tableName.Equals(Database.PlayerSessions.Name))
                AddPlayerSession();
            else if (tableName.Equals(Database.RarityLevels.Name))
                AddRarityLevel();
            else if (tableName.Equals(Database.Servers.Name))
                AddServer();
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void Edit(string tableName, string id)
        {
            if (tableName.Equals(Database.Abilities.Name))
                EditAbility(byte.Parse(id));
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                throw new ArgumentException($"Таблица {tableName} не подлежит редактированию.");
            else if (tableName.Equals(Database.Artifacts.Name))
                EditArtifact(byte.Parse(id));
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                throw new ArgumentException($"Таблица {tableName} не подлежит редактированию.");
            else if (tableName.Equals(Database.Entities.Name))
                EditEntity(byte.Parse(id));
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                EditExperienceLevel(byte.Parse(id));
            else if (tableName.Equals(Database.GameModes.Name))
                EditGameMode(byte.Parse(id));
            else if (tableName.Equals(Database.GameSessions.Name))
                EditGameSession(ulong.Parse(id));
            else if (tableName.Equals(Database.Players.Name))
                EditPlayer(id);
            else if (tableName.Equals(Database.PlayerSessions.Name))
                EditPlayerSession(ulong.Parse(id));
            else if (tableName.Equals(Database.RarityLevels.Name))
                EditRarityLevel(byte.Parse(id));
            else if (tableName.Equals(Database.Servers.Name))
                EditServer(ushort.Parse(id));
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void Remove(string tableName, string id)
        {
            if (tableName.Equals(Database.Abilities.Name))
                RemoveAbility(byte.Parse(id));
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                RemoveAcquiredAbility(ulong.Parse(id));
            else if (tableName.Equals(Database.Artifacts.Name))
                RemoveArtifact(byte.Parse(id));
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                RemoveCollectedArtifact(ulong.Parse(id));
            else if (tableName.Equals(Database.Entities.Name))
                RemoveEntity(byte.Parse(id));
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                RemoveExperienceLevel(byte.Parse(id));
            else if (tableName.Equals(Database.GameModes.Name))
                RemoveGameMode(byte.Parse(id));
            else if (tableName.Equals(Database.GameSessions.Name))
                RemoveGameSession(ulong.Parse(id));
            else if (tableName.Equals(Database.Players.Name))
                RemovePlayer(id);
            else if (tableName.Equals(Database.PlayerSessions.Name))
                RemovePlayerSession(ulong.Parse(id));
            else if (tableName.Equals(Database.RarityLevels.Name))
                RemoveRarityLevel(byte.Parse(id));
            else if (tableName.Equals(Database.Servers.Name))
                RemoveServer(ushort.Parse(id));
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void Exit() => loop = false;

        #endregion

        #region Database Entry Adders

        public static void AddAbility()
        {
            bool activatedAbility = ValueReader.ReadBool("Активируемая способность?");
            string assetName = ValueReader.ReadString("Название ассета:");
            if (activatedAbility)
            {
                float duration = ValueReader.ReadNonNegativeFloat("Длительность:");
                float cooldown = ValueReader.ReadNonNegativeFloat("Восстановление:");

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

            string playerId = IdReader.ReadPlayerId("ID игрока:");
            byte abilityId = IdReader.ReadAbilityId("ID способности:");

            Database.AcquiredAbilities.Add(new AcquiredAbility(playerId, abilityId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddArtifact()
        {
            if (!Database.RarityLevels.Entries.Any())
                throw new ConstraintException("Невозможно создать артефакт, пока в базе данных нет уровней редкости.");

            string assetName = ValueReader.ReadString("Название ассета:");
            byte rarityLevelId = IdReader.ReadRarityLevelId("ID уровня редкости:");

            Database.Artifacts.Add(new Artifact(assetName, rarityLevelId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddCollectedArtifact()
        {
            if (!Database.PlayerSessions.Entries.Any())
                throw new ConstraintException("Невозможно создать собранный артефакт, пока в базе данных нет сессий игроков.");
            if (!Database.Artifacts.Entries.Any())
                throw new ConstraintException("Невозможно создать собранный артефакт, пока в базе данных нет артефактов.");

            ulong playerSessionId = IdReader.ReadPlayerSessionId("ID сессии игрока:");
            byte artifactId = IdReader.ReadArtifactId("ID артефакта:");

            Database.CollectedArtifacts.Add(new CollectedArtifact(playerSessionId, artifactId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddEntity()
        {
            if (!Database.ExperienceLevels.Entries.Any())
                throw new ConstraintException("Невозможно создать сущность, пока в базе данных нет уровней опыта.");

            string assetName = ValueReader.ReadString("Название ассета:");
            float health = ValueReader.ReadNonNegativeFloat("Здоровье:");
            float movementSpeed = ValueReader.ReadNonNegativeFloat("Скорость передвижения:");
            byte requiredExperienceLevelId = IdReader.ReadExperienceLevelId("ID требуемого уровня опыта:");

            Database.Entities.Add(new Entity(assetName, health, movementSpeed, requiredExperienceLevelId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddExperienceLevel()
        {
            byte number = ValueReader.ReadByte("Номер:");
            ushort requiredExperiencePoints = ValueReader.ReadUShort("Требуемый опыт:");

            Database.ExperienceLevels.Add(new ExperienceLevel(number, requiredExperiencePoints));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddGameMode()
        {
            string assetName = ValueReader.ReadString("Название ассета:");
            bool isActive = ValueReader.ReadBool("Активен:");
            byte playerCount = ValueReader.ReadByte("Количество игроков:");
            float? timeLimit = ValueReader.ReadNonNegativeNullableFloat("Лимит времени (в секундах):");

            Database.GameModes.Add(new GameMode(assetName, isActive, playerCount, timeLimit));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddGameSession()
        {
            if (!Database.GameModes.Entries.Any())
                throw new ConstraintException("Невозможно создать игровую сессию, пока в базе данных нет игровых режимов.");

            ushort? serverId = IdReader.ReadNullableServerId("ID сервера:");

            if (serverId.HasValue && Database.Servers.Get(serverId.Value).IsActive == false)
                throw new ConstraintException("Невозможно создать игровую сессию: указанный сервер не активен.");

            byte gameModeId = IdReader.ReadGameModeId("ID игрового режима:");

            if (Database.GameModes.Get(gameModeId).IsActive == false)
                throw new ConstraintException("Невозможно создать игровую сессию: указанный игровой режим не активен.");

            Database.GameSessions.Add(new GameSession(serverId, gameModeId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddPlayer()
        {
            if (!Database.ExperienceLevels.Entries.Any())
                throw new ConstraintException("Невозможно создать игрока, пока в базе данных нет уровней опыта.");

            string username = ValueReader.ReadString("Никнейм:");
            string email = ValueReader.ReadString("Email:");
            string password = ValueReader.ReadString("Пароль:");
            bool enableDataCollection = ValueReader.ReadBool("Сбор данных:");

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

            ulong gameSessionId = IdReader.ReadGameSessionId("ID игровой сессии:");
            string playerId = IdReader.ReadPlayerId("ID игрока:");

            Database.PlayerSessions.Add(new PlayerSession(gameSessionId, playerId));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddRarityLevel()
        {
            string assetName = ValueReader.ReadString("Название ассета:");
            float probability = ValueReader.ReadNonNegativeFloat("Вероятность:");

            Database.RarityLevels.Add(new RarityLevel(assetName, probability));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        public static void AddServer()
        {
            string ipAddress = ValueReader.ReadString("IP-адрес:");
            ushort playerCapacity = ValueReader.ReadUShort("Вместимость:");
            bool isActive = ValueReader.ReadBool("Активен:");

            Database.Servers.Add(new Server(ipAddress, playerCapacity, isActive));
            Console.WriteLine(ADD_SUCCESS);
            Database.Save();
        }

        #endregion

        #region Database Entry Editors

        public static void EditAbility(byte id)
        {
            var ability = Database.Abilities.Get(id);

            ability.AssetName = ValueReader.ReadString($"Название ассета: {ability.AssetName} ->");
            if (ability is ActivatedAbility activatedAbility)
            {
                activatedAbility.Duration = ValueReader.ReadNonNegativeFloat($"Длительность: {activatedAbility.Duration} ->");
                activatedAbility.Cooldown = ValueReader.ReadNonNegativeFloat($"Восстановление: {activatedAbility.Cooldown} ->");

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

            artifact.AssetName = ValueReader.ReadString($"Название ассета: {artifact.AssetName} ->");
            artifact.RarityLevelId = IdReader.ReadRarityLevelId($"ID уровня редкости: {artifact.RarityLevelId} ->");

            Database.Artifacts.Edit(id, artifact);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditEntity(byte id)
        {
            var entity = Database.Entities.Get(id);

            entity.AssetName = ValueReader.ReadString($"Название ассета: {entity.AssetName} ->");
            entity.Health = ValueReader.ReadNonNegativeFloat($"Здоровье: {entity.Health} ->");
            entity.MovementSpeed = ValueReader.ReadNonNegativeFloat($"Скорость передвижения: {entity.MovementSpeed} ->");
            entity.RequiredExperienceLevelId = IdReader.ReadExperienceLevelId($"ID требуемого уровня опыта: {entity.RequiredExperienceLevelId} ->");

            Database.Entities.Edit(id, entity);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditExperienceLevel(byte id)
        {
            var experienceLevel = Database.ExperienceLevels.Get(id);

            experienceLevel.RequiredExperiencePoints = ValueReader.ReadUShort($"Требуемый опыт: {experienceLevel.RequiredExperiencePoints} ->");

            Database.ExperienceLevels.Edit(id, experienceLevel);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditGameMode(byte id)
        {
            var gameMode = Database.GameModes.Get(id);

            gameMode.AssetName = ValueReader.ReadString($"Название ассета: {gameMode.AssetName} ->");
            gameMode.IsActive = ValueReader.ReadBool($"Активен: {gameMode.IsActive} ->");
            gameMode.PlayerCount = ValueReader.ReadByte($"Количество игроков: {gameMode.PlayerCount} ->");
            gameMode.TimeLimit = ValueReader.ReadNonNegativeNullableFloat($"Лимит времени (в секундах): {gameMode.TimeLimit} ->");

            Database.GameModes.Edit(id, gameMode);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditGameSession(ulong id)
        {
            var gameSession = Database.GameSessions.Get(id);

            gameSession.ServerId = IdReader.ReadNullableServerId($"ID сервера: {gameSession.ServerId} ->");
            gameSession.GameModeId = IdReader.ReadGameModeId($"ID игрового режима: {gameSession.GameModeId} ->");
            gameSession.EndDateTime = ValueReader.ReadNullableDateTime($"Дата и время окончания: {gameSession.EndDateTime} ->");

            Database.GameSessions.Edit(id, gameSession);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditPlayer(string id)
        {
            var player = Database.Players.Get(id);

            player.Username = ValueReader.ReadString($"Никнейм: {player.Username} ->");
            player.Email = ValueReader.ReadString($"Email: {player.Email} ->");
            player.Password = ValueReader.ReadString($"Пароль: {player.Password} ->");
            player.ExperienceLevelId = IdReader.ReadExperienceLevelId($"ID уровня опыта: {player.ExperienceLevelId} ->");
            player.ExperiencePoints = ValueReader.ReadUShort($"Опыт: {player.ExperiencePoints} ->");
            player.AbilityPoints = ValueReader.ReadByte($"Очки способностей: {player.AbilityPoints} ->");
            player.IsOnline = ValueReader.ReadBool($"В сети: {player.IsOnline} ->");
            player.EnableDataCollection = ValueReader.ReadBool($"Сбор данных: {player.EnableDataCollection} ->");

            Database.Players.Edit(id, player);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditPlayerSession(ulong id)
        {
            var playerSession = Database.PlayerSessions.Get(id);

            if (playerSession.Player.EnableDataCollection == false)
                throw new ArgumentException($"Сессия игрока {id} не подлежит редактированию, так как у игрока {playerSession.PlayerId}, связанного с ней, отключён сбор данных.");

            playerSession.IsFinished = ValueReader.ReadNullableBool($"Завершена: {playerSession.IsFinished} ->");
            playerSession.IsWon = ValueReader.ReadNullableBool($"Выиграна: {playerSession.IsWon} ->");
            playerSession.TimeAlive = ValueReader.ReadNonNegativeNullableFloat($"Время жизни (в секундах): {playerSession.TimeAlive} ->");
            playerSession.PlayedAsEntity = ValueReader.ReadNullableBool($"Использована сущность: {playerSession.PlayedAsEntity} ->");
            playerSession.UsedEntityId = IdReader.ReadNullableEntityId($"ID использованной сущности: {playerSession.UsedEntityId} ->");

            Database.PlayerSessions.Edit(id, playerSession);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditRarityLevel(byte id)
        {
            var rarityLevel = Database.RarityLevels.Get(id);

            rarityLevel.AssetName = ValueReader.ReadString($"Название ассета: {rarityLevel.AssetName} ->");
            rarityLevel.Probability = ValueReader.ReadNonNegativeFloat($"Вероятность: {rarityLevel.Probability} ->");

            Database.RarityLevels.Edit(id, rarityLevel);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        public static void EditServer(ushort id)
        {
            var server = Database.Servers.Get(id);

            server.IpAddress = ValueReader.ReadString($"IP-адрес: {server.IpAddress} ->");
            server.PlayerCapacity = ValueReader.ReadUShort($"Вместимость: {server.PlayerCapacity} ->");
            server.IsActive = ValueReader.ReadBool($"Активен: {server.IsActive} ->");
            server.PlayerCount = ValueReader.ReadUShort($"Количество игроков: {server.PlayerCount} ->");

            Database.Servers.Edit(id, server);
            Console.WriteLine(EDIT_SUCCESS);
            Database.Save();
        }

        #endregion

        #region Database Entry Removers

        private static bool ConfirmRemoval() => ValueReader.ReadBool("Данное действие невозможно отменить. Удалить указанную запись? ");

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

            var experienceLevel = Database.ExperienceLevels.Get(id);

            if (experienceLevel.RequiringEntities.Any() || experienceLevel.Players.Any())
                throw new ConstraintException("Невозможно удалить уровень опыта, так как с ним связана одна или несколько сущностей и/или игроков.");

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

            if (gameMode.GameSessions.Any())
                throw new ConstraintException("Невозможно удалить игровой режим, так как с ним связана одна или несколько игровых сессий.");

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

            if (gameSession.PlayerSessions.Any())
                throw new ConstraintException("Невозможно удалить игровую сессию, так как с ней связана одна или несколько сессий игроков.");

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
                RemoveCollectedArtifact((ulong) collectedArtifact.Id, true);

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

        private static void ExecuteUserCommand(string command, string[] arguments)
        {
            switch (command)
            {
                case HELP_COMMAND:
                    if (arguments.Length > 1)
                        throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                    else if (arguments.Length == 1)
                        Help(arguments[0]);
                    else
                        Help();
                    break;
                case TABLES_COMMAND:
                    if (arguments.Length > 0)
                        throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                    else
                        Tables();
                    break;
                case VIEW_COMMAND:
                    if (arguments.Length == 0 || arguments.Length > 2)
                        throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                    else if (arguments.Length == 2)
                        View(arguments[0], arguments[1]);
                    else
                        View(arguments[0]);
                    break;
                case ADD_COMMAND:
                    if (arguments.Length != 1)
                        throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                    else
                        Add(arguments[0]);
                    break;
                case EDIT_COMMAND:
                    if (arguments.Length != 2)
                        throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                    else
                        Edit(arguments[0], arguments[1]);
                    break;
                case REMOVE_COMMAND:
                    if (arguments.Length != 2)
                        throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                    else
                        Remove(arguments[0], arguments[1]);
                    break;
                case EXIT_COMMAND:
                    Exit();
                    break;
                default:
                    throw new FormatException(UNKNOWN_COMMAND_MESSAGE);
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                Database.Load();
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(string.Join("", Enumerable.Repeat("-", 65)));
            Console.WriteLine("Добро пожаловать в программу управления базой данных хоррор-игры!");
            Console.WriteLine("Введите \"help\" для вывода списка доступных команд.");
            Console.WriteLine(string.Join("", Enumerable.Repeat("-", 65)));
            Console.WriteLine();

            while (loop)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    if (string.IsNullOrEmpty(input))
                        throw new FormatException(EMPTY_COMMAND_MESSAGE);

                    string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = words.First();
                    string[] arguments = words.Length > 1 ? words[1..words.Length] : Array.Empty<string>();
                
                    ExecuteUserCommand(command, arguments);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException ||
                        ex is FormatException ||
                        ex is ConstraintException ||
                        ex is DataException)
                        Console.WriteLine(ex.Message);
                    else
                        Console.WriteLine($"Произошла непредвиденная ошибка:\n{ex.Message}\n{ex.StackTrace}");
                }

                Console.WriteLine();
            }

            Database.Save();
        }
    }
}

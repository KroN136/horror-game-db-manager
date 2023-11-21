using HorrorGameDBManager.Models;
using System.Data;

namespace HorrorGameDBManager
{
    internal class Program
    {
        private static bool loop = true;

        private const string EMPTY_COMMAND_MESSAGE = "Введена пустая команда.";
        private const string UNKNOWN_COMMAND_MESSAGE = "Команда не распознана.";
        private const string WRONG_ARGUMENT_COUNT_MESSAGE = "Введено неверное число аргументов.";

        #region Command Actions

        private static void Help()
        {
            Help("help");
            Help("tables");
            Help("view");
            Help("add");
            Help("edit");
            Help("remove");
            Help("exit");
        }

        private static void Help(string command)
        {
            switch (command)
            {
                case "help":
                    Console.WriteLine("help [cmd] - просмотр справки по всем командам / просмотр справки по команде cmd");
                    break;
                case "tables":
                    Console.WriteLine("tables - просмотр списка всех таблиц");
                    break;
                case "view":
                    Console.WriteLine("view * - просмотр всех записей во всех таблицах");
                    Console.WriteLine("view <table> [id] - просмотр всех записей в таблице table / просмотр записи с идентификатором id в таблице table");
                    break;
                case "add":
                    Console.WriteLine("add <table> - добавление записи в таблицу table");
                    break;
                case "edit":
                    Console.WriteLine("edit <table> <id> - редактирование записи с идентификатором id в таблице table");
                    break;
                case "remove":
                    Console.WriteLine("remove <table> <id> - удаление записи с идентификатором id в таблице table");
                    break;
                case "exit":
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
                EntryManager.AddAbility();
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                EntryManager.AddAcquiredAbility();
            else if (tableName.Equals(Database.Artifacts.Name))
                EntryManager.AddArtifact();
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                EntryManager.AddCollectedArtifact();
            else if (tableName.Equals(Database.Entities.Name))
                EntryManager.AddEntity();
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                EntryManager.AddExperienceLevel();
            else if (tableName.Equals(Database.GameModes.Name))
                EntryManager.AddGameMode();
            else if (tableName.Equals(Database.GameSessions.Name))
                EntryManager.AddGameSession();
            else if (tableName.Equals(Database.Players.Name))
                EntryManager.AddPlayer();
            else if (tableName.Equals(Database.PlayerSessions.Name))
                EntryManager.AddPlayerSession();
            else if (tableName.Equals(Database.RarityLevels.Name))
                EntryManager.AddRarityLevel();
            else if (tableName.Equals(Database.Servers.Name))
                EntryManager.AddServer();
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void Edit(string tableName, string id)
        {
            if (tableName.Equals(Database.Abilities.Name))
                EntryManager.EditAbility(byte.Parse(id));
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                throw new ArgumentException($"Таблица {tableName} не является редактируемой.");
            else if (tableName.Equals(Database.Artifacts.Name))
                EntryManager.EditArtifact(byte.Parse(id));
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                EntryManager.EditCollectedArtifact(ulong.Parse(id));
            else if (tableName.Equals(Database.Entities.Name))
                EntryManager.EditEntity(byte.Parse(id));
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                EntryManager.EditExperienceLevel(byte.Parse(id));
            else if (tableName.Equals(Database.GameModes.Name))
                EntryManager.EditGameMode(byte.Parse(id));
            else if (tableName.Equals(Database.GameSessions.Name))
                EntryManager.EditGameSession(ulong.Parse(id));
            else if (tableName.Equals(Database.Players.Name))
                EntryManager.EditPlayer(id);
            else if (tableName.Equals(Database.PlayerSessions.Name))
                EntryManager.EditPlayerSession(ulong.Parse(id));
            else if (tableName.Equals(Database.RarityLevels.Name))
                EntryManager.EditRarityLevel(byte.Parse(id));
            else if (tableName.Equals(Database.Servers.Name))
                EntryManager.EditServer(ushort.Parse(id));
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void Remove(string tableName, string id)
        {
            if (tableName.Equals(Database.Abilities.Name))
                EntryManager.RemoveAbility(byte.Parse(id));
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                EntryManager.RemoveAcquiredAbility(ulong.Parse(id));
            else if (tableName.Equals(Database.Artifacts.Name))
                EntryManager.RemoveArtifact(byte.Parse(id));
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                EntryManager.RemoveCollectedArtifact(ulong.Parse(id));
            else if (tableName.Equals(Database.Entities.Name))
                EntryManager.RemoveEntity(byte.Parse(id));
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                EntryManager.RemoveExperienceLevel(byte.Parse(id));
            else if (tableName.Equals(Database.GameModes.Name))
                EntryManager.RemoveGameMode(byte.Parse(id));
            else if (tableName.Equals(Database.GameSessions.Name))
                EntryManager.RemoveGameSession(ulong.Parse(id));
            else if (tableName.Equals(Database.Players.Name))
                EntryManager.RemovePlayer(id);
            else if (tableName.Equals(Database.PlayerSessions.Name))
                EntryManager.RemovePlayerSession(ulong.Parse(id));
            else if (tableName.Equals(Database.RarityLevels.Name))
                EntryManager.RemoveRarityLevel(byte.Parse(id));
            else if (tableName.Equals(Database.Servers.Name))
                EntryManager.RemoveServer(ushort.Parse(id));
            else
                throw new ArgumentException($"Таблица {tableName} не существует.");
        }

        private static void Exit() => loop = false;

        #endregion

        public static void Main(string[] args)
        {
            Database.Load();

            Console.WriteLine(string.Join("", Enumerable.Repeat("-", 65)));
            Console.WriteLine("Добро пожаловать в программу управления базой данных хоррор-игры!");
            Console.WriteLine("Введите \"help\" для вывода списка доступных команд.");
            Console.WriteLine(string.Join("", Enumerable.Repeat("-", 65)));
            Console.WriteLine();

            while (loop)
                ExecuteUserCommand();

            Database.Save();
        }

        private static void ExecuteUserCommand()
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                if (string.IsNullOrEmpty(input))
                    throw new FormatException(EMPTY_COMMAND_MESSAGE);

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string[] args = parts.Length > 1 ? parts[1..parts.Length] : Array.Empty<string>();

                switch (command)
                {
                    case "help":
                        if (args.Length > 1)
                            throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else if (args.Length == 1)
                            Help(args[0]);
                        else
                            Help();
                        break;
                    case "tables":
                        if (args.Length > 0)
                            throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Tables();
                        break;
                    case "view":
                        if (args.Length == 0 || args.Length > 2)
                            throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else if (args.Length == 2)
                            View(args[0], args[1]);
                        else
                            View(args[0]);
                        break;
                    case "add":
                        if (args.Length != 1)
                            throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Add(args[0]);
                        break;
                    case "edit":
                        if (args.Length != 2)
                            throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Edit(args[0], args[1]);
                        break;
                    case "remove":
                        if (args.Length != 2)
                            throw new FormatException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Remove(args[0], args[1]);
                        break;
                    case "exit":
                        Exit();
                        break;
                    default:
                        throw new FormatException(UNKNOWN_COMMAND_MESSAGE);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ConstraintException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка.\n{ex.Message}\n{ex.StackTrace}");
            }

            Console.WriteLine();
        }
    }
}

using HorrorGameDBManager.Models;

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
                TablePrinter.PrintAbilities(Database.Abilities.GetAll());
                TablePrinter.PrintAcquiredAbilities(Database.AcquiredAbilities.GetAll());
                TablePrinter.PrintArtifacts(Database.Artifacts.GetAll());
                TablePrinter.PrintCollectedArtifacts(Database.CollectedArtifacts.GetAll());
                TablePrinter.PrintEntities(Database.Entities.GetAll());
                TablePrinter.PrintExperienceLevels(Database.ExperienceLevels.GetAll());
                TablePrinter.PrintGameModes(Database.GameModes.GetAll());
                TablePrinter.PrintGameSessions(Database.GameSessions.GetAll());
                TablePrinter.PrintPlayers(Database.Players.GetAll());
                TablePrinter.PrintPlayerSessions(Database.PlayerSessions.GetAll());
                TablePrinter.PrintRarityLevels(Database.RarityLevels.GetAll());
                TablePrinter.PrintServers(Database.Servers.GetAll());
                return;
            }

            if (tableName.Equals(Database.Abilities.Name))
                TablePrinter.PrintAbilities(Database.Abilities.GetAll());
            else if (tableName.Equals(Database.AcquiredAbilities.Name))
                TablePrinter.PrintAcquiredAbilities(Database.AcquiredAbilities.GetAll());
            else if (tableName.Equals(Database.Artifacts.Name))
                TablePrinter.PrintArtifacts(Database.Artifacts.GetAll());
            else if (tableName.Equals(Database.CollectedArtifacts.Name))
                TablePrinter.PrintCollectedArtifacts(Database.CollectedArtifacts.GetAll());
            else if (tableName.Equals(Database.Entities.Name))
                TablePrinter.PrintEntities(Database.Entities.GetAll());
            else if (tableName.Equals(Database.ExperienceLevels.Name))
                TablePrinter.PrintExperienceLevels(Database.ExperienceLevels.GetAll());
            else if (tableName.Equals(Database.GameModes.Name))
                TablePrinter.PrintGameModes(Database.GameModes.GetAll());
            else if (tableName.Equals(Database.GameSessions.Name))
                TablePrinter.PrintGameSessions(Database.GameSessions.GetAll());
            else if (tableName.Equals(Database.Players.Name))
                TablePrinter.PrintPlayers(Database.Players.GetAll());
            else if (tableName.Equals(Database.PlayerSessions.Name))
                TablePrinter.PrintPlayerSessions(Database.PlayerSessions.GetAll());
            else if (tableName.Equals(Database.RarityLevels.Name))
                TablePrinter.PrintRarityLevels(Database.RarityLevels.GetAll());
            else if (tableName.Equals(Database.Servers.Name))
                TablePrinter.PrintServers(Database.Servers.GetAll());
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
                throw new ArgumentException($"Таблица {Database.AcquiredAbilities.Name} не является редактируемой.");
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
            /*
            Database.ExperienceLevels.Add(new List<ExperienceLevel>()
            {
                new ExperienceLevel(1, 0),
                new ExperienceLevel(2, 500),
                new ExperienceLevel(3, 1000),
                new ExperienceLevel(4, 1500),
                new ExperienceLevel(5, 2000),
                new ExperienceLevel(6, 2500),
                new ExperienceLevel(7, 3000),
                new ExperienceLevel(8, 3500),
                new ExperienceLevel(9, 4000),
                new ExperienceLevel(10, 4500),
                new ExperienceLevel(11, 5000),
                new ExperienceLevel(12, 5500),
                new ExperienceLevel(13, 6000),
                new ExperienceLevel(14, 6500),
                new ExperienceLevel(15, 7000),
                new ExperienceLevel(16, 7500),
                new ExperienceLevel(17, 8000),
                new ExperienceLevel(18, 8500),
                new ExperienceLevel(19, 9000),
                new ExperienceLevel(20, 9500),
                new ExperienceLevel(21, 10000),
                new ExperienceLevel(22, 10500),
                new ExperienceLevel(23, 11000),
                new ExperienceLevel(24, 11500),
                new ExperienceLevel(25, 12000)
            });

            Database.Players.Add(new List<Player>()
            {
                new Player
                (
                    username: "Sweet_KroNa",
                    email: "kron2002a@yandex.ru",
                    password: "9136KroNa",
                    enableDataCollection: true
                ),
                new Player
                (
                    username: "Player1",
                    email: "original.email@gmail.com",
                    password: "1234password",
                    enableDataCollection: true
                ),
                new Player
                (
                    username: "Dark Angel",
                    email: "angelina.dark.2002@mail.ru",
                    password: "iwilleatyoursoul",
                    enableDataCollection: false
                )
            });

            Database.Abilities.Add(new List<Ability>()
            {
                new Ability(@"Dash.asset"),
                new Ability(@"QuieterThanWater.asset"),
                new ActivatedAbility(@"NeedForSpeed_Level1.asset", 30, 120),
                new ActivatedAbility(@"NeedForSpeed_Level2.asset", 30, 120),
                new ActivatedAbility(@"NeedForSpeed_Level3.asset", 30, 120),
                new ActivatedAbility(@"NeedForSpeed_Level4.asset", 30, 120),
                new ActivatedAbility(@"InvisibleHat_Level1.asset", 30, 600),
                new ActivatedAbility(@"InvisibleHat_Level2.asset", 60, 600),
                new ActivatedAbility(@"InvisibleHat_Level3.asset", 90, 600),
                new ActivatedAbility(@"InvisibleHat_Level4.asset", 120, 600)
            });
            */

            Console.WriteLine("Добро пожаловать в программу управления базой данных хоррор-игры!");
            Console.WriteLine("Введите help для вывода списка доступных команд.");
            Console.WriteLine();

            while (loop)
                ExecuteUserCommand();
        }

        private static void ExecuteUserCommand()
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException(EMPTY_COMMAND_MESSAGE);

                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string[] args = parts.Length > 1 ? parts[1..parts.Length] : Array.Empty<string>();

                switch (command)
                {
                    case "help":
                        if (args.Length > 1)
                            throw new ArgumentException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else if (args.Length == 1)
                            Help(args[0]);
                        else
                            Help();
                        break;
                    case "tables":
                        if (args.Length > 0)
                            throw new ArgumentException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Tables();
                        break;
                    case "view":
                        if (args.Length == 0 || args.Length > 2)
                            throw new ArgumentException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else if (args.Length == 2)
                            View(args[0], args[1]);
                        else
                            View(args[0]);
                        break;
                    case "add":
                        if (args.Length != 1)
                            throw new ArgumentException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Add(args[0]);
                        break;
                    case "edit":
                        if (args.Length != 2)
                            throw new ArgumentException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Edit(args[0], args[1]);
                        break;
                    case "remove":
                        if (args.Length != 2)
                            throw new ArgumentException(WRONG_ARGUMENT_COUNT_MESSAGE);
                        else
                            Remove(args[0], args[1]);
                        break;
                    case "exit":
                        Exit();
                        break;
                    default:
                        throw new ArgumentException(UNKNOWN_COMMAND_MESSAGE);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
    }
}

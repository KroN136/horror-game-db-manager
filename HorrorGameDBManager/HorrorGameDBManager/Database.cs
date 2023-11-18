using System.Text.Json;
using HorrorGameDBManager.Models;
using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager
{
    internal static class Database
    {
        public static Table<Ability> Abilities { get; private set; } = new Table<Ability>("abilities");
        public static Table<AcquiredAbility> AcquiredAbilities { get; private set; } = new Table<AcquiredAbility>("acquired_abilities");
        public static Table<Artifact> Artifacts { get;private set;  } = new Table<Artifact>("artifacts");
        public static Table<CollectedArtifact> CollectedArtifacts { get; private set; } = new Table<CollectedArtifact>("collected_artifacts");
        public static Table<Entity> Entities { get; private set; } = new Table<Entity>("entities");
        public static Table<ExperienceLevel> ExperienceLevels { get; private set; } = new Table<ExperienceLevel>("experience_levels");
        public static Table<GameMode> GameModes { get; private set; } = new Table<GameMode>("game_modes");
        public static Table<GameSession> GameSessions { get; private set; } = new Table<GameSession>("game_sessions");
        public static Table<Player> Players { get; private set; } = new Table<Player>("players");
        public static Table<PlayerSession> PlayerSessions { get; private set; } = new Table<PlayerSession>("player_sessions");
        public static Table<RarityLevel> RarityLevels { get; private set; } = new Table<RarityLevel>("rarity_levels");
        public static Table<Server> Servers { get; private set; } = new Table<Server>("servers");

        private static Table<T> LoadTable<T>(string name) where T : Model
        {
            Table<T> table = new("EMPTY_TABLE");

            try
            {
                if (File.Exists($"database\\{name}.json") == false)
                    throw new FileNotFoundException($"Файл не существует.");

                string fileContents = File.ReadAllText($"database\\{name}.json");
                var data = JsonSerializer.Deserialize<Table<T>>(fileContents, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                });

                if (data == null)
                    throw new FileLoadException("JsonSerializer вернул NULL.");
                else
                    table = data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось загрузить таблицу {name} из файла: {ex.Message}\n");
            }

            return table;
        }

        private static void SaveTable<T>(Table<T> table) where T : Model
        {
            try
            {
                string json = JsonSerializer.Serialize(table, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                });

                File.WriteAllText($"database\\{table.Name}.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось сохранить таблицу {table.Name} в файл: {ex.Message}\n");
            }
        }

        public static void Load()
        {
            Abilities.Add(LoadTable<Ability>(Abilities.Name).Entries);
            AcquiredAbilities.Add(LoadTable<AcquiredAbility>(AcquiredAbilities.Name).Entries);
            Artifacts.Add(LoadTable<Artifact>(Artifacts.Name).Entries);
            CollectedArtifacts.Add(LoadTable<CollectedArtifact>(CollectedArtifacts.Name).Entries);
            Entities.Add(LoadTable<Entity>(Entities.Name).Entries);
            ExperienceLevels.Add(LoadTable<ExperienceLevel>(ExperienceLevels.Name).Entries);
            GameModes.Add(LoadTable<GameMode>(GameModes.Name).Entries);
            GameSessions.Add(LoadTable<GameSession>(GameSessions.Name).Entries);
            Players.Add(LoadTable<Player>(Players.Name).Entries);
            PlayerSessions.Add(LoadTable<PlayerSession>(PlayerSessions.Name).Entries);
            RarityLevels.Add(LoadTable<RarityLevel>(RarityLevels.Name).Entries);
            Servers.Add(LoadTable<Server>(Servers.Name).Entries);
        }

        public static void Save()
        {
            SaveTable(Abilities);
            SaveTable(AcquiredAbilities);
            SaveTable(Artifacts);
            SaveTable(CollectedArtifacts);
            SaveTable(Entities);
            SaveTable(ExperienceLevels);
            SaveTable(GameModes);
            SaveTable(GameSessions);
            SaveTable(Players);
            SaveTable(PlayerSessions);
            SaveTable(RarityLevels);
            SaveTable(Servers);
        }
    }
}

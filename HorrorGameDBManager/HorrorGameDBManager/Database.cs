using System.Data;
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

        private static readonly string path = AppContext.BaseDirectory + "database";

        private static void LoadTable<T>(Table<T> table) where T : Model
        {
            try
            {
                string fileName = $"{path + Path.DirectorySeparatorChar + table.Name}.json";
                if (File.Exists(fileName) == false)
                    throw new FileNotFoundException($"Файл {fileName} не существует.");

                string fileContents = File.ReadAllText(fileName);
                var loadedTable = JsonSerializer.Deserialize<Table<T>>(fileContents, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

                if (loadedTable == null)
                    throw new FileLoadException("JsonSerializer вернул NULL.");
                else
                    table.Add(loadedTable.Entries);
            }
            catch (Exception ex)
            {
                throw new DataException($"Не удалось загрузить таблицу {table.Name} с диска: {ex.Message}\n");
            }
        }

        private static void SaveTable<T>(Table<T> table) where T : Model
        {
            try
            {
                string json = JsonSerializer.Serialize(table, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

                string fileName = $"{path + Path.DirectorySeparatorChar + table.Name}.json";
                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                throw new DataException($"Не удалось сохранить таблицу {table.Name} на диск: {ex.Message}\n");
            }
        }

        public static void Load()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return;
            }

            LoadTable(Abilities);
            LoadTable(AcquiredAbilities);
            LoadTable(Artifacts);
            LoadTable(CollectedArtifacts);
            LoadTable(Entities);
            LoadTable(ExperienceLevels);
            LoadTable(GameModes);
            LoadTable(GameSessions);
            LoadTable(Players);
            LoadTable(PlayerSessions);
            LoadTable(RarityLevels);
            LoadTable(Servers);
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

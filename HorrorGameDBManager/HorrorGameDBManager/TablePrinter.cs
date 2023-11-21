using HorrorGameDBManager.Models;

namespace HorrorGameDBManager
{
    internal static class TablePrinter
    {
        public static int MaxColumnLength { get; set; } = 25;

        private static string SetMinLength(string target, int length)
        {
            string result = new(target);

            while (result.Length < length)
                result += " ";

            return result;
        }

        private static string SetMaxLength(string target, int length)
        {
            string result = new(target);

            if (result.Length > length)
                result = result[..(length - 3)] + "...";

            return result;
        }

        private static string SetLength(string target, int length)
        {
            string result = new(target);

            result = SetMaxLength(result, length);
            result = SetMinLength(result, length);

            return result;
        }

        public static void PrintTable(IEnumerable<string[]> dataList, string[] headers, string tableHeader, string tableName)
        {
            int[] maxLengths = new int[headers.Length];

            for (int i = 0; i < maxLengths.Length; i++)
            {
                if (dataList.Any())
                    maxLengths[i] = Math.Clamp(dataList.Select(data => data[i].Length).Max(), headers[i].Length, MaxColumnLength);
                else
                    maxLengths[i] = Math.Clamp(headers[i].Length, headers[i].Length, MaxColumnLength);
            }

            for (int i = 0; i < headers.Length; i++)
                headers[i] = SetLength(headers[i], maxLengths[i]);

            string headerString = "| " + string.Join(" | ", headers) + " |";

            Console.WriteLine($"{tableHeader.ToUpper()} ({tableName}), всего элементов: {dataList.Count()}");
            Console.WriteLine(string.Join("", Enumerable.Repeat("-", headerString.Length)));
            Console.WriteLine(headerString);
            Console.WriteLine(string.Join("", Enumerable.Repeat("-", headerString.Length)));

            foreach (var data in dataList)
            {
                for (int i = 0; i < data.Length; i++)
                    data[i] = SetLength(data[i], maxLengths[i]);

                Console.WriteLine("| " + string.Join(" | ", data) + " |");
            }

            Console.WriteLine(string.Join("", Enumerable.Repeat("-", headerString.Length)));
            Console.WriteLine();
        }

        public static void PrintAbilities(IEnumerable<Ability> abilities)
        {
            List<string[]> entryDataList = new();
            
            for (int i = 0; i < abilities.Count(); i++)
            {
                var entry = abilities.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.AssetName,
                    entry is ActivatedAbility ? "да" : "нет",
                    entry is ActivatedAbility activatedAbility ? $"{activatedAbility.Duration} сек" : "-",
                    entry is ActivatedAbility activatedAbility1 ? $"{activatedAbility1.Cooldown} сек" : "-"
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("Название ассета", MaxColumnLength),
                SetMaxLength("Активируемая", MaxColumnLength),
                SetMaxLength("Длительность", MaxColumnLength),
                SetMaxLength("Восстановление", MaxColumnLength),
            };

            PrintTable(entryDataList, headers, "способности", Database.Abilities.Name);
        }

        public static void PrintAcquiredAbilities(IEnumerable<AcquiredAbility> acquiredAbilities)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < acquiredAbilities.Count(); i++)
            {
                var entry = acquiredAbilities.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.PlayerId,
                    entry.AbilityId.ToString()
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("ID игрока", MaxColumnLength),
                SetMaxLength("ID способности", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "приобретённые способности", Database.AcquiredAbilities.Name);
        }

        public static void PrintArtifacts(IEnumerable<Artifact> artifacts)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < artifacts.Count(); i++)
            {
                var entry = artifacts.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.AssetName,
                    entry.RarityLevelId.ToString()
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("Название ассета", MaxColumnLength),
                SetMaxLength("ID уровня редкости", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "артефакты", Database.Artifacts.Name);
        }

        public static void PrintCollectedArtifacts(IEnumerable<CollectedArtifact> collectedArtifacts)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < collectedArtifacts.Count(); i++)
            {
                var entry = collectedArtifacts.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.PlayerId,
                    entry.ArtifactId.ToString(),
                    entry.PlayerSessionId.HasValue ? entry.PlayerSessionId.Value.ToString() : "-"
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("ID игрока", MaxColumnLength),
                SetMaxLength("ID артефакта", MaxColumnLength),
                SetMaxLength("ID сессии игрока", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "собранные артефакты", Database.CollectedArtifacts.Name);
        }

        public static void PrintEntities(IEnumerable<Entity> entities)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < entities.Count(); i++)
            {
                var entry = entities.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.AssetName,
                    entry.Health.ToString(),
                    entry.MovementSpeed.ToString(),
                    entry.RequiredExperienceLevelId.ToString()
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("Название ассета", MaxColumnLength),
                SetMaxLength("Здоровье", MaxColumnLength),
                SetMaxLength("Скорость передвижения", MaxColumnLength),
                SetMaxLength("ID требуемого уровня опыта", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "сущности", Database.Entities.Name);
        }

        public static void PrintExperienceLevels(IEnumerable<ExperienceLevel> experienceLevels)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < experienceLevels.Count(); i++)
            {
                var entry = experienceLevels.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.Number.ToString(),
                    entry.RequiredExperiencePoints.ToString(),
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("Номер", MaxColumnLength),
                SetMaxLength("Требуемый опыт", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "уровни опыта", Database.ExperienceLevels.Name);
        }

        public static void PrintGameModes(IEnumerable<GameMode> gameModes)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < gameModes.Count(); i++)
            {
                var entry = gameModes.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.AssetName,
                    entry.PlayerCount.ToString(),
                    entry.TimeLimit.HasValue ? entry.TimeLimit.Value.ToString() : "-",
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("Название ассета", MaxColumnLength),
                SetMaxLength("Количество игроков", MaxColumnLength),
                SetMaxLength("Лимит времени", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "игровые режимы", Database.GameModes.Name);
        }

        public static void PrintGameSessions(IEnumerable<GameSession> gameSessions)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < gameSessions.Count(); i++)
            {
                var entry = gameSessions.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.ServerId.HasValue ? entry.ServerId.Value.ToString() : "-",
                    entry.GameModeId.HasValue ? entry.GameModeId.Value.ToString() : "-",
                    entry.StartDateTime.ToString(),
                    entry.EndDateTime.HasValue ? entry.EndDateTime.Value.ToString() : "-",
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("ID сервера", MaxColumnLength),
                SetMaxLength("ID игрового режима", MaxColumnLength),
                SetMaxLength("Дата и время начала", MaxColumnLength),
                SetMaxLength("Дата и время окончания", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "игровые сессии", Database.GameSessions.Name);
        }

        public static void PrintPlayers(IEnumerable<Player> players)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < players.Count(); i++)
            {
                var entry = players.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.Username,
                    entry.Email,
                    entry.Password,
                    entry.RegistrationDateTime.ToString(),
                    entry.ExperienceLevelId.ToString(),
                    entry.ExperiencePoints.ToString(),
                    entry.AbilityPoints.ToString(),
                    entry.IsOnline ? "да" : "нет",
                    entry.EnableDataCollection ? "да" : "нет"
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("Никнейм", MaxColumnLength),
                SetMaxLength("Email", MaxColumnLength),
                SetMaxLength("Пароль", MaxColumnLength),
                SetMaxLength("Дата и время регистрации", MaxColumnLength),
                SetMaxLength("ID уровня опыта", MaxColumnLength),
                SetMaxLength("Опыт", MaxColumnLength),
                SetMaxLength("Очки способностей", MaxColumnLength),
                SetMaxLength("В сети", MaxColumnLength),
                SetMaxLength("Сбор данных", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "игроки", Database.Players.Name);
        }

        public static void PrintPlayerSessions(IEnumerable<PlayerSession> playerSessions)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < playerSessions.Count(); i++)
            {
                var entry = playerSessions.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.GameSessionId.HasValue ? entry.GameSessionId.Value.ToString() : "-",
                    entry.PlayerId,
                    entry.IsFinished.HasValue ? entry.IsFinished.Value ? "да" : "нет" : "-",
                    entry.IsWon.HasValue ? entry.IsWon.Value ? "да" : "нет" : "-",
                    entry.TimeAlive.HasValue ? $"{entry.TimeAlive.Value} сек" : "-",
                    entry.PlayedAsEntity.HasValue ? entry.PlayedAsEntity.Value ? "да" : "нет" : "-",
                    entry.UsedEntityId.HasValue ? entry.UsedEntityId.Value.ToString() : "-",
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("ID игровой сессии", MaxColumnLength),
                SetMaxLength("ID игрока", MaxColumnLength),
                SetMaxLength("Завершена", MaxColumnLength),
                SetMaxLength("Выиграна", MaxColumnLength),
                SetMaxLength("Время жизни", MaxColumnLength),
                SetMaxLength("Использована сущность", MaxColumnLength),
                SetMaxLength("ID использованной сущности", MaxColumnLength)
            };

            PrintTable(entryDataList, headers, "сессии игроков", Database.PlayerSessions.Name);
        }

        public static void PrintRarityLevels(IEnumerable<RarityLevel> rarityLevels)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < rarityLevels.Count(); i++)
            {
                var entry = rarityLevels.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.AssetName,
                    entry.Probability.ToString()
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("Название ассета", MaxColumnLength),
                SetMaxLength("Вероятность", MaxColumnLength),
            };

            PrintTable(entryDataList, headers, "уровни редкости", Database.RarityLevels.Name);
        }

        public static void PrintServers(IEnumerable<Server> servers)
        {
            List<string[]> entryDataList = new();

            for (int i = 0; i < servers.Count(); i++)
            {
                var entry = servers.ElementAt(i);

                string[] entryData = new string[]
                {
                    entry.Id.ToString()!,
                    entry.IpAddress,
                    entry.PlayerCapacity.ToString(),
                    entry.IsActive ? "да" : "нет",
                    entry.PlayerCount.ToString()
                };

                entryDataList.Add(entryData);
            }

            string[] headers = new string[]
            {
                SetMaxLength("ID", MaxColumnLength),
                SetMaxLength("IP-адрес", MaxColumnLength),
                SetMaxLength("Вместимость", MaxColumnLength),
                SetMaxLength("Активен", MaxColumnLength),
                SetMaxLength("Количество игроков", MaxColumnLength),
            };

            PrintTable(entryDataList, headers, "серверы", Database.Servers.Name);
        }
    }
}

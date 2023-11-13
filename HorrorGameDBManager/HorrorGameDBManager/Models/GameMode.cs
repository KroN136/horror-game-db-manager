namespace HorrorGameDBManager.Models
{
    internal class GameMode
    {
        public byte Id { get; }
        public string AssetName { get; set; }
        public byte PlayerCount { get; set; }
        public float? TimeLimit { get; set; }

        public GameMode(string assetName, byte playerCount, float? timeLimit)
        {
            Id = Database.GenerateGameModeId();
            AssetName = assetName;
            PlayerCount = playerCount;
            TimeLimit = timeLimit;
        }
    }
}

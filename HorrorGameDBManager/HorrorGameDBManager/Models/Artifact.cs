using System;

namespace HorrorGameDBManager.Models
{
    internal class Artifact
    {
        public string AssetName { get; set; }
        public byte RarityLevelId { get; }

        public Artifact(string assetName, byte rarityLevelId)
        {
            AssetName = assetName;

            if (Database.RarityLevelExists(rarityLevelId))
                RarityLevelId = rarityLevelId;
            else
                throw new ArgumentException($"Уровень редкости {rarityLevelId} не существует.");
        }
    }
}

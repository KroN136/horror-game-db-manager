﻿namespace HorrorGameDBManager.Models.Base
{
    internal abstract class ModelWithStringId : Model
    {
        private readonly int idLength;
        private const string POSSIBLE_ID_CHARACTERS = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789_-";

        public ModelWithStringId(int idLength) => this.idLength = idLength;

        private string GenerateStringId(int length)
        {
            Random random = new Random();

            return new string(Enumerable.Repeat(POSSIBLE_ID_CHARACTERS, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public override object GenerateId(IEnumerable<object> existingIds)
        {
            string id;

            if (existingIds.Any())
            {
                id = existingIds.First().ToString()!;
                while (existingIds.Contains(id))
                    id = GenerateStringId(idLength);
            }
            else
            {
                id = GenerateStringId(idLength);
            }

            return id;
        }
    }
}

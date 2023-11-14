using System;
using System.Collections.Generic;
using System.Linq;

namespace HorrorGameDBManager
{
    internal class TableWithStringId<U> : Table<string, U>
    {
        private int idLength;
        private const string possibleIdCharacters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789_-";

        public TableWithStringId(int idLength) : base() => this.idLength = idLength;
        public TableWithStringId(Dictionary<string, U> entries, int idLength) : base(entries) => this.idLength = idLength;

        private string GenerateStringId(int length)
        {
            Random random = new Random();

            return new string(Enumerable.Repeat(possibleIdCharacters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override string GenerateId()
        {
            string id;

            if (entries.Any())
            {
                id = entries.Keys.First();
                while (entries.Keys.Contains(id))
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

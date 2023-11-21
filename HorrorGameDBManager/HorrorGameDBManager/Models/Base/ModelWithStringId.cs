namespace HorrorGameDBManager.Models.Base
{
    internal abstract class ModelWithStringId : Model
    {
        private readonly int idLength;
        private const string POSSIBLE_ID_CHARACTERS = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789_-";

        public ModelWithStringId(int idLength) => this.idLength = idLength;

        private string GenerateStringId()
        {
            Random random = new();
            return new string(Enumerable.Repeat(POSSIBLE_ID_CHARACTERS, idLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override object GenerateId(IEnumerable<object> existingIds)
        {
            string id;

            if (existingIds.Any())
            {
                id = existingIds.First().ToString()!;
                while (existingIds.Contains(id))
                    id = GenerateStringId();
            }
            else
            {
                id = GenerateStringId();
            }

            return id;
        }
    }
}

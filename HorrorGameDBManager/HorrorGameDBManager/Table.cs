using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager
{
    internal class Table<T> where T : Model
    {
        public string Name { get; }
        private static List<string> names = new();

        protected List<T> entries = new();

        public List<T> GetAll() => new(entries);
        public void SetAll(List<T> entries) =>
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));

        public Table(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (names.Contains(name))
                throw new ArgumentException($"Таблица {name} уже существует.");

            Name = name;
        }

        public bool Exists(object id) => entries.Any(entry => entry.Id.Equals(id));

        public T Get(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (!Exists(id))
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            return (T) entries.Find(entry => entry.Id.Equals(id))!.Clone();
        }

        public void Add(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            entries.Add(entry);
        }

        public void Add(IEnumerable<T> entries)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));

            if (entries.Any(entry => entry == null))
                throw new ArgumentException("Одна или несколько добавляемых записей была(-и) NULL.");

            this.entries.AddRange(entries);
        }

        public void Edit(object id, T newEntry)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (!Exists(id))
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            T entry = entries.Find(entry => entry.Id.Equals(id))!;
            entries[entries.IndexOf(entry)] = newEntry;
        }

        public void Remove(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (!Exists(id))
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            entries.Remove(entries.Find(entry => entry.Id.Equals(id))!);
        }
    }
}

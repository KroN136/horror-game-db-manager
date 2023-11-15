using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager
{
    internal class Table<T> where T : Model
    {
        protected Dictionary<object, T> entries = new();

        public Dictionary<object, T> GetAll() => new(entries);
        public void SetAll(Dictionary<object, T> entries) =>
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));

        public Table() { }
        public Table(Dictionary<object, T> entries) => SetAll(entries);

        public bool Exists(object id) => entries.ContainsKey(id);

        public T Get(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (entries.ContainsKey(id) == false)
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            return entries[id];
        }

        public void Add(T entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            object id = entry.GenerateId(entries.Keys);
            entries[id] = entry;
        }

        public void Add(IEnumerable<T> entries)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));

            if (entries.Any(entry => entry == null))
                throw new ArgumentException("Одна или несколько добавляемых записей была(-и) NULL.");

            foreach (T entry in entries)
            {
                object id = entry.GenerateId(this.entries.Keys);
                this.entries[id] = entry;
            }
        }

        public void Remove(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (entries.ContainsKey(id) == false)
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            entries.Remove(id);
        }
    }
}

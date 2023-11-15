using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager
{
    internal class Table<T> where T : Model
    {
        protected List<T> entries = new();

        public List<T> GetAll() => new(entries);
        public void SetAll(List<T> entries) =>
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));

        public Table() { }
        public Table(List<T> entries) => SetAll(entries);

        public bool Exists(object id) => entries.Any(entry => entry.Id.Equals(id));

        public T Get(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (!Exists(id))
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            return entries.Find(entry => entry.Id.Equals(id))!;
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

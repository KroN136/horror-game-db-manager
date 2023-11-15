using System;
using System.Collections.Generic;

namespace HorrorGameDBManager
{
    internal abstract class Table<T, U> where T : notnull
    {
        protected Dictionary<T, U> entries = new Dictionary<T, U>();

        public Dictionary<T, U> GetEntries() => new Dictionary<T, U>(entries);
        public void SetEntries(Dictionary<T, U> entries) =>
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));

        public Table() { }
        public Table(Dictionary<T, U> entries) => SetEntries(entries);

        public bool EntryExists(T id) => entries.ContainsKey(id);

        public U GetEntry(T id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (entries.ContainsKey(id) == false)
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            return entries[id];
        }

        public void AddEntry(U entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            T id = GenerateId();
            entries[id] = entry;
        }

        public void AddEntries(IEnumerable<U> entries)
        {
            if (entries == null)
                throw new ArgumentNullException(nameof(entries));

            if (entries.Any(entry => entry == null))
                throw new ArgumentException("Одна или несколько добавляемых записей была(-и) NULL.");

            foreach (U entry in entries)
            {
                T id = GenerateId();
                this.entries[id] = entry;
            }
        }

        public void RemoveEntry(T id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (entries.ContainsKey(id) == false)
                throw new ArgumentException($"Запись с идентификатором {id} не существует.");

            entries.Remove(id);
        }

        protected abstract T GenerateId();
    }
}

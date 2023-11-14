using System;
using System.Collections.Generic;

namespace HorrorGameDBManager
{
    internal abstract class Table<T, U>
    {
        protected Dictionary<T, U> entries;

        public Dictionary<T, U> GetEntries() => new Dictionary<T, U>(entries);
        public void SetEntries(Dictionary<T, U> entries) =>
            this.entries = entries ?? throw new ArgumentNullException(nameof(entries));

        public Table() => SetEntries(new Dictionary<T, U>());
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

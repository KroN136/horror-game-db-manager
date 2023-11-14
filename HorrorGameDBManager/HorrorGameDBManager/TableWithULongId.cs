using System.Collections.Generic;
using System.Linq;

namespace HorrorGameDBManager
{
    internal class TableWithULongId<U> : Table<ulong, U>
    {
        public TableWithULongId() : base() { }
        public TableWithULongId(Dictionary<ulong, U> entries) : base(entries) { }

        protected override ulong GenerateId() => entries.Any() ?
            entries.Keys.Last() + 1 :
            1;
    }
}

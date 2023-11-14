using System.Collections.Generic;
using System.Linq;

namespace HorrorGameDBManager
{
    internal class TableWithUShortId<U> : Table<ushort, U>
    {
        public TableWithUShortId() : base() { }
        public TableWithUShortId(Dictionary<ushort, U> entries) : base(entries) { }

        protected override ushort GenerateId() => (ushort) (entries.Any() ?
            entries.Keys.Last() + 1 :
            1);
    }
}

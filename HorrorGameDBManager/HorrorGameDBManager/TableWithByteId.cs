using System.Collections.Generic;
using System.Linq;

namespace HorrorGameDBManager
{
    internal class TableWithByteId<U> : Table<byte, U>
    {
        public TableWithByteId() : base() { }
        public TableWithByteId(Dictionary<byte, U> entries) : base(entries) { }

        protected override byte GenerateId() => (byte) (entries.Any() ?
            entries.Keys.Last() + 1 :
            1);
    }
}

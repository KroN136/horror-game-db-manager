namespace HorrorGameDBManager.Models.Base
{
    internal abstract class ModelWithULongId : Model
    {
        public override object GenerateId(IEnumerable<object> existingIds) => (ulong) (existingIds.Any() ?
            (ulong) existingIds.Last() + 1 :
            1);
    }
}

namespace HorrorGameDBManager.Models.Base
{
    internal abstract class ModelWithULongId : Model
    {
        protected override object GenerateId(IEnumerable<object> existingIds) => (ulong) (existingIds.Any() ?
            (ulong) existingIds.Last() + 1 :
            1);
    }
}

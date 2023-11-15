namespace HorrorGameDBManager.Models.Base
{
    internal class ModelWithUShortId : Model
    {
        public override object GenerateId(IEnumerable<object> existingIds) => (ushort) (existingIds.Any() ?
            (ushort) existingIds.Last() + 1 :
            1);
    }
}

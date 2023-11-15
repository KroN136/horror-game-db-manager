namespace HorrorGameDBManager.Models.Base
{
    internal abstract class ModelWithByteId : Model
    {
        public override object GenerateId(IEnumerable<object> existingIds) => (byte) (existingIds.Any() ?
            (byte) existingIds.Last() + 1 :
            1);
    }
}

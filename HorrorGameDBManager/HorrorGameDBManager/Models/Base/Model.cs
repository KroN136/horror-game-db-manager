namespace HorrorGameDBManager.Models.Base
{
    internal abstract class Model
    {
        public abstract object GenerateId(IEnumerable<object> existingIds);
    }
}

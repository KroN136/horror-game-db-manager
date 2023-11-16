namespace HorrorGameDBManager.Models.Base
{
    internal abstract class Model : ICloneable
    {
        public object Id { get; protected set; } = new();
        protected abstract object GenerateId(IEnumerable<object> existingIds);
        public abstract object Clone();
    }
}

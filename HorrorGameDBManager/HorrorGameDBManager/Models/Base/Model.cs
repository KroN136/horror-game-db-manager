namespace HorrorGameDBManager.Models.Base
{
    internal abstract class Model
    {
        public object Id { get; init; } = new();
        public abstract object GenerateId(IEnumerable<object> existingIds);
    }
}

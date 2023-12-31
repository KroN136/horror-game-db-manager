﻿namespace HorrorGameDBManager.Models.Base
{
    internal abstract class ModelWithUShortId : Model
    {
        protected override object GenerateId(IEnumerable<object> existingIds) => (ushort) (existingIds.Any() ?
            (ushort) existingIds.Last() + 1 :
            1);
    }
}

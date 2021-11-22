using System;

namespace NCore.Samples.Inventory.Domain.Infra
{
    public static class AggregateKeyExtensions
    {
        public static AggregateKey AsAggregateKey(this Guid id)
        {
            return new AggregateKey(id);
        }

        public static Guid AsGuid(this AggregateKey key)
        {
            return new Guid(key.ToString());
        }

        public static Guid AsGuid(this string key)
        {
            return new Guid(key);
        }
    }
}
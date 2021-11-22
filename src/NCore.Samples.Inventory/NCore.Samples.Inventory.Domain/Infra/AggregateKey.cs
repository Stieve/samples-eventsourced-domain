using System;

namespace NCore.Samples.Inventory.Domain.Infra
{
    public readonly struct AggregateKey : IEquatable<AggregateKey>
    {
        private readonly string _value;

        public AggregateKey(Guid id)
        {
            _value = id.ToString("N");
        }

        public bool Equals(AggregateKey other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is AggregateKey other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(_value);
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator AggregateKey(Guid id)
            => new AggregateKey(id);

        public static implicit operator Guid(AggregateKey key)
            => new Guid(key.ToString());

        public static implicit operator string(AggregateKey key)
            => key.ToString();
    }
}
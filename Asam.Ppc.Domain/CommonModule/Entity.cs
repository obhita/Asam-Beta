using System;

namespace Asam.Ppc.Domain.Common
{
    public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>
    {
        public TId Id { get; private set; }

        public virtual Entity<TId> SetId(TId id)
        {
            Id = id;
            return this;
        }

        public bool Equals(Entity<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            var thisIsTransient = Equals(Id, default(TId));
            var otherIsTransient = Equals(other.Id, default(TId));

            bool result;
            if (thisIsTransient && otherIsTransient)
            {
                result = ReferenceEquals(this, other);
            }
            else
            {
                result = Equals(other.Id, Id);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity<TId>)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }
    }

    public abstract class Entity : Entity<string>, IEntity
    {
    }
}

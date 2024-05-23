using GameLibrary.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Models
{
    public abstract class EntityWithIdAndName<T>
        : IEquatable<EntityWithIdAndName<T>?>
    where T : EntityWithIdAndName<T>
    {

        protected static readonly Dictionary<string, EntityWithIdAndName<T>> _wellKnownValues;

        static EntityWithIdAndName()
        {
            _wellKnownValues = new Dictionary<string, EntityWithIdAndName<T>>();
        }

        protected static void AddWellKnownValues()
        {
            PropertyInfo[] staticprops =
                typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(T))
                .ToArray();

            foreach (PropertyInfo prop in staticprops)
            {
                T propValue = (prop.GetValue(null) as T)!;
                _wellKnownValues.Add(propValue.Id, propValue);
            }
        }

        public string Id { get; }
        public string Name { get; }

        protected EntityWithIdAndName(string id, string name)
        {
            Id = id.GetWithTextOrThrow(nameof(id));
            Name = name.GetWithTextOrThrow(nameof(name));
        }

        public override bool Equals(object? obj) =>
            (this as IEquatable<EntityWithIdAndName<T>?>).Equals(obj as EntityWithIdAndName<T>);

        bool IEquatable<EntityWithIdAndName<T>?>.Equals(EntityWithIdAndName<T>? other) =>
            other is not null
            && GetType() == other.GetType()
            && Id == other.Id;

        public override int GetHashCode() =>
            Id.GetHashCode();
    }
}

using System.Reflection;

namespace GeekShopping.Identity.Enumerations.Base;

public abstract class EnumerationBase<TEnumerator, TEntity>
    where TEnumerator : EnumerationBase<TEnumerator, TEntity>
    where TEntity : class
{
    private static IReadOnlyCollection<TEntity> _entities;

    public static IReadOnlyCollection<TEntity> GetAll()
    {
        if (_entities?.Any() ?? false) return _entities;

        _entities = typeof(TEnumerator)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<TEntity>()
            .ToList()
            .AsReadOnly();

        return _entities;
    }
}

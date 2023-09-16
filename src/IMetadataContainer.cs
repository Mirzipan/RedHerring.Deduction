using System.Reflection;

namespace RedHerring.Deduction;

public interface IMetadataContainer
{
    IReadOnlyCollection<Assembly> KnownAssemblies { get; }
    void Add(IEnumerable<Assembly> assemblies);
    void Add(params Assembly[] assemblies);
    void Add(Assembly assembly);
    IEnumerable<Type> GetAllTypes();
}
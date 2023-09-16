using System.Runtime.CompilerServices;

namespace RedHerring.Deduction;

public class Crawler : ICrawlMetadata, IDisposable
{
    private List<IIndexMetadata> _indexers = new();
    private IMetadataContainer _container;

    public IReadOnlyList<IIndexMetadata> Indexers => _indexers;
    public IMetadataContainer Container => _container;

    #region Lifecycle

    public Crawler(IMetadataContainer container)
    {
        _container = container;
    }

    public void Process()
    {
        foreach (var type in _container.GetAllTypes())
        {
            Index(type);
        }
    }

    public void Dispose()
    {
    }

    #endregion Lifecycle

    #region Manipulation

    public void AddIndexer(IIndexMetadata indexer)
    {
        _indexers.Add(indexer);
    }

    public void RemoveIndexer(IIndexMetadata indexer)
    {
        _indexers.Remove(indexer);
    }

    #endregion Manipulation

    #region Private

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Index(Type type)
    {
        for (int i = 0; i < _indexers.Count; i++)
        {
            _indexers[i].Index(type);
        }
    }

    #endregion Private
}
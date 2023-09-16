namespace RedHerring.Deduction;

public interface ICrawlMetadata
{
    IReadOnlyList<IIndexMetadata> Indexers { get; }
    IMetadataContainer Container { get; }
}
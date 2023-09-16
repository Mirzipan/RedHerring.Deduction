# Red Herring Deduction

![Nuget](https://img.shields.io/nuget/v/RedHerring.Deduction)

Simple metadata crawler for your game.

## Container

Container currently holds assemblies and allows easy access to all loaded types.

## Crawler

When you register your indexers with the `Crawler` (or whatever you used to implemented `ICrawlMetadata`), it will be notified when all types are being processed.

## Indexer

You can implement your own metadata indexer, using the `IIndexMetadata` interface.
Once your indexer has been added to the crawler, it will be invoked during type processing.

## Sample

```csharp
private ICrawlMetadata _crawler;

public void Init() 
{
    IMetadataContainer container = new MetadataContainer();
    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
    container.Add(assemblies);
    
    _crawler = new Crawler(container);
    var indexer = new YourIndexer();
    _crawler.AddIndexer(indexer);
    
    _crawler.Process(); // this is what calls your indexers
}

```


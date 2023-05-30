#if NET7_0_OR_GREATER

using Orleans;
using Orleans.TestingHost;

namespace ConsumerTests.Orleans;

public class ClusterFixture : IDisposable
{
    //for now my env name is always Development and it gets overridden later by env variables
    private static readonly string _envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

    public TestCluster Cluster { get; }

    public ClusterFixture()
    {
        var builder = new TestClusterBuilder();

        Cluster = builder.Build();

        Cluster.Deploy();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Cluster.StopAllSilos();
    }
}

public sealed class GlobalClusterFixture : ClusterFixture
{ }


[CollectionDefinition(Name)]
public class GlobalClusterCollection : ICollectionFixture<GlobalClusterFixture>
{
    public const string Name = "ClusterCollection";
}

/// <summary>
/// Uses a single, global cluster for operations that are stateless and to save performance
/// </summary>
[Collection(GlobalClusterCollection.Name)]
public abstract class ClusterTestBase
{
    public ClusterTestBase(GlobalClusterFixture fixture)
    {
        Cluster = fixture.Cluster;
    }

    protected TestCluster Cluster { get; }

    protected IGrainFactory GrainFactory => Cluster.GrainFactory;
}

#endif
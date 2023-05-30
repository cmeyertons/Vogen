#if NET7_0_OR_GREATER

using Orleans;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerTests.Orleans;

[ValueObject(typeof(string), Conversions.OrleansConverter)]
[RegisterSerializer, RegisterCopier]
public partial record struct StringValueObject
{ }

[GenerateSerializer]
public readonly record struct StringHolder(StringValueObject VO);

public interface ISerializationTestGrain : IGrainWithGuidKey
{
    ValueTask<T> Return<T>(T item);
}

public class SerializationTestGrain : Grain, ISerializationTestGrain
{
    public ValueTask<T> Return<T>(T item) => ValueTask.FromResult(item);
}

public class StringTests : ClusterTestBase
{
    public StringTests(GlobalClusterFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task TestOrleans()
    {
        var vo = StringValueObject.From(Guid.NewGuid().ToString());

        var grain = this.Cluster.GrainFactory.GetGrain<ISerializationTestGrain>(Guid.NewGuid());

        var value = await grain.Return(vo);

        var list = Enumerable.Range(0, 10).Select(x => StringValueObject.From(x.ToString(CultureInfo.InvariantCulture))).ToList();

        var listResult = await grain.Return(list);

        listResult.Should().BeEquivalentTo(list);

        value.Should().Be(vo);

        var embedded = new StringHolder(vo);

        var embeddedResult = await grain.Return(embedded);

        embeddedResult.Should().Be(embedded);
    }
}

#endif


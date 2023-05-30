namespace SnapshotTests.Orleans
{
    //[ValueObject(typeof(string), Conversions.OrleansConverter)]
    //[RegisterConverter]
    public partial record struct OrleansValueObject
    { }

    public class OrleansTests
    {
        public OrleansTests()
        {
            // var set = ImmutableHashSet.Create<OrleansValueObject>();

        }
    }
}

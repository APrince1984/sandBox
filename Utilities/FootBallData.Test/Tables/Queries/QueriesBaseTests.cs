using NUnit.Framework;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public abstract class QueriesBaseTests : DataTestBase
    {
        [Test]
        public abstract void GetEntityById_EntityDoesNotExist_ReturnsNull();

        [Test]
        public abstract void GetEntityById_EntityDoesExist_ReturnsEntity();
    }
}

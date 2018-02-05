using NUnit.Framework;

namespace FootBallData.Test.Tables.Commands
{
    [TestFixture]
    public abstract class CommandsBaseTests : DataTestBase
    {
        [Test]
        public abstract void SaveEntity_EntityIsNew_EntityIsCreated();

        [Test]
        public abstract void SaveEntity_EntityExists_EntityIsUpdated();
    }
}

using FootBallData.Tables;
using FootBallData.Tables.Commands;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Commands
{
    [TestFixture]
    public class TitleCommandsTests : DataTestBase
    {
        [Test]
        public void TitleCommands_TitleIsNew_TitleIsCreated()
        {
            var title = TitleCommands.SaveTitle(Context, new Title{Description = RandomUtil.GetRandomString()});
            Assert.IsNotNull(title.IdTitle);
        }

        [Test]
        public void TitleCommands_TitleExists_TitleIsUpdated()
        {
            var description = RandomUtil.GetRandomAlphaNumericString(25);
            var title = TitleCommands.SaveTitle(Context, new Title{Description = description});
            var newDescription = RandomUtil.GetRandomAlphaNumericString(30);
            title.Description = newDescription;
            TitleCommands.SaveTitle(Context, title);
            Assert.AreNotEqual(description, title.Description);
            Assert.AreEqual(newDescription, title.Description);

        }
    }


}

using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
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

            var titleDb = TitleQueries.GetTitleById(Context, title.IdTitle);
            Assert.AreNotEqual(description, titleDb.Description);
            Assert.AreEqual(newDescription, titleDb.Description);

        }
    }


}

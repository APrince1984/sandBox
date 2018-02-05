using System.Linq;
using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public class TitleQueriesTests : DataTestBase
    {
        [Test]
        public void GetTitleById_IdDoesNotExist_ReturnsNull()
        {
            Assert.IsNull(TitleQueries.GetTitleById(Context, -1));
        }

        [Test]
        public void GetTitleById_TitleExists_ReturnsTitle()
        {
            var title = TitleCommands.SaveTitle(Context, new Title{Description = RandomUtil.GetRandomString()});
            Assert.IsNotNull(TitleQueries.GetTitleById(Context, title.IdTitle));
        }

        [Test]
        public void GetTitleByPartOfDescription_ReturnsListOfTitles()
        {
            var description = RandomUtil.GetRandomString(25);
            TitleCommands.SaveTitle(Context, new Title {Description = description});
            var titles = TitleQueries.GetTitlesByPartOfDescription(Context,
                description.Substring(RandomUtil.GetRandomNumber(1), RandomUtil.GetRandomNumber(1) + 1));
            Assert.IsNotEmpty(titles);
            Assert.IsNotNull(titles.Where(t => t.Description.Contains(description)));
        }
    }
}

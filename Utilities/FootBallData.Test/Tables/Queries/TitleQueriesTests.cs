using System.Linq;
using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public class TitleQueriesTests : QueriesBaseTests
    {
        [Test]
        public override void GetEntityById_EntityDoesExist_ReturnsEntity()
        {
            var title = TitleCommands.SaveTitle(new Title { Description = RandomUtil.GetRandomString() }, Context);
            Assert.IsNotNull(TitleQueries.GetTitleById(Context, title.IdTitle));
        }

        [Test]
        public override void GetEntityById_EntityDoesNotExist_ReturnsNull()
        {
            Assert.IsNull(TitleQueries.GetTitleById(Context, -1));
        }
        
        [Test]
        public void GetTitleByPartOfDescription_ReturnsListOfTitles()
        {
            var description = RandomUtil.GetRandomString(25);
            TitleCommands.SaveTitle(new Title { Description = description }, Context);
            var titles = TitleQueries.GetTitlesByPartOfDescription(Context,
                description.Substring(RandomUtil.GetRandomNumber(1), RandomUtil.GetRandomNumber(1) + 1));
            Assert.IsNotEmpty(titles);
            Assert.IsNotNull(titles.Where(t => t.Description.Contains(description)));
        }
    }
}

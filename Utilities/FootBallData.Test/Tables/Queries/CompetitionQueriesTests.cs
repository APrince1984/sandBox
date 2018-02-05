using System.Linq;
using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public class CompetitionQueriesTests : QueriesBaseTests
    {
        [Test]
        public void GetCompetitionByPartOfName_ReturnsListOfCompetitions()
        {
            var name = RandomUtil.GetRandomString(30);
            CompetitionCommands.SaveCompetition(Context,
                new Competition {Name = name, Description = RandomUtil.GetRandomString(150)});
            var competitions = CompetitionQueries.GetCompetitionByPartOfName(Context,
                name.Substring(RandomUtil.GetRandomNumber(1), RandomUtil.GetRandomNumber(1) + 1));
            Assert.IsNotEmpty(competitions);
            Assert.IsNotNull(competitions.FirstOrDefault(c => c.Name == name));
        }

        [Test]
        public void GetCompetitionByPartOfDescription_ReturnsListOfCompetitions()
        {
            var description = RandomUtil.GetRandomString(200);
            CompetitionCommands.SaveCompetition(Context,
                new Competition { Name = RandomUtil.GetRandomString(30), Description = description });
            var competitions = CompetitionQueries.GetCompetitionByPartOfDescription(Context,
                description.Substring(RandomUtil.GetRandomNumber(1), RandomUtil.GetRandomNumber(2) + 1));
            Assert.IsNotEmpty(competitions);
            Assert.IsNotNull(competitions.FirstOrDefault(c => c.Description == description));
        }

        [Test]
        public override void GetEntityById_EntityDoesNotExist_ReturnsNull()
        {
            Assert.IsNull(CompetitionQueries.GetCompetitionById(Context, -1));
        }

        [Test]
        public override void GetEntityById_EntityDoesExist_ReturnsEntity()
        {
            var competition = CompetitionCommands.SaveCompetition(Context,
                new Competition { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(150) });
            Assert.IsNotNull(CompetitionQueries.GetCompetitionById(Context, competition.IdCompetition));
        }
    }
}

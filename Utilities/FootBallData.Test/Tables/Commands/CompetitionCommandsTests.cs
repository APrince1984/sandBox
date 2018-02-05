using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Commands
{
    [TestFixture]
    public class CompetitionCommandsTests : DataTestBase
    {
        [Test]
        public void SaveCompetition_CompetitionIsNew_CompetitionIsCreated()
        {
            var competition = CompetitionCommands.SaveCompetition(Context,
                new Competition {Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(100)});
            Assert.IsNotNull(competition.IdCompetition);
        }

        [Test]
        public void SaveCompetition_CompetitionExists_CompetitionIsUpdated()
        {
            var name = RandomUtil.GetRandomString();
            var description = RandomUtil.GetRandomString(100);
            var competition =
                CompetitionCommands.SaveCompetition(Context, new Competition {Name = name, Description = description});
            var newName = RandomUtil.GetRandomString();
            var newDescription = RandomUtil.GetRandomString(100);
            competition.Name = newName;
            competition.Description = newDescription;
            CompetitionCommands.SaveCompetition(Context, competition);

            var competitionDb = CompetitionQueries.GetCompetitionById(Context, competition.IdCompetition);
            Assert.IsNotNull(competitionDb);
            Assert.AreNotEqual(name, competitionDb.Name);
            Assert.AreNotEqual(description, competitionDb.Description);
            Assert.AreEqual(newName, competitionDb.Name);
            Assert.AreEqual(newDescription, competitionDb.Description);
        }
    }
}

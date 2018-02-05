using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Commands
{
    [TestFixture]
    public class SerieCommandsTests : CommandsBaseTests
    {
        [Test]
        public override void SaveEntity_EntityExists_EntityIsUpdated()
        {
            var competition = CreateCompetition();
            var serie = SerieCommands.SaveSerie(new Serie { Description = RandomUtil.GetRandomString(), IdCompetition = competition.IdCompetition }, Context);
            Assert.IsNotNull(serie);

            var teamsToPromote = RandomUtil.GetRandomNumber(1);
            serie.TeamsPromote = teamsToPromote;
            serie.SaveSerie(Context);

            var serieDb = SerieQueries.GetSerieById(Context, serie.IdSerie);
            Assert.IsNotNull(serieDb.TeamsPromote);
            Assert.AreEqual(teamsToPromote, serieDb.TeamsPromote);
        }

        [Test]
        public override void SaveEntity_EntityIsNew_EntityIsCreated()
        {
            var competition = CreateCompetition();
            var serie = SerieCommands.SaveSerie(new Serie{Description = RandomUtil.GetRandomString(), IdCompetition = competition.IdCompetition}, Context);
            Assert.IsNotNull(serie.IdSerie);
        }

        private Competition CreateCompetition()
        {
            return CompetitionCommands.SaveCompetition(
                new Competition {Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(150)},
                Context);
        }
    }
}

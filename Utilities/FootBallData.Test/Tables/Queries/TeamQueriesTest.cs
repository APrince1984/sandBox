using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public class TeamQueriesTest : QueriesBaseTest
    {
        [Test]
        public override void GetEntityById_EntityDoesExist_ReturnsEntity()
        {
            var name = RandomUtil.GetRandomString();
            var team = TeamCommands.SaveTeam(new Team{Description = RandomUtil.GetRandomString(200), Name = name}, Context);
            var teamDb = TeamQueries.GetTeamById(Context, team.IdTeam);
            Assert.IsNotNull(teamDb);
            Assert.AreEqual(name, teamDb.Name);
        }

        [Test]
        public override void GetEntityById_EntityDoesNotExist_ReturnsNull()
        {
            Assert.IsNull(TeamQueries.GetTeamById(Context, -1));
        }

        [Test]
        public void GetTeamsByIdSerie_NoTeamsForThatSerieExist_ReturnsEmptyList()
        {
            Assert.IsEmpty(TeamQueries.GetTeamsByIdSerie(Context, -1));
        }

        [Test]
        public void GetTeamsByIdSerie_TeamsForThatSerieExist_ReturnsTeamList()
        {
            var serie = SerieCommands.SaveSerie(new Serie {Description = RandomUtil.GetRandomString()}, Context);
            TeamCommands.SaveTeam(new Team { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(), IdSerie = serie.IdSerie }, Context);
            TeamCommands.SaveTeam(new Team { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(), IdSerie = serie.IdSerie }, Context);
            var teams = TeamQueries.GetTeamsByIdSerie(Context, serie.IdSerie);
            Assert.IsNotNull(teams);
            Assert.AreEqual(2, teams.Count);
        }

        [Test]
        public void GetTeamsByIdCompetition_TeamsForThatCompetitionDoesNotExist_ReturnsEmptyList()
        {
            Assert.IsEmpty(TeamQueries.GetTeamsByIdCompetition(Context, -1));
        }

        [Test]
        public void GetTeamsByIdCompetition_TeamsForThatCompetitionExist_ReturnsTeamList()
        {
            var competition = CompetitionCommands.SaveCompetition(new Competition{Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(100)}, Context);
            var serie1 = SerieCommands.SaveSerie(new Serie { Description = RandomUtil.GetRandomString(), IdCompetition = competition.IdCompetition}, Context);
            var serie2 = SerieCommands.SaveSerie(new Serie { Description = RandomUtil.GetRandomString(), IdCompetition = competition.IdCompetition }, Context);
            TeamCommands.SaveTeam(new Team { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(), IdSerie = serie1.IdSerie }, Context);
            TeamCommands.SaveTeam(new Team { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(), IdSerie = serie1.IdSerie }, Context);
            TeamCommands.SaveTeam(new Team { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(), IdSerie = serie2.IdSerie }, Context);
            TeamCommands.SaveTeam(new Team { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(), IdSerie = serie2.IdSerie }, Context);

            var teams = TeamQueries.GetTeamsByIdCompetition(Context, competition.IdCompetition);
            Assert.IsNotNull(teams);
            Assert.AreEqual(4, teams.Count);
        }
    }
}

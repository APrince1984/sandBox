using System.Linq;
using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public class SerieQueriesTests : QueriesBaseTests
    {
        [Test]
        public override void GetEntityById_EntityDoesExist_ReturnsEntity()
        {
            var competition = CompetitionCommands.SaveCompetition(new Competition { Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(150) }, Context);
            var serie = SerieCommands.SaveSerie(
                new Serie {Description = RandomUtil.GetRandomString(), IdCompetition = competition.IdCompetition},
                Context);
            Assert.IsNotNull(serie.IdSerie);

        }

        [Test]
        public override void GetEntityById_EntityDoesNotExist_ReturnsNull()
        {
            Assert.IsNull(SerieQueries.GetSerieById(Context, -1));
        }

        [Test]
        public void GetSeriesByIdCompetition_NoSeriesForThatIdExist_ReturnsEmptyList()
        {
            Assert.IsEmpty(SerieQueries.GetSeriesByIdCompetition(Context, -1));
        }

        [Test]
        public void GetSeriesByIdCompetition_SeriesForThatIdExist_ReturnsAllSeries()
        {
            var competition = CompetitionCommands.SaveCompetition(
                new Competition {Name = RandomUtil.GetRandomString(), Description = RandomUtil.GetRandomString(150)},
                Context);

            SerieCommands.SaveSerie(new Serie { Description = RandomUtil.GetRandomString(), IdCompetition = competition.IdCompetition}, Context);
            SerieCommands.SaveSerie(new Serie { Description = RandomUtil.GetRandomString(), IdCompetition = competition.IdCompetition }, Context);

            var series = SerieQueries.GetSeriesByIdCompetition(Context, competition.IdCompetition);
            Assert.IsNotNull(series);
            Assert.AreEqual(2, series.Count);
        }

        [Test]
        public void GetSeriesByPartOfDescription_ReturnsListOfSeries()
        {
            var description = RandomUtil.GetRandomString(30);
            SerieCommands.SaveSerie(new Serie { Description = description }, Context);
            var series = SerieQueries.GetSeriesByPartOfDescription(Context,
                description.Substring(RandomUtil.GetRandomNumber(1), RandomUtil.GetRandomNumber(1) + 1));
            Assert.IsNotNull(series);
            Assert.IsNotNull(series.FirstOrDefault(s => s.Description == description));
        }
    }
}

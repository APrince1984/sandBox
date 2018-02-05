using System.Collections.Generic;
using System.Linq;

namespace FootBallData.Tables.Queries
{
    public static class TeamQueries
    {
        public static Team GetTeamById(FootBallContext context, int idTeam)
        {
            return context.Teams.FirstOrDefault(t => t.IdTeam == idTeam);
        }

        public static List<Team> GetTeamsByIdSerie(FootBallContext context, int idSerie)
        {
            return context.Teams.Where(t => t.IdSerie == idSerie).ToList();
        }

        public static List<Team> GetTeamsByIdCompetition(FootBallContext context, int idCompetition)
        {
            var series = SerieQueries.GetSeriesByIdCompetition(context, idCompetition).Select(s => (int?) s.IdSerie).ToList();
            if (series.Any())
                return context.Teams.Where(t => t.IdSerie != null && series.Contains(t.IdSerie)).ToList();

            return new List<Team>();
        }
    }
}

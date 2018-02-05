using System.Collections.Generic;
using System.Linq;

namespace FootBallData.Tables.Queries
{
    public static class SerieQueries
    {
        public static Serie GetSerieById(FootBallContext context, int idSerie)
        {
            return context.Series.FirstOrDefault(s => s.IdSerie == idSerie);
        }

        public static List<Serie> GetSeriesByIdCompetition(FootBallContext context, int idCompetition)
        {
            return context.Series.Where(s => s.IdCompetition == idCompetition).ToList();
        }

        public static List<Serie> GetSeriesByPartOfDescription(FootBallContext context, string description)
        {
            return context.Series.Where(s => s.Description.Contains(description)).ToList();
        }
    }
}

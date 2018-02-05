using System.Collections.Generic;
using System.Linq;

namespace FootBallData.Tables.Queries
{
    public static class CompetitionQueries
    {
        public static Competition GetCompetitionById(FootBallContext context, int idCompetition)
        {
            return context.Competitions.FirstOrDefault(c => c.IdCompetition == idCompetition);
        }

        public static List<Competition> GetCompetitionByPartOfName(FootBallContext context, string name)
        {
            return context.Competitions.Where(c => c.Name.Contains(name)).ToList();
        }

        public static List<Competition> GetCompetitionByPartOfDescription(FootBallContext context, string description)
        {
            return context.Competitions.Where(c => c.Description.Contains(description)).ToList();
        }
    }
}

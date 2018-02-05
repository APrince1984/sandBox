using System.Collections.Generic;
using System.Linq;

namespace FootBallData.Tables.Queries
{
    public static class TitleQueries
    {
        public static Title GetTitleById(FootBallContext context, int idTitle)
        {
            return context.Titles.FirstOrDefault(t => t.IdTitle == idTitle);
        }

        public static List<Title> GetTitlesByPartOfDescription(FootBallContext context, string description)
        {
            return context.Titles.Where(t => t.Description.Contains(description)).ToList();
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace FootBallData.Tables.Queries
{
    public static class PersonTitleQueries
    {
        public static PersonTitle GetPersonTitleByAllIds(FootBallContext context, int idTitle, int idPerson,
            int? idTeam = null)
        {
            return context.PersonTitles.FirstOrDefault(pt =>
                pt.IdPerson == idPerson && pt.IdTitle == idTitle && pt.IdTeam == idTeam);
        }

        public static List<PersonTitle> GetAllPersonsTitlesByIdTitle(FootBallContext context, int idTitle)
        {
            return context.PersonTitles.Where(pt => pt.IdTitle == idTitle).ToList();
        }

        public static List<PersonTitle> GetAllPersonsTitlesByIdPerson(FootBallContext context, int idPerson)
        {
            return context.PersonTitles.Where(pt => pt.IdPerson == idPerson).ToList();
        }

        public static List<PersonTitle> GetAllPersonsTitlesByIdTeam(FootBallContext context, int idTeam)
        {
            return context.PersonTitles.Where(pt => pt.IdTeam == idTeam).ToList();
        }
    }
}

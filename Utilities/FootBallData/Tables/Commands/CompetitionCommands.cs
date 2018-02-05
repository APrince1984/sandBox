using System.Data.Entity.Migrations;

namespace FootBallData.Tables.Commands
{
    public static class CompetitionCommands
    {
        public static Competition SaveCompetition(FootBallContext context, Competition competition)
        {
            context.Competitions.AddOrUpdate(competition);
            context.SaveChanges();
            return competition;
        }
    }
}

using System.Data.Entity.Migrations;

namespace FootBallData.Tables.Commands
{
    public static class CompetitionCommands
    {
        public static Competition SaveCompetition(this Competition competition, FootBallContext context)
        {
            context.Competitions.AddOrUpdate(competition);
            context.SaveChanges();
            return competition;
        }
    }
}

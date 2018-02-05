using System.Data.Entity.Migrations;

namespace FootBallData.Tables.Commands
{
    public static class TeamCommands
    {
        public static Team SaveTeam(this Team team, FootBallContext context)
        {
            context.Teams.AddOrUpdate(team);
            context.SaveChanges();
            return team;
        }
    }
}

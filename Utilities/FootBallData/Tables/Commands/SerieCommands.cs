using System.Data.Entity.Migrations;

namespace FootBallData.Tables.Commands
{
    public static class SerieCommands
    {
        public static Serie SaveSerie(this Serie serie, FootBallContext context)
        {
            context.Series.AddOrUpdate(serie);
            context.SaveChanges();
            return serie;
        }
    }
}

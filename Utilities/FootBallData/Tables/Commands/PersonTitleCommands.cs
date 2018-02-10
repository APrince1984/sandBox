using System.Data.Entity.Migrations;

namespace FootBallData.Tables.Commands
{
    public static class PersonTitleCommands
    {
        public static PersonTitle SavePersonTitle(this PersonTitle personTitle, FootBallContext context)
        {
            context.PersonTitles.AddOrUpdate(personTitle);
            context.SaveChanges();
            return personTitle;
        }
    }
}

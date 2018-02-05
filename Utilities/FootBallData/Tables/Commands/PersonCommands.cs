using System.Data.Entity.Migrations;

namespace FootBallData.Tables.Commands
{
    public static class PersonCommands
    {
        public static Person SavePerson(this Person person, FootBallContext context)
        {
            context.Persons.AddOrUpdate(person);
            context.SaveChanges();
            return person;
        }
    }
}
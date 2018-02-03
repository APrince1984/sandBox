using System.Data.Entity.Migrations;

namespace FootBallData.Tables.Commands
{
    public static class PersonCommands
    {
        public static Person SavePerson(FootBallContext context, Person person)
        {
            context.Persons.AddOrUpdate(person);
            context.SaveChanges();
            return person;
        }
    }
}
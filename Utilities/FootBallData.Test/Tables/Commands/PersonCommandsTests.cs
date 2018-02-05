using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Commands
{
    [TestFixture]
    public class PersonCommandsTests : CommandsBaseTests
    {
        [Test]
        public override void SaveEntity_EntityIsNew_EntityIsCreated()
        {
            var person = CreatePerson();

            person = PersonCommands.SavePerson(Context, person);
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.IdPerson);
        }

        [Test]
        public override void SaveEntity_EntityExists_EntityIsUpdated()
        {
            var person = CreatePerson();

            person = PersonCommands.SavePerson(Context, person);
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.IdPerson);

            var previousFirstName = person.FirstName;
            var newFirstName = RandomUtil.GetRandomString(15);
            person.FirstName = newFirstName;
            person = PersonCommands.SavePerson(Context, person);

            var personDb = PersonQueries.GetPersonById(Context, person.IdPerson);
            Assert.AreNotEqual(previousFirstName, personDb.FirstName);
            Assert.AreEqual(newFirstName, personDb.FirstName);
        }

        private static Person CreatePerson()
        {
            return new Person
            {
                FirstName = RandomUtil.GetRandomString(),
                LastName = RandomUtil.GetRandomString(),
                BirthDate = RandomUtil.GetRandomDateInThePast(1)
            };
        }
    }
}

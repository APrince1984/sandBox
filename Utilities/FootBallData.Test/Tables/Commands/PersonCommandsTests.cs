using FootBallData.Tables;
using FootBallData.Tables.Commands;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Commands
{
    [TestFixture]
    public class PersonCommandsTests : DataTestBase
    {
        [Test]
        public void SavePerson_PersonIsNew_PersonIsSaved()
        {
            var person = CreatePerson();
                
            person = PersonCommands.SavePerson(Context, person);
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.IdPerson);
        }

        [Test]
        public void SavePerson_PersonExists_PersonIsUpdate()
        {
            var person = CreatePerson();
                
            person = PersonCommands.SavePerson(Context, person);
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.IdPerson);

            var previousFirstName = person.FirstName;
            var newFirstName = RandomUtil.GetRandomString(15);
            person.FirstName = newFirstName;
            person = PersonCommands.SavePerson(Context, person);
            Assert.AreNotEqual(previousFirstName, person.FirstName);
            Assert.AreEqual(newFirstName, person.FirstName);
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

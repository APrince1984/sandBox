using System;
using System.Linq;
using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public class PersonQueriesTests : DataTestBase
    {
        [Test]
        public void GetPersonById_PersonDoesNotExist_ReturnsNull()
        {
            Assert.IsNull(PersonQueries.GetPersonById(Context, -1));
        }

        [Test]
        public void GetPersonById_PersonExists_ReturnsPerson()
        {
            var person = CreatePerson();
            Assert.IsNotNull(PersonQueries.GetPersonById(Context, person.IdPerson));
        }

        [Test]
        public void GetPersonByParthOfName_ReturnsListOfPersons_withExpectedFirstName()
        {
            var firstName = RandomUtil.GetRandomString(15);
            CreatePerson(firstName);

            var persons = PersonQueries.GetPersonsByParthOfName(Context, firstName.Substring(8));
            Assert.IsNotNull(persons);
            Assert.IsNotNull(persons.Where(p => p.FirstName == firstName));
        }

        [Test]
        public void GetPersonByParthOfName_ReturnsListOfPersons_withExpectedLastName()
        {
            var lastName = RandomUtil.GetRandomString(15);
            CreatePerson(RandomUtil.GetRandomString(), lastName);

            var persons = PersonQueries.GetPersonsByParthOfName(Context, lastName.Substring(8));
            Assert.IsNotNull(persons);
            Assert.IsNotNull(persons.Where(p => p.LastName == lastName));
        }

        [Test]
        public void GetPersonsBetweenBirthDates_NoPersonOnThatDayBorn_ReturnsEmptyList()
        {
            var bDate = RandomUtil.GetRandomDateInTheFuture(1);     // Person will never have a birthday in the future ;p
            Assert.IsEmpty(PersonQueries.GetPersonsBetweenBirthDates(Context, bDate));
        }

        [Test]
        public void GetPersonsBetweenBirthDates_PersonBornOnThatDay_ReturnsThatPersonInTheList()
        {
            var bDate = RandomUtil.GetRandomDateInThePast(1);     
            var person = CreatePerson(RandomUtil.GetRandomString(), RandomUtil.GetRandomString(), bDate);

            var persons = PersonQueries.GetPersonsBetweenBirthDates(Context, bDate);
            Assert.IsNotEmpty(persons);
            Assert.IsTrue(persons.Contains(person));
        }

        [Test]
        public void GetPersonsBetweenBirthDates_TwoDatesGiven_ReturnsPersons()
        {
            var bDate1 = RandomUtil.GetRandomDateInThePast(1);
            var person1 = CreatePerson(RandomUtil.GetRandomString(), RandomUtil.GetRandomString(), bDate1);
            var bDate2 = RandomUtil.GetRandomDateInThePast(1);
            var person2 = CreatePerson(RandomUtil.GetRandomString(), RandomUtil.GetRandomString(), bDate2);

            SwitchDatesIfNeeded(ref bDate2, ref bDate1);

            var persons = PersonQueries.GetPersonsBetweenBirthDates(Context, bDate1, bDate2);
            Assert.IsNotEmpty(persons);
            Assert.IsTrue(persons.Contains(person1));
            Assert.IsTrue(persons.Contains(person2));
        }

        [Test]
        public void GetPersonsBetweenDates_TwoDatesGiven_SecondDateSmallerThenFirst_ThrowsException()
        {
            var bDate1 = RandomUtil.GetRandomDateInThePast(1);
            var bDate2 = bDate1.AddDays(-1);
            Assert.Throws<Exception>(() => PersonQueries.GetPersonsBetweenBirthDates(Context, bDate1, bDate2));
        }

        private Person CreatePerson(string firstName = null, string lastName = null, DateTime? bDate = null)
        {
            return PersonCommands.SavePerson(Context,
                new Person
                {
                    FirstName = firstName ?? RandomUtil.GetRandomString(),
                    LastName = lastName ?? RandomUtil.GetRandomString(),
                    BirthDate = bDate ?? RandomUtil.GetRandomDateInThePast(1)
                });
        }

        private static void SwitchDatesIfNeeded(ref DateTime bDate2, ref DateTime bDate1)
        {
            if (bDate2 >= bDate1)
                return ;
            
            var bDate = bDate2;
            bDate2 = bDate1;
            bDate1 = bDate;
        }
    }
}

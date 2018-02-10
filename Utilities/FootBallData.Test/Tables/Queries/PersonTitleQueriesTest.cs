using System.Linq;
using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using FootBallData.Test.Tables.ObjectCreators;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Queries
{
    [TestFixture]
    public class PersonTitleQueriesTest : QueriesBaseTest
    {
        [Test]
        public override void GetEntityById_EntityDoesExist_ReturnsEntity()
        {
            PersonTitleCreator.CreatePersonTitle(Context, out var person, out var title);

            var personTitle = PersonTitleQueries.GetPersonTitleByAllIds(Context, title.IdTitle, person.IdPerson);
            Assert.IsNotNull(personTitle);
            Assert.AreEqual(person, personTitle.PersonTitlePerson);
            Assert.AreEqual(title, personTitle.PersonTitleTitle);
        }

        [Test]
        public override void GetEntityById_EntityDoesNotExist_ReturnsNull()
        {
            Assert.IsNull(PersonTitleQueries.GetPersonTitleByAllIds(Context, -1, -1));
        }

        [Test]
        public void GetPersonTitlesByIdPerson_PersonTitleExists_ReturnsList()
        {
            PersonTitleCreator.CreatePersonTitle(Context, out var person, out var title);
            var personTitles = PersonTitleQueries.GetAllPersonsTitlesByIdPerson(Context, person.IdPerson);
            Assert.IsTrue(personTitles.Any());
            Assert.IsNotNull(personTitles.FirstOrDefault(pt => pt.IdPerson == person.IdPerson));
        }

        [Test]
        public void GetPersonTitlesByIdPerson_PersonTitleDoesNotExists_ReturnsEmptyList()
        {
            Assert.IsEmpty(PersonTitleQueries.GetAllPersonsTitlesByIdPerson(Context, -1));
        }

        [Test]
        public void GetPersonTitlesByIdTitle_PersonTitleExists_ReturnsList()
        {
            PersonTitleCreator.CreatePersonTitle(Context, out var person, out var title);
            var personTitles = PersonTitleQueries.GetAllPersonsTitlesByIdTitle(Context, title.IdTitle);
            Assert.IsTrue(personTitles.Any());
            Assert.IsNotNull(personTitles.FirstOrDefault(pt => pt.IdTitle == title.IdTitle));
        }

        [Test]
        public void GetPersonTitlesByIdTitle_PersonTitleDoesNotExists_ReturnsEmptyList()
        {
            Assert.IsEmpty(PersonTitleQueries.GetAllPersonsTitlesByIdTitle(Context, -1));
        }

        [Test]
        public void GetPersonTitlesByIdTeam_PersonTitleExists_ReturnsList()
        {
            PersonTitleCreator.CreatePersonTitle(Context, out var person, out var title, out var team);
            
            var personTitles = PersonTitleQueries.GetAllPersonsTitlesByIdTeam(Context, team.IdTeam);
            Assert.IsTrue(personTitles.Any());
            Assert.IsNotNull(personTitles.FirstOrDefault(pt => pt.IdTeam == team.IdTeam));
        }

        [Test]
        public void GetPersonTitlesByIdTeam_PersonTitleDoesNotExists_ReturnsEmptyList()
        {
            Assert.IsEmpty(PersonTitleQueries.GetAllPersonsTitlesByIdTeam(Context, -1));
        }

        
    }
}

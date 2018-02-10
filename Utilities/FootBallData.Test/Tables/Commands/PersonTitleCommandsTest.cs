using FootBallData.Tables;
using FootBallData.Tables.Commands;
using FootBallData.Tables.Queries;
using FootBallData.Test.Tables.ObjectCreators;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.Commands
{
    [TestFixture]
    public class PersonTitleCommandsTest : CommandsBaseTest
    {
        [Test]
        public override void SaveEntity_EntityExists_EntityIsUpdated()
        {
            var personTitle = PersonTitleCreator.CreatePersonTitle(Context, out var person, out var title);
            var team = TeamCommands.SaveTeam(new Team {Description = RandomUtil.GetRandomString(), Name = RandomUtil.GetRandomString()}, Context);
            personTitle.IdTeam = team.IdTeam;
            personTitle.SavePersonTitle(Context);
            using (var context = new FootBallContext())
            {
                var personTitleDb = PersonTitleQueries.GetAllPersonsTitlesByIdTeam(context, team.IdTeam);
                Assert.IsNotNull(personTitleDb);
            }

        }

        [Test]
        public override void SaveEntity_EntityIsNew_EntityIsCreated()
        {
            var person = PersonCommands.SavePerson(new Person
            {
                FirstName = RandomUtil.GetRandomString(),
                LastName = RandomUtil.GetRandomString()
            }, Context);
            var title = TitleCommands.SaveTitle(new Title {Description = RandomUtil.GetRandomString()}, Context);
            var personTitle = PersonTitleCommands.SavePersonTitle(new PersonTitle{IdPerson = person.IdPerson, IdTitle = title.IdTitle}, Context);
            Assert.IsNotNull(personTitle);
        }
    }
}


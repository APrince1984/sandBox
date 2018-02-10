using FootBallData.Tables;
using FootBallData.Tables.Commands;
using NUnit.Framework;
using Utilities;

namespace FootBallData.Test.Tables.ObjectCreators
{
    public static class PersonTitleCreator
    {
        public static PersonTitle CreatePersonTitle(FootBallContext context, out Person person, out Title title)
        {
            person = PersonCommands.SavePerson(
                new Person { FirstName = RandomUtil.GetRandomString(), LastName = RandomUtil.GetRandomString() },
                context);
            Assert.IsNotNull(person);

            title = TitleCommands.SaveTitle(new Title { Description = RandomUtil.GetRandomString() }, context);
            Assert.IsNotNull(title);

            return PersonTitleCommands.SavePersonTitle(new PersonTitle { IdPerson = person.IdPerson, IdTitle = title.IdTitle },
                context);
        }

        public static PersonTitle CreatePersonTitle(FootBallContext context, out Person person, out Title title, out Team team)
        {
            person = PersonCommands.SavePerson(
                new Person { FirstName = RandomUtil.GetRandomString(), LastName = RandomUtil.GetRandomString() },
                context);
            Assert.IsNotNull(person);

            title = TitleCommands.SaveTitle(new Title { Description = RandomUtil.GetRandomString() }, context);
            Assert.IsNotNull(title);

            team = TeamCommands.SaveTeam(
                new Team { Description = RandomUtil.GetRandomString(100), Name = RandomUtil.GetRandomString() }, context);

            return PersonTitleCommands.SavePersonTitle(new PersonTitle { IdPerson = person.IdPerson, IdTitle = title.IdTitle, IdTeam = team.IdTeam },
                context);
        }
    }
}

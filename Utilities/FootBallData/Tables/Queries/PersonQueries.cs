using System;
using System.Collections.Generic;
using System.Linq;

namespace FootBallData.Tables.Queries
{
    public static class PersonQueries
    {
        public static Person GetPersonById(FootBallContext context, int idPerson)
        {
            return context.Persons.FirstOrDefault(p => p.IdPerson == idPerson);
        }

        public static List<Person> GetPersonsByParthOfName(FootBallContext context, string name)
        {
            return context.Persons.Where(p => p.FirstName.Contains(name) || p.FirstName.Contains(name)).ToList();
        }

        public static List<Person> GetPersonsBetweenBirthDates(FootBallContext context, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate == null)
                startDate = DateTime.Today;

            if (endDate == null)
                endDate = startDate.Value.AddDays(1);

            if(startDate > endDate)
                throw new Exception("EndDate has to be bigger then startdate");

            return context.Persons.Where(p => p.BirthDate >= startDate && p.BirthDate <= endDate).ToList();
        }
    }
}
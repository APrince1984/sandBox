using System;
using FootBallData.Tables;
using System.Data.Entity;
using System.Configuration;

//using Microsoft.EntityFrameworkCore;

namespace FootBallData
{
    public class FootBallContext : DbContext
    {
        public FootBallContext() : base()
        {
            var aaa = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            var bbb = ConfigurationManager.ConnectionStrings;
            var ccc = bbb.Count;
        }

        public DbSet<Person> Persons { get; set; }
    }
}

using FootBallData.Tables;
using System.Data.Entity;

//using Microsoft.EntityFrameworkCore;

namespace FootBallData
{
    public class FootBallContext : DbContext
    {
        private const string _connectionString = @"Data Source=DIRK-PC\SQLEXPRESS; Initial Catalog=FootBall; User id=FootBallData; Password=test123";

        public FootBallContext() : base(_connectionString)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootBallData.Tables
{
    [Table("Person", Schema = "dbo")]
    public class Person
    {
        [Column("ID_Person"), Key]
        public int IdPerson { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("BirthDate")]
        public DateTime? BirthDate { get; set; }
        
    }
}

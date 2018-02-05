using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootBallData.Tables
{
    [Table("Competition", Schema = "dbo")]
    public class Competition
    {
        [Column("ID_Competition"), Key]
        public int IdCompetition { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootBallData.Tables
{
    [Table("Team", Schema = "dbo")]
    public class Team
    {
        [Column("ID_Team"), Key]
        public int IdTeam { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("ID_Serie"), ForeignKey("TeamSerie")]
        public int? IdSerie { get; set; }

        public virtual Serie TeamSerie { get; set; }
    }
}

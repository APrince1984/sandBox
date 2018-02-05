using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootBallData.Tables
{
    [Table("Serie", Schema = "dbo")]
    public class Serie
    {
        [Column("ID_Serie"), Key]
        public int IdSerie { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("TeamsPromote")]
        public int? TeamsPromote { get; set; }

        [Column("TeamsDegradate")]
        public int? TeamsDegradate { get; set; }

        [Column("ID_Competition"), ForeignKey("SerieCompetition")]
        public int? IdCompetition { get; set; }

        public virtual Competition SerieCompetition { get; set; }
    }
}

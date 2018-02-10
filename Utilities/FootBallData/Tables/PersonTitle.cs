using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootBallData.Tables
{
    [Table("PersonTitle", Schema = "dbo")]
    public class PersonTitle
    {
        [Column("ID_Person", Order = 1), Key, ForeignKey("PersonTitlePerson")]
        public int IdPerson { get; set; }

        public virtual Person PersonTitlePerson { get; set; }

        [Column("ID_Title", Order = 2), Key, ForeignKey("PersonTitleTitle")]
        public int IdTitle { get; set; }

        public virtual Title PersonTitleTitle { get; set; }

        [Column("ID_Team"), ForeignKey("PersonTitleTeam")]
        public int? IdTeam { get; set; }

        public virtual Team PersonTitleTeam { get; set; }
        
    }
}

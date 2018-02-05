using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootBallData.Tables
{
    [Table("Title", Schema = "dbo")]
    public class Title
    {
        [Column("ID_Title"), Key]
        public int IdTitle { get; set; }

        [Column("Description")]
        public string Description { get; set; }
        
    }
}

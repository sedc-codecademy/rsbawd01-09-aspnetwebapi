using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public int Tag { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}

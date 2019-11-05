using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Data.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { set; get; }

        [Required]
        public string AdminLogin { set; get; }
        [Required]
        public string AdminPass { set; get; }

    }
}

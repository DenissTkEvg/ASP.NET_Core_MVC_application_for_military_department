using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Data.Models
{
    public class Specialty
    {
        [Key]
        public int SpecialtyId { set; get; }
        [Required]
        public string Name { set; get; }
        public virtual ICollection<Group> Groups { set; get; }
    }
}

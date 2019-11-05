using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ElectronicJournal.Data.Models
{
    public class Group
    {
        [Key]
        public int GroupId { set; get; }
        [Required]
        public string Name { set; get; }
   
        public int SpecialtyId { set; get; }
        public virtual Specialty Specialty { set; get; }

        public virtual ICollection<Student> Students { set; get; }

    }
}

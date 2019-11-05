using System.Collections.Generic;
using ElectronicJournal.Data.Models;
namespace ElectronicJournal.ViewModels
{
    public class ShowJournalViewModel
    {
        public List<Specialty> ListOfSpecialties { set;  get; }
        public List<Group> ListOfGroups { set; get; }
        public ShowJournalViewModel()
        {
            ListOfSpecialties = new List<Specialty>();
            ListOfGroups = new List<Group>();
        }
    }
}

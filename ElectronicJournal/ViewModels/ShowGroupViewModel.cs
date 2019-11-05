using ElectronicJournal.Data.Models;
using System.Collections.Generic;


namespace ElectronicJournal.ViewModels
{
    public class ShowGroupViewModel
    {
        public List<Student> ListOfGroupStudents { get; set; }
        public string GroupSpecialtyName { get; set; }
        public ShowGroupViewModel()
        {
            ListOfGroupStudents = new List<Student>();

        }
    }
}

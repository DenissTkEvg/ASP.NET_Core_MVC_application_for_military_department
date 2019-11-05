using ElectronicJournal.Data.Models;
using System.Collections.Generic;


namespace ElectronicJournal.ViewModels
{
    public class ResultOfSearchViewModel
    {
        public List<Student> ListOfStudents { get; }
        public string Message { set; get; }
        public ResultOfSearchViewModel()
        {
            ListOfStudents = new List<Student>();
        }
    }
}

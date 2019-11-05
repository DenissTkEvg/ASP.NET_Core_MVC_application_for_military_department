using ElectronicJournal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicJournal.ViewModels
{
    public class ShowStudentViewModel
    {
        public Student CurrentStudent { get; }
        public List<StudyEvent> EventsOfCurrentStudent { get; }
        public ShowStudentViewModel(Student student, List<StudyEvent> studyEvents)
        {
            CurrentStudent = student;
            EventsOfCurrentStudent = studyEvents;
        }
    }
}

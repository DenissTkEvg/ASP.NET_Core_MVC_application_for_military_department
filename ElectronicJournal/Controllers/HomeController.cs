using Microsoft.AspNetCore.Mvc;
using ElectronicJournal.Data.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using ElectronicJournal.ViewModels;
using System.Threading.Tasks;

namespace ElectronicJournal.Controllers
{
    public class HomeController : Controller
    {
        private ElJournalDBContext db;
        public HomeController(ElJournalDBContext context)
        {
            db = context;
        }
        public async Task<ViewResult> Index()
        {
            //TODO: Валидация ФИО
            var specialties =await db.Specialties.ToListAsync();
            var groups =await db.Groups.ToListAsync();
            var students =await db.Students.ToListAsync();
            ViewBag.Specialties = specialties;
            ViewBag.Groups = groups;
            ViewBag.Students = students;
            return View();
        }
        [HttpPost]
        public async Task<ViewResult> Index(Student person)
        {
            ResultOfSearchViewModel obj = new ResultOfSearchViewModel();
            //TODO: Валидация ФИО, Поиск по определнным параметрам (дополнить)
            var item = person.Group.Specialty.Name;
            if (String.Compare(item, "Выбор направления") == 0)
            {

                var student =await db.Students.Include(p => p.Group).FirstOrDefaultAsync(st => st.Name == person.Name && st.Surname == person.Surname && st.Patronymic == person.Patronymic && st.UniversityGroupName == person.UniversityGroupName && st.Group.Name == person.Group.Name);
                if (student != null) 
                { 
                    obj.ListOfStudents.Add(student);
                    return View("~/Views/Home/ResultOfSearch.cshtml", obj); 
                }
                else 
                {
                    obj.Message = "По результату запроса ничего не найдено";
                    return View("~/Views/Home/ErrorOfSearch.cshtml", obj);
                }
            }
            else
            {
               
                var student =await db.Students.Include(p => p.Group.Specialty).FirstOrDefaultAsync(st => st.Name == person.Name && st.Surname == person.Surname && st.Patronymic == person.Patronymic && st.UniversityGroupName == person.UniversityGroupName && st.Group.Name == person.Group.Name && st.Group.Specialty.Name == person.Group.Specialty.Name);
                if (student != null)
                {
                    obj.ListOfStudents.Add(student);
                    return View("~/Views/Home/ResultOfSearch.cshtml", obj);
                }
                else
                {
                    obj.Message = "По результату запроса ничего не найдено";
                    return View("~/Views/Home/ErrorOfSearch.cshtml", obj);
                }
            }

        }
        public async Task<ViewResult> ShowJournal()
        { 
            //TODO: Проверка на ошибки, исправление ViewModel
            ShowJournalViewModel obj = new ShowJournalViewModel();
            obj.ListOfGroups =await db.Groups.ToListAsync();
            obj.ListOfSpecialties =await db.Specialties.ToListAsync();
            return View(obj);
        }
        [HttpPost]
        public async Task<ViewResult> ShowJournal(Group group)
        {
            //TODO: Проверка на ошибки, исправление ViewModel
            var students = db.Students.Include(st => st.Group).Where(student => student.Group.Name == group.Name).OrderBy(o=>o.Surname);
            var specialtyName = db.Groups.Include(t=>t.Specialty).FirstOrDefault(n => n.Name == group.Name).Specialty.Name;
            var obj = new ShowGroupViewModel();
            obj.GroupSpecialtyName = specialtyName;
            obj.ListOfGroupStudents =await students.ToListAsync();
            return View("~/Views/Home/ShowGroupJournal.cshtml", obj);
        }
        public async Task<ViewResult> ShowStudent(int id)
        {
            //TODO: График, проверка на ошибки
            var student =await db.Students.Include(g => g.Group).Include(s => s.Group.Specialty).Include(l=>l.StudyEvents).FirstAsync(st => st.StudentId == id);
            var eventsListOfStudent = student.StudyEvents.OrderBy(o => o.EventDate).ToList();
            var obj = new ShowStudentViewModel(student, eventsListOfStudent);
            return View(obj);
        }

        //Временный метод для редактирования БД
        public string Add()
        {
            //var e = new StudyEvent()
            //{
            //    DescriptionOfEvent = "Дисциплина: ТСП-11; Тема: «Виды помех»; Оценка: 4",
            //    EventType = "Ответ на занятии.",
            //    EventDate = DateTime.Parse("19.10.2019"),
            //    Mark = 4,
            //    StudentId = 1
            //};
            //var e2 = new StudyEvent()
            //{
            //    DescriptionOfEvent = "Дисциплина ВСП-12; Оценка: Зачтено",
            //    EventType = "Зачет.",
            //    EventDate = DateTime.Parse("21.05.2019"),
            //    StudentId = 2
            //};
            //db.StudyEvents.Add(e);
            //db.StudyEvents.Add(e2);
            //db.SaveChanges();
            return "Добавлено.";
        }
    }

}


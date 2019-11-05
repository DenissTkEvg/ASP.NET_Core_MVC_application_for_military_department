using Microsoft.EntityFrameworkCore;


namespace ElectronicJournal.Data.Models
{
    public class ElJournalDBContext:DbContext
    {
        public ElJournalDBContext(DbContextOptions<ElJournalDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Admin> Admins { set; get; }
        public DbSet<Specialty> Specialties { set; get; }
        public DbSet<Group> Groups { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<StudyEvent> StudyEvents { set; get; }
    }
}

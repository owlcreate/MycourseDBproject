using Microsoft.EntityFrameworkCore;
using nscccoursemap_matchacode.Models;

namespace nscccoursemap_matchacode.Data
{
    public class NsccCourseMapDbContext : DbContext
    {
        public NsccCourseMapDbContext (
            DbContextOptions<NsccCourseMapDbContext> options)
            : base(options)
        {
        }

        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Course> Courses{ get; set; }

        public DbSet<Semester> Semesters{ get; set; }

        public DbSet<AdvisingAssignment> AdvisingAssignments { get; set; }

        public DbSet<DiplomaProgram> DiplomaPrograms{ get; set; }

        public DbSet<CourseOffering> CourseOfferings{ get; set; }

        public DbSet<CoursePrerequisite> CoursePrerequisites{ get; set; }

        public DbSet<DiplomaProgramYear> DiplomaProgramYears{ get; set; }

        public DbSet<DiplomaProgramYearSection> DiplomaProgramYearSections{ get; set; }

        public DbSet<Instructor> Instructors{ get; set; }


        // CUSTOM CONFIGURATION WITH FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Prerequisites)
                .WithOne(cpr => cpr.Course)
                .HasForeignKey(cpr => cpr.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.IsPrerequisiteFor)
                .WithOne(cpr => cpr.Prerequisite)
                .HasForeignKey(cpr => cpr.PrerequisiteId);

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique();

            modelBuilder.Entity<AcademicYear>()
                .HasIndex(c => c.Title)
                .IsUnique();

            modelBuilder.Entity<CourseOffering>()
                .HasIndex(o => new { o.CourseId, o.InstructorId, o.DiplomaProgramYearSectionId, o.SemesterId})
                .IsUnique();

            modelBuilder.Entity<AdvisingAssignment>()
                .HasIndex(o => new { o.InstructorId, o.DiplomaProgramYearSectionId})
                .IsUnique();
            modelBuilder.Entity<Semester>()
                .HasIndex(c => c.Name)
                .IsUnique();
            modelBuilder.Entity<DiplomaProgram>()
                .HasIndex(c => c.Title)
                .IsUnique();
            modelBuilder.Entity<DiplomaProgramYear>()
                .HasIndex(o => new { o.Title, o.DiplomaProgramId})
                .IsUnique();
            
            modelBuilder.Entity<CoursePrerequisite>()
                .HasIndex(o => new { o.CourseId, o.PrerequisiteId})
                .IsUnique();
            modelBuilder.Entity<DiplomaProgramYearSection>()
                .HasIndex(o => new { o.Title, o.DiplomaProgramYearId, o.AcademicYearId})
                .IsUnique();

                //TURN OFF CASCADE DELETE FOR ALL RELATIOONSHIPS
                foreach(var entity in modelBuilder.Model.GetEntityTypes()){
                    foreach(var fk in entity.GetForeignKeys()){
                        fk.DeleteBehavior = DeleteBehavior.NoAction;
                    }
                }
        }


    }
}
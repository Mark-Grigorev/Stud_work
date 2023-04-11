using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StudProject.Models
{
    public partial class StudProdContext : DbContext
    {
        public StudProdContext()
        {
        }

        public StudProdContext(DbContextOptions<StudProdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<PersonalInformationOfSt> PersonalInformationOfSts { get; set; }
        public virtual DbSet<PersonalInformationOfTeacher> PersonalInformationOfTeachers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TheSubject> TheSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-D0RUOU9;Database=StudProd;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Groupe>(entity =>
            {
                entity.ToTable("Groupe");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameOfGroupe)
                    .HasMaxLength(50)
                    .HasColumnName("Name of groupe")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PersonalInformationOfSt>(entity =>
            {
                entity.ToTable("Personal_Information_of_St");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HomeAdress)
                    .HasMaxLength(50)
                    .HasColumnName("Home Adress")
                    .IsFixedLength(true);

                entity.Property(e => e.Inn).HasColumnName("INN");

                entity.Property(e => e.Login)
                    .HasMaxLength(25)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsFixedLength(true);

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.PersonalInformationOfSts)
                    .HasForeignKey(d => d.Student)
                    .HasConstraintName("FK_Personal_Information_of_St_Students1");
            });

            modelBuilder.Entity<PersonalInformationOfTeacher>(entity =>
            {
                entity.ToTable("Personal_Information_of_Teachers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HomeAdress)
                    .HasMaxLength(50)
                    .HasColumnName("Home Adress")
                    .IsFixedLength(true);

                entity.Property(e => e.Inn).HasColumnName("INN");

                entity.Property(e => e.Login)
                    .HasMaxLength(25)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsFixedLength(true);

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.PersonalInformationOfTeachers)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("FK_Personal_Information_of_Teachers_Positions1");

                entity.HasOne(d => d.TeacherNavigation)
                    .WithMany(p => p.PersonalInformationOfTeachers)
                    .HasForeignKey(d => d.Teacher)
                    .HasConstraintName("FK_Personal_Information_of_Teachers_Teachers1");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Position1)
                    .HasMaxLength(25)
                    .HasColumnName("Position")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CorrectAnswer)
                    .HasMaxLength(50)
                    .HasColumnName("Correct answer")
                    .IsFixedLength(true);

                entity.Property(e => e.NameOfQuestion)
                    .HasMaxLength(50)
                    .HasColumnName("Name of question")
                    .IsFixedLength(true);

                entity.Property(e => e.TheSubject).HasColumnName("The subject");

                entity.HasOne(d => d.TeacherNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Teacher)
                    .HasConstraintName("FK_Questions_Teachers");

                entity.HasOne(d => d.TheSubjectNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TheSubject)
                    .HasConstraintName("FK_Questions_The Subject");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date of Birth");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("Full name")
                    .IsFixedLength(true);

                entity.HasOne(d => d.GroupeNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Groupe)
                    .HasConstraintName("FK_Students_Groupe");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date of Birth");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("Full name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.Subject)
                    .HasConstraintName("FK_Tests_The Subject");

                entity.HasOne(d => d.TeacherNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.Teacher)
                    .HasConstraintName("FK_Tests_Teachers");
            });

            modelBuilder.Entity<TheSubject>(entity =>
            {
                entity.ToTable("The Subject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameOfSubject)
                    .HasMaxLength(50)
                    .HasColumnName("Name of Subject")
                    .IsFixedLength(true);

               

                entity.HasOne(d => d.GroupeNavigation)
                    .WithMany(p => p.TheSubjects)
                    .HasForeignKey(d => d.Groupe)
                    .HasConstraintName("FK_The Subject_Groupe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

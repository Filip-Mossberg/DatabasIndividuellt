using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabasIndividuellt.Models
{
    public partial class Data : DbContext
    {
        public Data()
        {
        }

        public Data(DbContextOptions<Data> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<PersonalClass> PersonalClasses { get; set; } = null!;
        public virtual DbSet<Proffession> Proffessions { get; set; } = null!;
        public virtual DbSet<Pssg> Pssgs { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<VwPersonalInfo> VwPersonalInfos { get; set; } = null!;
        public virtual DbSet<VwSectionAverageSalary> VwSectionAverageSalaries { get; set; } = null!;
        public virtual DbSet<VwSectionPayout> VwSectionPayouts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = FILIPS-HP;Initial Catalog=PrimarySchool;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Section");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GradeLetter).HasMaxLength(5);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.DateHierd).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.LName)
                    .HasMaxLength(50)
                    .HasColumnName("lName");

                entity.Property(e => e.ProffessionId).HasColumnName("ProffessionID");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.HasOne(d => d.Proffession)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.ProffessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personal_Proffession");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personal_Section");
            });

            modelBuilder.Entity<PersonalClass>(entity =>
            {
                entity.ToTable("PersonalClass");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.PersonalClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalClass_Class");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.PersonalClasses)
                    .HasForeignKey(d => d.PersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonalClass_Personal");
            });

            modelBuilder.Entity<Proffession>(entity =>
            {
                entity.ToTable("Proffession");

                entity.Property(e => e.ProffessionId).HasColumnName("ProffessionID");

                entity.Property(e => e.ProffessionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Pssg>(entity =>
            {
                entity.ToTable("PSSG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Pssgs)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PSSG_Grade");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.Pssgs)
                    .HasForeignKey(d => d.PersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PSSG_Personal");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Pssgs)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PSSG_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Pssgs)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PSSG_Subject");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Section");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.SectionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.LName)
                    .HasMaxLength(50)
                    .HasColumnName("lName");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(50)
                    .HasColumnName("SSN");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.CourseActive).HasMaxLength(50);

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<VwPersonalInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_PersonalInfo");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.LName)
                    .HasMaxLength(50)
                    .HasColumnName("lName");

                entity.Property(e => e.ProffessionName).HasMaxLength(50);
            });

            modelBuilder.Entity<VwSectionAverageSalary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_SectionAverageSalary");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.SectionName).HasMaxLength(50);
            });

            modelBuilder.Entity<VwSectionPayout>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_SectionPayout");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.SectionName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

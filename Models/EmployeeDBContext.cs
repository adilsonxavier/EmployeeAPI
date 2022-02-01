using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeRegister.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Foto> Fotos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillEmployee> SkillEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cpnfigurações necessárias no muitos-para-muitos (criado manuelmente )
            modelBuilder.Entity<SkillEmployee>()
                .HasKey(se => new { se.SkillId, se.EmployeeId });

            modelBuilder.Entity<SkillEmployee>()
                .HasOne(se => se.Skill)
                .WithMany(s => s.SkillEmployees)
                .HasForeignKey(se => se.SkillId);

            modelBuilder.Entity<SkillEmployee>()
                .HasOne(se => se.Employee)
                .WithMany(e => e.SkillEmployees)
                .HasForeignKey(se => se.EmployeeId);
        }

    }
}

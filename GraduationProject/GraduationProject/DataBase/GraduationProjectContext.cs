using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.DataBase;

public partial class GraduationProjectContext : DbContext
{
    public GraduationProjectContext()
    {
    }

    public GraduationProjectContext(DbContextOptions<GraduationProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalGender> AnimalGenders { get; set; }

    public virtual DbSet<AnimalKind> AnimalKinds { get; set; }

    public virtual DbSet<AnimalMaterial> AnimalMaterials { get; set; }

    public virtual DbSet<Aviary> Aviaries { get; set; }

    public virtual DbSet<CareMaterial> CareMaterials { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }

    public virtual DbSet<PersonGender> PersonGenders { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<SeasonMethod> SeasonMethods { get; set; }

    public virtual DbSet<TemperatureMethod> TemperatureMethods { get; set; }

    public virtual DbSet<TypeAviary> TypeAviaries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-80QITHSR\\SQLEXPRES;Initial Catalog=GraduationProject;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_User");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.ToTable("Animal");

            entity.Property(e => e.AviaryId).HasColumnName("Aviary_Id");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.GenderId).HasColumnName("Gender_Id");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Aviary).WithMany(p => p.Animals)
                .HasForeignKey(d => d.AviaryId)
                .HasConstraintName("FK_Animal_Aviary1");

            entity.HasOne(d => d.Gender).WithMany(p => p.Animals)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Animal_AnimalGender");
        });

        modelBuilder.Entity<AnimalGender>(entity =>
        {
            entity.ToTable("AnimalGender");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AnimalKind>(entity =>
        {
            entity.ToTable("AnimalKind");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AnimalMaterial>(entity =>
        {
            entity.ToTable("Animal_Material");

            entity.Property(e => e.AnimalId).HasColumnName("Animal_Id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MaterialId).HasColumnName("Material_Id");

            entity.HasOne(d => d.Animal).WithMany(p => p.AnimalMaterials)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_Material_Animal1");

            entity.HasOne(d => d.Material).WithMany(p => p.AnimalMaterials)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_Material_CareMaterial");
        });

        modelBuilder.Entity<Aviary>(entity =>
        {
            entity.ToTable("Aviary");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KindId).HasColumnName("Kind_Id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeId).HasColumnName("Type_Id");

            entity.HasOne(d => d.Kind).WithMany(p => p.Aviaries)
                .HasForeignKey(d => d.KindId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aviary_AnimalKind");

            entity.HasOne(d => d.Type).WithMany(p => p.Aviaries)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Aviary_TypeAviary");
        });

        modelBuilder.Entity<CareMaterial>(entity =>
        {
            entity.ToTable("CareMaterial");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.MeasurementUnitId).HasColumnName("MeasurementUnit_Id");
            entity.Property(e => e.ProductionDate).HasColumnType("date");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeId).HasColumnName("Type_Id");

            entity.HasOne(d => d.MeasurementUnit).WithMany(p => p.CareMaterials)
                .HasForeignKey(d => d.MeasurementUnitId)
                .HasConstraintName("FK_CareMaterial_MeasurementUnit");

            entity.HasOne(d => d.Type).WithMany(p => p.CareMaterials)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CareMaterial_MaterialType");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("MaterialType");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MeasurementUnit>(entity =>
        {
            entity.ToTable("MeasurementUnit");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PersonGender>(entity =>
        {
            entity.ToTable("PersonGender");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.ToTable("Report");

            entity.Property(e => e.AviaryId).HasColumnName("Aviary_id");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Aviary).WithMany(p => p.Reports)
                .HasForeignKey(d => d.AviaryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_Aviary");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.ToTable("Season");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeasonMethod>(entity =>
        {
            entity.ToTable("Season_Method");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MethodId).HasColumnName("Method_Id");
            entity.Property(e => e.SeasonId).HasColumnName("Season_Id");

            entity.HasOne(d => d.Method).WithMany(p => p.SeasonMethods)
                .HasForeignKey(d => d.MethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_Method_TemperatureMethod");

            entity.HasOne(d => d.Season).WithMany(p => p.SeasonMethods)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_Method_Season");
        });

        modelBuilder.Entity<TemperatureMethod>(entity =>
        {
            entity.ToTable("TemperatureMethod");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TypeAviary>(entity =>
        {
            entity.ToTable("TypeAviary");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.BirthPlace)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DivissionCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GenderId).HasColumnName("Gender_Id");
            entity.Property(e => e.IdentityDocument)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IssuedDate).HasColumnType("date");
            entity.Property(e => e.IssuedPlace)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_User_PersonGender");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

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

    public virtual DbSet<AnimalDisease> AnimalDiseases { get; set; }

    public virtual DbSet<AnimalGender> AnimalGenders { get; set; }

    public virtual DbSet<AnimalKind> AnimalKinds { get; set; }

    public virtual DbSet<AnimalMaterial> AnimalMaterials { get; set; }

    public virtual DbSet<Aviary> Aviaries { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<CareMaterial> CareMaterials { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<DiseaseType> DiseaseTypes { get; set; }

    public virtual DbSet<MaterialSupplier> MaterialSuppliers { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<MealOrder> MealOrders { get; set; }

    public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }

    public virtual DbSet<Offspring> Offspring { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<PersonGender> PersonGenders { get; set; }

    public virtual DbSet<PlannerTask> PlannerTasks { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TypeAviary> TypeAviaries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
            entity.Property(e => e.BinaryImage).HasColumnType("image");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.FeedRateInKg).HasColumnType("decimal(3, 0)");
            entity.Property(e => e.GenderId).HasColumnName("Gender_Id");
            entity.Property(e => e.HeightInMetre).HasColumnType("decimal(3, 0)");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WeightInKg).HasColumnType("decimal(3, 0)");

            entity.HasOne(d => d.Aviary).WithMany(p => p.Animals)
                .HasForeignKey(d => d.AviaryId)
                .HasConstraintName("FK_Animal_Aviary1");

            entity.HasOne(d => d.Gender).WithMany(p => p.Animals)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Animal_AnimalGender");
        });

        modelBuilder.Entity<AnimalDisease>(entity =>
        {
            entity.ToTable("Animal_Disease");

            entity.Property(e => e.AnimalId).HasColumnName("Animal_Id");
            entity.Property(e => e.DiseaseId).HasColumnName("Disease_Id");

            entity.HasOne(d => d.Animal).WithMany(p => p.AnimalDiseases)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_Animal_Disease_Animal");

            entity.HasOne(d => d.Disease).WithMany(p => p.AnimalDiseases)
                .HasForeignKey(d => d.DiseaseId)
                .HasConstraintName("FK_Animal_Disease_Disease");
        });

        modelBuilder.Entity<AnimalGender>(entity =>
        {
            entity.ToTable("AnimalGender");

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

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.ToTable("Basket");

            entity.Property(e => e.MealId).HasColumnName("Meal_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Meal).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.MealId)
                .HasConstraintName("FK_Basket_Meal");
        });

        modelBuilder.Entity<CareMaterial>(entity =>
        {
            entity.ToTable("CareMaterial");

            entity.Property(e => e.BinaryImage).HasColumnType("image");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
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

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.ToTable("Disease");

            entity.Property(e => e.DiseaseTypeId).HasColumnName("DiseaseType_Id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VaccinationId).HasColumnName("Vaccination_Id");

            entity.HasOne(d => d.DiseaseType).WithMany(p => p.Diseases)
                .HasForeignKey(d => d.DiseaseTypeId)
                .HasConstraintName("FK_Disease_DiseaseType");

            entity.HasOne(d => d.Vaccination).WithMany(p => p.Diseases)
                .HasForeignKey(d => d.VaccinationId)
                .HasConstraintName("FK_Disease_Vaccination");
        });

        modelBuilder.Entity<DiseaseType>(entity =>
        {
            entity.ToTable("DiseaseType");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaterialSupplier>(entity =>
        {
            entity.ToTable("Material_Supplier");

            entity.Property(e => e.MaterialId).HasColumnName("Material_Id");
            entity.Property(e => e.Price).HasColumnType("decimal(7, 0)");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialSuppliers)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Material_Supplier_CareMaterial");

            entity.HasOne(d => d.Supplier).WithMany(p => p.MaterialSuppliers)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Material_Supplier_Supplier");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("MaterialType");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.ToTable("Meal");

            entity.Property(e => e.BinaryImage).HasColumnType("image");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Meals)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Meal_Category");
        });

        modelBuilder.Entity<MealOrder>(entity =>
        {
            entity.ToTable("Meal_Order");

            entity.Property(e => e.MealId).HasColumnName("Meal_Id");
            entity.Property(e => e.OrderId).HasColumnName("Order_Id");

            entity.HasOne(d => d.Meal).WithMany(p => p.MealOrders)
                .HasForeignKey(d => d.MealId)
                .HasConstraintName("FK_Meal_Order_Meal");

            entity.HasOne(d => d.Order).WithMany(p => p.MealOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Meal_Order_Order");
        });

        modelBuilder.Entity<MeasurementUnit>(entity =>
        {
            entity.ToTable("MeasurementUnit");

            entity.Property(e => e.Title)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Offspring>(entity =>
        {
            entity.Property(e => e.AnimalId).HasColumnName("Animal_Id");
            entity.Property(e => e.KidId).HasColumnName("Kid_Id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Offspring)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("FK_Offspring_Animal");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.ReadyTime).HasColumnType("date");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Order_OrderStatus");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.ToTable("OrderStatus");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PersonGender>(entity =>
        {
            entity.ToTable("PersonGender");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlannerTask>(entity =>
        {
            entity.ToTable("PlannerTask");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
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

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TypeAviary>(entity =>
        {
            entity.ToTable("TypeAviary");

            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.BinaryImage).HasColumnType("image");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.GenderId).HasColumnName("Gender_Id");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
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

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.ToTable("User_Task");

            entity.Property(e => e.TaskId).HasColumnName("Task_Id");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Task).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_User_Task_PlannerTask");

            entity.HasOne(d => d.User).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_Task_User");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.ToTable("Vaccination");

            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

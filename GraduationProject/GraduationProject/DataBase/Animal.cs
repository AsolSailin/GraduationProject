using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Animal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string? Image { get; set; }

    public int? GenderId { get; set; }

    public int? AviaryId { get; set; }

    public bool? IsDeleted { get; set; }

    public decimal? HeightInMetre { get; set; }

    public decimal? WeightInKg { get; set; }

    public decimal? FeedRateInKg { get; set; }

    public byte[]? BinaryImage { get; set; }

    public virtual ICollection<AnimalDisease> AnimalDiseases { get; set; } = new List<AnimalDisease>();

    public virtual ICollection<AnimalMaterial> AnimalMaterials { get; set; } = new List<AnimalMaterial>();

    public virtual ICollection<AnimalReport> AnimalReports { get; set; } = new List<AnimalReport>();

    public virtual ICollection<AnimalVaccination> AnimalVaccinations { get; set; } = new List<AnimalVaccination>();

    public virtual Aviary? Aviary { get; set; }

    public virtual AnimalGender? Gender { get; set; }

    public virtual ICollection<Offspring> Offspring { get; set; } = new List<Offspring>();
}

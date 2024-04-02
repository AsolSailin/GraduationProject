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

    public virtual ICollection<AnimalMaterial> AnimalMaterials { get; set; } = new List<AnimalMaterial>();

    public virtual Aviary? Aviary { get; set; }

    public virtual AnimalGender? Gender { get; set; }
}

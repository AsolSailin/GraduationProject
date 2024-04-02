using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Aviary
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool Cleaned { get; set; }

    public int TypeId { get; set; }

    public int KindId { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual AnimalKind Kind { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual TypeAviary Type { get; set; } = null!;
}

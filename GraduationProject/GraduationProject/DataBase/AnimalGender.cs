using System;
using System.Collections.Generic;

namespace GraduationProject;

public partial class AnimalGender
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}

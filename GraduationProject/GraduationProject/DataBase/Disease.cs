using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Disease
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool? IsQuarantine { get; set; }

    public virtual ICollection<AnimalDisease> AnimalDiseases { get; set; } = new List<AnimalDisease>();
}

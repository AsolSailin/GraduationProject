using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Vaccination
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();
}

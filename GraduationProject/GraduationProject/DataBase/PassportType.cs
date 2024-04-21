using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class PassportType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Passport> Passports { get; set; } = new List<Passport>();
}

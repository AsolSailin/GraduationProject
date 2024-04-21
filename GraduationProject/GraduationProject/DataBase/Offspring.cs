using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Offspring
{
    public int Id { get; set; }

    public int? AnimalId { get; set; }

    public int? KidId { get; set; }

    public virtual Animal? Animal { get; set; }
}

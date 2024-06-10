using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class AnimalVaccination
{
    public int Id { get; set; }

    public int? AnimalId { get; set; }

    public int? VaccinationId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Vaccination? Vaccination { get; set; }
}

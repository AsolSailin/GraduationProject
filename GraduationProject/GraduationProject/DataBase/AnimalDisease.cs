using System;
using System.Collections.Generic;
using GraduationProject.DataBase;

namespace GraduationProject;

public partial class AnimalDisease
{
    public int Id { get; set; }

    public int? AnimalId { get; set; }

    public int? DiseaseId { get; set; }

    public virtual Animal? Animal { get; set; }

    public virtual Disease? Disease { get; set; }
}

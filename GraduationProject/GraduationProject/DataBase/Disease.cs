using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Disease
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? DiseaseTypeId { get; set; }

    public int? VaccinationId { get; set; }

    public virtual ICollection<AnimalDisease> AnimalDiseases { get; set; } = new List<AnimalDisease>();

    public virtual DiseaseType? DiseaseType { get; set; }

    public virtual Vaccination? Vaccination { get; set; }
}

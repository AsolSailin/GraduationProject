using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Report
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public bool IsAccepted { get; set; }

    public int UserId { get; set; }

    public int AviaryId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<AnimalReport> AnimalReports { get; set; } = new List<AnimalReport>();

    public virtual Aviary Aviary { get; set; } = null!;

    public virtual ICollection<MaterialApplication> MaterialApplications { get; set; } = new List<MaterialApplication>();

    public virtual User User { get; set; } = null!;
}

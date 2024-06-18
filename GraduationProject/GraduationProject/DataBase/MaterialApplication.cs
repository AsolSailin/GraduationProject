using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class MaterialApplication
{
    public int Id { get; set; }

    public int MaterialId { get; set; }

    public DateTime? Date { get; set; }

    public double Expense { get; set; }

    public int? ReportId { get; set; }

    public virtual CareMaterial Material { get; set; } = null!;

    public virtual Report? Report { get; set; }
}

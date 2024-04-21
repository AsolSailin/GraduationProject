using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class Passport
{
    public int PassportNumber { get; set; }

    public int? PassportSeries { get; set; }

    public string? IssuePlace { get; set; }

    public DateTime? IssueDate { get; set; }

    public int? DivissionCode { get; set; }

    public int? PassportTypeId { get; set; }

    public virtual PassportType? PassportType { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

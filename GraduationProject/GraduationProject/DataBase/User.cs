using System;
using System.Collections.Generic;

namespace GraduationProject.DataBase;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? BirthPlace { get; set; }

    public string? Registration { get; set; }

    public int? GenderId { get; set; }

    public int? PassportId { get; set; }

    public int? MaritalStatusId { get; set; }

    public int? KidId { get; set; }

    public int? RoleId { get; set; }

    public string? Image { get; set; }

    public byte[]? BinaryImage { get; set; }

    public int? Experience { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual PersonGender? Gender { get; set; }

    public virtual Kid? Kid { get; set; }

    public virtual MaritalStatus? MaritalStatus { get; set; }

    public virtual Passport? Passport { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Role? Role { get; set; }
}

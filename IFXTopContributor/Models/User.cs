using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IFXTopContributor.Models;

public partial class User
{
    [Required]
    public int Userid { get; set; }
    [Required]
    public string Firstname { get; set; } = string.Empty;
    [Required]
    public string Lastname { get; set; } = string.Empty;
    [Required]
    public string? Email { get; set; } = string.Empty;
    [Required]
    public bool Microsoftaccount { get; set; }
    [Required]
    public int Roleid { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; } = DateTime.UtcNow;

    public int? Logincodeid { get; set; }

    //public virtual Logincode? Logincode { get; set; }

    //public virtual ICollection<Logincode> Logincodes { get; set; } = new List<Logincode>();
}

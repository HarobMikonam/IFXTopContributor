using System;
using System.Collections.Generic;

namespace IFXTopContributor.Models;

public partial class Logincode
{
    public int Codeid { get; set; }

    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string? Encryptedpasswordhash { get; set; }

    public DateTime? Createdat { get; set; }

    public bool Used { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

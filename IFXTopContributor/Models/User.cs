using System;
using System.Collections.Generic;

namespace IFXTopContributor.Models;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public DateTime Createdat { get; set; }

    public DateTime Updatedat { get; set; } = DateTime.UtcNow;
}

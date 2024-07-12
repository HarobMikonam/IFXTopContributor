using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IFXTopContributor.Models;

public partial class User
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Firstname { get; set; } = string.Empty;
    [Required]
    public string? Lastname { get; set; } = string.Empty;
    [Required]
    public string? Email { get; set; } = string.Empty;
    [Required]
    public string? Role { get; set; } = string.Empty;

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }  = DateTime.UtcNow;
}

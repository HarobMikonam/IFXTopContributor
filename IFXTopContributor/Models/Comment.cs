using System;
using System.Collections.Generic;

namespace IFXTopContributor.Models;

public partial class Comment
{
    public int Commentid { get; set; }

    public int Userid { get; set; }

    public int Votedforid { get; set; }

    public string Commenttext { get; set; } = null!;

    public string? Encryptedcomment { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }
}

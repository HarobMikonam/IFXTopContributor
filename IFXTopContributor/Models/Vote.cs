using System;
using System.Collections.Generic;

namespace IFXTopContributor.Models;

public partial class Vote
{
    public int Voteid { get; set; }

    public int Voterid { get; set; }

    public int Votedforid { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public string? Encryptedcomment { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }
}

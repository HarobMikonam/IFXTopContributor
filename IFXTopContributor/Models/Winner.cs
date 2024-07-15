using System;
using System.Collections.Generic;

namespace IFXTopContributor.Models;

public partial class Winner
{
    public int Winnerid { get; set; }

    public int Userid { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public DateTime? Createdat { get; set; }
}

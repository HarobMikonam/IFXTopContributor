using System;
using System.Collections.Generic;

namespace IFXTopContributor.Models;

public partial class Log
{
    public int Logid { get; set; }

    public string Actiontype { get; set; } = null!;

    public int? Userid { get; set; }

    public int? Targetid { get; set; }

    public DateTime? Createdat { get; set; }
}

using System;
using System.Collections.Generic;

namespace VAVS_Data.Models;

public partial class TbTownship
{
    public int TownshipPkid { get; set; }

    public string TownshipCode { get; set; } = null!;

    public string? TownshipName { get; set; }

    public string? DistrictCode { get; set; }

    public virtual ICollection<TbPersonalDetail> TbPersonalDetails { get; set; } = new List<TbPersonalDetail>();
}

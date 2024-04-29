using System;
using System.Collections.Generic;

namespace VAVS_Data.Models;

public partial class TbStateDivision
{
    public int StateDivisionPkid { get; set; }

    public string StateDivisionCode { get; set; } = null!;

    public string? StateDivisionName { get; set; }

    public string? CityOfRegion { get; set; }

    public string? EngShortCode { get; set; }

    public string? MynShortCode { get; set; }

    public virtual ICollection<TbPersonalDetail> TbPersonalDetails { get; set; } = new List<TbPersonalDetail>();

    public virtual ICollection<TbVehicleStandardValue> TbVehicleStandardValues { get; set; } = new List<TbVehicleStandardValue>();
}

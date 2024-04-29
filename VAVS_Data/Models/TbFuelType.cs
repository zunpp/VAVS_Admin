using System;
using System.Collections.Generic;

namespace VAVS_Data.Models;

public partial class TbFuelType
{
    public int FuelTypePkid { get; set; }

    public string? FuelType { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<TbVehicleStandardValue> TbVehicleStandardValues { get; set; } = new List<TbVehicleStandardValue>();
}

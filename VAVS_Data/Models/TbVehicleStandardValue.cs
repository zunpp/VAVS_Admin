using System;
using System.Collections.Generic;

namespace VAVS_Data.Models;

public partial class TbVehicleStandardValue
{
    public int VehicleStandardValuePkid { get; set; }

    public string? Manufacturer { get; set; }

    public string? CountryOfMade { get; set; }

    public string? VehicleBrand { get; set; }

    public string? BuildType { get; set; }

    public string? ModelYear { get; set; }

    public string? EnginePower { get; set; }

    public string? StandardValue { get; set; }

    public string? OfficeLetterNo { get; set; }

    public string? AttachFileName { get; set; }

    public string? Remarks { get; set; }

    public DateTime? EntryDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public int StateDivisionPkid { get; set; }

    public int FuelTypePkid { get; set; }

    public string? VehicleNumber { get; set; }

    public virtual TbFuelType FuelTypePk { get; set; } = null!;

    public virtual TbStateDivision StateDivisionPk { get; set; } = null!;
}

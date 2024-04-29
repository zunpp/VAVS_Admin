using System;
using System.Collections.Generic;

namespace VAVS_Data.Models;

public partial class TbTaxValidation
{
    public int TaxValidationPkid { get; set; }

    public int? PersonalPkid { get; set; }

    public string? PersonTinnumber { get; set; }

    public string? PersonNrc { get; set; }

    public int? PersonTownshipPkid { get; set; }

    public string? VehicleNumber { get; set; }

    public string? Manufacturer { get; set; }

    public string? CountryOfMade { get; set; }

    public string? VehicleBrand { get; set; }

    public string? BuildType { get; set; }

    public string? ModelYear { get; set; }

    public string? EnginePower { get; set; }

    public string? FuelType { get; set; }

    public string? OfficeLetterNo { get; set; }

    public string? AttachFileName { get; set; }

    public DateTime? EntryDate { get; set; }

    public decimal? StandardValue { get; set; }

    public decimal? ContractValue { get; set; }

    public decimal? TaxAmount { get; set; }

    public string? PaymentRefId { get; set; }

    public string? QrcodeNumber { get; set; }

    public string? DemandNumber { get; set; }

    public string? FormNumber { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}

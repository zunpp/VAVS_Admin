using System;
using System.Collections.Generic;

namespace VAVS_Data.Models;

public partial class TbPersonalDetail
{
    public int PersonalPkid { get; set; }

    public DateTime? TransactionId { get; set; }

    public DateTime? EntryDate { get; set; }

    public string? PersonTinnumber { get; set; }

    public string? Name { get; set; }

    public string? NrctownshipNumber { get; set; }

    public string? NrctownshipInitial { get; set; }

    public string? Nrctype { get; set; }

    public string? Nrcnumber { get; set; }

    public string? Quarter { get; set; }

    public string? Street { get; set; }

    public string? HousingNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? RegistrationStatus { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int StateDivisionPkid { get; set; }

    public int TownshipPkid { get; set; }

    public string NrcbackImagePath { get; set; } = null!;

    public string NrcfrontImagePath { get; set; } = null!;

    public virtual TbStateDivision StateDivisionPk { get; set; } = null!;

    public virtual TbTownship TownshipPk { get; set; } = null!;
}

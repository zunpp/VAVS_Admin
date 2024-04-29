using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAVS_Model.Model
{
    public class VM_TaxValidation
    {
        public int TaxValidationPkid { get; set; }

        public int? PersonalPkid { get; set; }

        public string? PersonTinnumber { get; set; }

        public string? PersonNrc { get; set; }

        public int? PersonTownshipPkid { get; set; }

        public int? VehiclePkid { get; set; }

        public string? VehicleNumber { get; set; }

        public decimal? StandardValue { get; set; }

        public decimal? ContractValue { get; set; }

        public decimal? TaxAmount { get; set; }

        public string? PaymentRefId { get; set; }

        public string? QrcodeNumber { get; set; }

        public string? DemandNumber { get; set; }

        public string? FormNumber { get; set; }

        public string? Name { get; set; }
        public string? StateDivision { get; set; }
        public string? Township { get; set; }
        public string? VehicleBrand { get; set; }
        public string? ModelYear { get; set; }
       
    }
}

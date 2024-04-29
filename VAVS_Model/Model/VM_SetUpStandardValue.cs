using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAVS_Model.Model
{
    public class VM_SetUpStandardValue
    {
        public int? VehicleStandardMasterPkid { get; set; }
        public string? Manufacturer { get; set; }
        public string? BuildType { get; set; }
        public string? FuelType { get; set; }
        public string? VehicleBrand { get; set; }
        public string? ModelYear { get; set; }
        public string? EnginePower { get; set; }
        public decimal? StandardValue { get; set; }
    }
}

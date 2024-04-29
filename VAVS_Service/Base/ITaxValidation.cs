using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAVS_Model.Model;

namespace VAVS_Service.Base
{
    public interface ITaxValidation
    {
        List<VM_TaxValidation> GetTaxValidation(string? VehicleNumber, string? NRC, string? Status, int? TownshipPkid);
        VM_TaxValidation GetTaxValidationById(int TaxValidationPkid);
        Task<dynamic> EditTaxValidation(VM_TaxValidation taxValidation, int userId);
    }
}

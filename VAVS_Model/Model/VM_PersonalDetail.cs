using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAVS_Model.Model
{
    public class VM_PersonalDetail
    {
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

        public string? StateDivision { get; set; }

        public string? Township { get; set; }
        public string NRC { get; set; }
       


    
    }
}

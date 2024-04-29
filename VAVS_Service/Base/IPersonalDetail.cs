using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAVS_Model.Model;

namespace VAVS_Service.Base
{
    public interface IPersonalDetail
    {
        List<VM_PersonalDetail> GetPersonalDetail();
    }
}

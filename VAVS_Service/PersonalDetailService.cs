using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAVS_Data.Repository.Base;
using VAVS_Model.Model;
using VAVS_Service.Base;
using VAVS_Service.DataAccess;
using VAVS_Service.Options;

namespace VAVS_Service
{
    public class PersonalDetailService:IPersonalDetail
    {
        public ConnectionStrings _connectionStrings;
        public IUnitOfWork _unitOfwork;
        private readonly PersonalDetailDAO _personalDetailDAO;
        public PersonalDetailService(IUnitOfWork unitOfWork, IOptions<ConnectionStrings> connectionStrings)
        {
            _unitOfwork = unitOfWork;
            _connectionStrings = connectionStrings.Value;
            _personalDetailDAO = new PersonalDetailDAO();
        }
        public List<VM_PersonalDetail> GetPersonalDetail()
        {
            IDbConnection connection = new SqlConnection(_connectionStrings.DefaultConnection);
            IDbConnection mycon = connection;
            IDbCommand cmd = mycon.CreateCommand();
            var results = _personalDetailDAO.GetPersonalDetail(cmd);

            return results;

        }
    }
}

using Microsoft.AspNetCore.Http;
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
    public class TaxValidationServices:ITaxValidation
    {
        public ConnectionStrings _connectionStrings;
        public IUnitOfWork _unitOfwork;
        private readonly TaxValidationDAO _taxValidationDAO;
        public TaxValidationServices(IUnitOfWork unitOfWork, IOptions<ConnectionStrings> connectionStrings)
        {
            _unitOfwork = unitOfWork;
            _connectionStrings = connectionStrings.Value;
            _taxValidationDAO = new TaxValidationDAO();
        }
        public List<VM_TaxValidation> GetTaxValidation(string? VehicleNumber, string? NRC, string? Status,int? TownshipPkid)
        {
            IDbConnection connection = new SqlConnection(_connectionStrings.DefaultConnection);
            IDbConnection mycon = connection;
            IDbCommand cmd = mycon.CreateCommand();
            var results = _taxValidationDAO.GetTaxValidation(cmd, VehicleNumber, NRC, Status,TownshipPkid);

            return results;

        }
        public VM_TaxValidation GetTaxValidationById( int TaxValidationPkid)
        {
            IDbConnection connection = new SqlConnection(_connectionStrings.DefaultConnection);
            IDbConnection mycon = connection;
            IDbCommand cmd = mycon.CreateCommand();
            var results = _taxValidationDAO.GetTaxValidationById(cmd, TaxValidationPkid);

            return results;

        }
        public async Task<dynamic> EditTaxValidation(VM_TaxValidation taxValidation, int userId)
        {
            try
            {
               
                    IDbConnection connection = new SqlConnection(_connectionStrings.DefaultConnection);
                    IDbConnection mycon = connection;
                    IDbCommand cmd = mycon.CreateCommand();
                    var officeResult = _taxValidationDAO.EditTaxValidation(cmd, taxValidation, userId);
                    return StatusCodes.Status200OK;
               

            }
            catch (Exception ex)
            {
                return StatusCodes.Status500InternalServerError;
            }


        }
    }
}

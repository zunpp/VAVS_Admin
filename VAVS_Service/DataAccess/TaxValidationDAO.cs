using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAVS_Model.Model;
using VAVS_Service.Extensions;

namespace VAVS_Service.DataAccess
{
    internal class TaxValidationDAO
    {
        public List<VM_TaxValidation> GetTaxValidation(IDbCommand cmd, string? VehicleNumber = null, string? NRC = null, string? Status = null,int? TownshipPkid=null)
        {

            cmd.CommandText = "Sp_GetTaxValidation";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Connection.Open();
            cmd.AddParameter("@VehicleNumber", VehicleNumber);
            cmd.AddParameter("@NRC", NRC);
            cmd.AddParameter("@Status", Status);
            cmd.AddParameter("@TownshipPkid", TownshipPkid);
            SqlDataAdapter ResAdapter = new SqlDataAdapter((SqlCommand)cmd);
            DataSet ResDs = new DataSet();
            ResAdapter.Fill(ResDs);
            List<VM_TaxValidation> lstBank = new List<VM_TaxValidation>();
            if (ResDs != null)
            {
                if (ResDs.Tables.Count > 0)
                {
                    if (ResDs.Tables[0] != null)
                    {
                        if (ResDs.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ResDs.Tables[0].Rows.Count; i++)
                            {
                                VM_TaxValidation bank = new VM_TaxValidation
                                {
                                    StateDivision = ResDs.Tables[0].Rows[i]["StateDivisionName"] != DBNull.Value ? ResDs.Tables[0].Rows[i]["StateDivisionName"].ToString(): "",
                                    Township = ResDs.Tables[0].Rows[i]["TownShipName"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["TownShipName"].ToString()) : "",
                                    Name = ResDs.Tables[0].Rows[i]["Name"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["Name"].ToString()) : "",
                                    VehicleNumber = ResDs.Tables[0].Rows[i]["VehicleNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["VehicleNumber"].ToString()) : "",
                                    VehicleBrand = ResDs.Tables[0].Rows[i]["VehicleBrand"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["VehicleBrand"].ToString()) : "",
                                    PersonTinnumber = ResDs.Tables[0].Rows[i]["PersonTINNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["PersonTINNumber"].ToString()) : "",
                                    PersonNrc = ResDs.Tables[0].Rows[i]["PersonNRC"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["PersonNRC"].ToString()) : "",
                                    QrcodeNumber = ResDs.Tables[0].Rows[i]["QrcodeNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["QrcodeNumber"].ToString()) : "",
                                    DemandNumber = ResDs.Tables[0].Rows[i]["DemandNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["DemandNumber"].ToString()) : "",
                                    FormNumber = ResDs.Tables[0].Rows[i]["FormNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["FormNumber"].ToString()) : "",
                                    TaxValidationPkid = ResDs.Tables[0].Rows[i]["TaxValidationPkid"] != DBNull.Value ? Convert.ToInt32((ResDs.Tables[0].Rows[i]["TaxValidationPkid"])) : 0,
                                    ModelYear = ResDs.Tables[0].Rows[i]["ModelYear"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["ModelYear"].ToString()) : ""
                                };

                                lstBank.Add(bank);
                            }
                        }
                    }
                }
            }
            cmd.Connection.Close();
            return lstBank;

        }

        public VM_TaxValidation GetTaxValidationById(IDbCommand cmd,int TaxValidationPkid)
        {

            cmd.CommandText = "Sp_GetTaxValidationById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Connection.Open();
           
            cmd.AddParameter("@TaxValidationPkid", TaxValidationPkid);
            SqlDataAdapter ResAdapter = new SqlDataAdapter((SqlCommand)cmd);
            DataSet ResDs = new DataSet();
            ResAdapter.Fill(ResDs);
            VM_TaxValidation tax = new VM_TaxValidation();
            if (ResDs != null)
            {
                if (ResDs.Tables.Count > 0)
                {
                    if (ResDs.Tables[0] != null)
                    {
                        if (ResDs.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ResDs.Tables[0].Rows.Count; i++)
                            {

                                tax.StateDivision = ResDs.Tables[0].Rows[i]["StateDivisionName"] != DBNull.Value ? ResDs.Tables[0].Rows[i]["StateDivisionName"].ToString() : "";
                                    tax.Township = ResDs.Tables[0].Rows[i]["TownShipName"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["TownShipName"].ToString()) : "";
                                tax.Name = ResDs.Tables[0].Rows[i]["Name"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["Name"].ToString()) : "";
                                tax.VehicleNumber = ResDs.Tables[0].Rows[i]["VehicleNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["VehicleNumber"].ToString()) : "";
                                tax.VehicleBrand = ResDs.Tables[0].Rows[i]["VehicleBrand"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["VehicleBrand"].ToString()) : "";
                                tax.PersonTinnumber = ResDs.Tables[0].Rows[i]["PersonTINNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["PersonTINNumber"].ToString()) : "";
                                tax.PersonNrc = ResDs.Tables[0].Rows[i]["PersonNRC"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["PersonNRC"].ToString()) : "";
                                tax.QrcodeNumber = ResDs.Tables[0].Rows[i]["QrcodeNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["QrcodeNumber"].ToString()) : "";
                                tax.DemandNumber = ResDs.Tables[0].Rows[i]["DemandNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["DemandNumber"].ToString()) : "";
                                tax.FormNumber = ResDs.Tables[0].Rows[i]["FormNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["FormNumber"].ToString()) : "";
                                tax.TaxValidationPkid = ResDs.Tables[0].Rows[i]["TaxValidationPkid"] != DBNull.Value ? Convert.ToInt32((ResDs.Tables[0].Rows[i]["TaxValidationPkid"])) : 0;
                                tax.ModelYear = ResDs.Tables[0].Rows[i]["ModelYear"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["ModelYear"].ToString()) : "";
                                tax.StandardValue = ResDs.Tables[0].Rows[i]["StandardValue"] != DBNull.Value ? Convert.ToDecimal((ResDs.Tables[0].Rows[i]["StandardValue"])) : 0;
                                tax.ContractValue = ResDs.Tables[0].Rows[i]["ContractValue"] != DBNull.Value ? Convert.ToDecimal((ResDs.Tables[0].Rows[i]["ContractValue"])) : 0;
                                tax.TaxAmount = ResDs.Tables[0].Rows[i]["TaxAmount"] != DBNull.Value ? Convert.ToDecimal((ResDs.Tables[0].Rows[i]["TaxAmount"])) : 0;
                            }
                        }
                    }
                }
            }
            cmd.Connection.Close();
            return tax;

        }

        public dynamic EditTaxValidation(IDbCommand cmd,VM_TaxValidation vM_TaxValidation, int userId)
        {
            try
            {
                cmd.CommandText = "Sp_EditTaxValidation";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Connection.Open();


                cmd.AddParameter("@TaxValidationPkid", vM_TaxValidation.TaxValidationPkid);
                cmd.AddParameter("@QRCodeNumber", vM_TaxValidation.QrcodeNumber);
                cmd.AddParameter("@DemandNumber", vM_TaxValidation.DemandNumber);
                cmd.AddParameter("@FormNumber", vM_TaxValidation.FormNumber);            
                cmd.AddParameter("@IsDeleted", false);
                cmd.AddParameter("@CreatedBy", userId);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return vM_TaxValidation;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}

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
    internal class PersonalDetailDAO
    {
        public List<VM_PersonalDetail> GetPersonalDetail(IDbCommand cmd)
        {

            cmd.CommandText = "Sp_GetPersonalDetail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Connection.Open();
            
            SqlDataAdapter ResAdapter = new SqlDataAdapter((SqlCommand)cmd);
            DataSet ResDs = new DataSet();
            ResAdapter.Fill(ResDs);
            List<VM_PersonalDetail> lstBank = new List<VM_PersonalDetail>();
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
                                VM_PersonalDetail personal = new VM_PersonalDetail();

                                personal.StateDivision = ResDs.Tables[0].Rows[i]["StateDivisionName"] != DBNull.Value ? ResDs.Tables[0].Rows[i]["StateDivisionName"].ToString() : "";
                                personal.Township = ResDs.Tables[0].Rows[i]["TownShipName"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["TownShipName"].ToString()) : "";
                                personal.Name = ResDs.Tables[0].Rows[i]["Name"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["Name"].ToString()) : "";
                                personal.PersonTinnumber = ResDs.Tables[0].Rows[i]["PersonTINNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["PersonTINNumber"].ToString()) : "";
                                personal.NrctownshipNumber = ResDs.Tables[0].Rows[i]["NrctownshipNumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["NrctownshipNumber"].ToString()) : "";
                                personal.NrctownshipInitial = ResDs.Tables[0].Rows[i]["NrctownshipInitial"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["NrctownshipInitial"].ToString()) : "";
                                personal.Nrctype = ResDs.Tables[0].Rows[i]["Nrctype"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["Nrctype"].ToString()) : "";
                                personal.Nrcnumber = ResDs.Tables[0].Rows[i]["Nrcnumber"] != DBNull.Value ? (ResDs.Tables[0].Rows[i]["Nrcnumber"].ToString()) : "";
                                personal.NRC = personal.NrctownshipNumber + personal.NrctownshipInitial + personal.Nrctype + personal.Nrcnumber;

                                lstBank.Add(personal);
                            }
                        }
                    }
                }
            }
            cmd.Connection.Close();
            return lstBank;

        }

    }
}

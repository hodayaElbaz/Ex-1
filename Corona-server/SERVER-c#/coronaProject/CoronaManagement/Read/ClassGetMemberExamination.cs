using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QueryServer.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace QueryServer.Quries
{
    /// <summary>
    /// This class intended for geting  all member's Examinations
    /// קלאס לצורך הבאת פרטי בדיקה של חבר אחד
    /// </summary>
    public class GetMemberExaminationResponse : ClassResponse
    {
        public GetMemberExaminationResponse()
        {

            listMemberExaminations = new List<ClassExamination>();
        }

        public List<ClassExamination> listMemberExaminations;
    }
    public class GetMemberExaminationParameter
    {
        public int memberID { get; set; }
    }
    public static class GetMemberExamination
    {
        public static GetMemberExaminationResponse Query(GetMemberExaminationParameter pObjParamter)
        {
            GetMemberExaminationResponse _response = new GetMemberExaminationResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);
            
            try           
            {
                string oString = "Select * from DBCorona.dbo.[MemberExamination] where memberID=@pmemberID ";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@pmemberID", pObjParamter.memberID);
                myConnection.Open();
                ClassExamination obj;
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    //סוכם על מנת להציג רק עד 4 בדיקות
                    int _count = 0;
                    while(  oReader.Read() && _count<=3)
                    {
                       
                        obj = new ClassExamination();

                        obj.memberID        = (int)oReader["memberID"];
                        obj.examinationID   = (int)oReader["examinationID"];
                        obj.dateTimeResult = (DateTime)oReader["dateTimeResult"];
                        obj.result = (bool)oReader["result"];
                        obj.dateTimeVaccination = (DateTime)oReader["dateTimeVaccination"];
                        obj.dateTimeaRecovery = (DateTime)oReader["dateTimeaRecovery"];
                        obj.manufacturer        = oReader["manufacturer"].ToString();

                        _response.listMemberExaminations.Add(obj);
                        _count++;
                    }
                }
                return _response;
            }
            catch (Exception ex)
            {
                _response.systemErrors.Add(ex.Message);
                return _response;
            }
            finally
            {
                myConnection.Close();
            }              
        }              
      
    }
}
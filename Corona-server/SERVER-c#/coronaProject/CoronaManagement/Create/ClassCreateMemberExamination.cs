using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QueryServer.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using QueryServer.Quries;

namespace QueryServer.Create
{
    /// <summary>
    /// This class intended for create  only one member's Examination
    /// </summary>
    public class CreateMemberExaminationResponse : ClassResponse
    {

    }
    public class CreateMemberExaminationParameter
    {
        public ClassExamination objMemberExamination { get; set; }
    }
    public static class CreateMemberExamination
    {
        public static CreateMemberExaminationResponse Create(CreateMemberExaminationParameter pObjParamter)
        {
            CreateMemberExaminationResponse _response = new CreateMemberExaminationResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);         
               
                try
                {
                string oString = "insert DBCorona.dbo.[MemberExamination]  (examinationID,examinationID,DateTimeResult,result,dateTimeVaccination,dateTimeaRecovery,manufacturer) values " +
                "( @pMemberID,@pExaminationID,@pDateTimeResult,@pResult,@pDateTimeVaccination,@pDateTimeRecovery,@pManufacturer)";
       
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@pMemberID", pObjParamter.objMemberExamination.memberID);
                    oCmd.Parameters.AddWithValue("@pExaminationID", pObjParamter.objMemberExamination.examinationID);
                oCmd.Parameters.AddWithValue("@pDateTimeResult", pObjParamter.objMemberExamination.dateTimeResult);
                oCmd.Parameters.AddWithValue("@pResult", pObjParamter.objMemberExamination.result);
                    oCmd.Parameters.AddWithValue("@pDateTimeVaccination", pObjParamter.objMemberExamination.dateTimeVaccination);
                    oCmd.Parameters.AddWithValue("@pDateTimeRecovery", pObjParamter.objMemberExamination.dateTimeaRecovery);
                    oCmd.Parameters.AddWithValue("@pManufacturer", pObjParamter.objMemberExamination.manufacturer);
          

                    myConnection.Open();
                    oCmd.ExecuteNonQuery();
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
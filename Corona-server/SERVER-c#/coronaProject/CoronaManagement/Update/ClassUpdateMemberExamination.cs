using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QueryServer.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using QueryServer.Quries;

namespace QueryServer.Updates
{
    public class UpdateMemberExaminationResponse : ClassResponse
    {

    }
    public class UpdateMemberExaminationParameter
    {
        public ClassExamination objMemberExamination { get; set; }
    }
    public static class UpdateMemberExamination
    {
        public static UpdateMemberExaminationResponse Update(UpdateMemberExaminationParameter pObjParamter)
        {
            UpdateMemberExaminationResponse _response = new UpdateMemberExaminationResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);         
               
                try
                {
                    string oString = "update DBCorona.dbo.[MemberExamination]  set  examinationID=@pExaminationID,dateTimeResult = @pDateTimeResult,result= @pResult, dateTimeVaccination=@pDateTimeVaccination " +
                        " , dateTimeRecovery=@pDateTimeRecovery, manufacturer=@pManufacturer where (memberID=@pMemberID and examinationID=@pExaminationID) ";

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
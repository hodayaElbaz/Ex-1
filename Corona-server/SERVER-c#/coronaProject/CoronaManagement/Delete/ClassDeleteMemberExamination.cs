using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QueryServer.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using QueryServer.Quries;

namespace QueryServer.Delete
{
    /// <summary>
    /// This class intended for deletion only one member's Examination
    /// </summary>
    public class DeleteMemberExaminationResponse : ClassResponse
    {

    }
    public class DeleteMemberExaminationParameter
    {
        public ClassExamination objMemberExamination { get; set; }
    }
    public static class DeleteMemberExamination
    {
        public static DeleteMemberExaminationResponse Delete(DeleteMemberExaminationParameter pObjParamter)
        {
            DeleteMemberExaminationResponse _response = new DeleteMemberExaminationResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);         
                
                try
                {
                    string oString = "Delete from  DBCorona.dbo.[MemberExamination]  where memberID=@pMemberID and examinationID=@pExaminationID ";

                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@pMemberID", pObjParamter.objMemberExamination.memberID);
                    oCmd.Parameters.AddWithValue("@pExaminationID", pObjParamter.objMemberExamination.examinationID);
     
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
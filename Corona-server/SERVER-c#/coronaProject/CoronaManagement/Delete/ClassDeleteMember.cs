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
    /// This class intended for deletion a member
    /// </summary>
    public class DeleteMemberResponse : ClassResponse
    {

    }
    public class DeleteMemberParameter
    {
        public ClassMember objMember { get; set; }
    }
    public static class DeleteMember
    {
        public static DeleteMemberResponse Delete(DeleteMemberParameter pObjParamter)
        {
                DeleteMemberResponse _response = new DeleteMemberResponse();

                var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
                SqlConnection myConnection = new SqlConnection(con);

                 try
                {
                    string oString = "delete from  DBCorona.dbo.[Member]  where memberID=@pMemberID ";

                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@pMemberID", pObjParamter.objMember.memberID);

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
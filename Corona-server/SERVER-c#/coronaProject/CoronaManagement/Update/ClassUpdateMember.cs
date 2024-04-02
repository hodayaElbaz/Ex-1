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
    public class UpdateMemberResponse : ClassResponse
    {

    }
    public class UpdateMemberParameter
    {
        public ClassMember objMember { get; set; }
    }
    public static class UpdateMember
    {
        public static UpdateMemberResponse Update(UpdateMemberParameter pObjParamter)
        {
            UpdateMemberResponse _response = new UpdateMemberResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);
           
              
                
                try
                {
                    string oString = "update DBCorona.dbo.[Member]  set  memberName=@pMemberName,memberTel1=@pMemberTel1,memberTel2=@pMemberTel2," +
                        " memberAddress= @pMemberAddress, memberEmail=@pMemberEmail where (memberID=@pMemberID) ";

                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@pMemberID", pObjParamter.objMember.memberID);
                    oCmd.Parameters.AddWithValue("@pMemberName", pObjParamter.objMember.memberName);
                    oCmd.Parameters.AddWithValue("@pMemberTel1", pObjParamter.objMember.memberTel1);
                    oCmd.Parameters.AddWithValue("@pMemberTel2", pObjParamter.objMember.memberTel2);
                    oCmd.Parameters.AddWithValue("@pMemberAddress", pObjParamter.objMember.memberAddress);
                    oCmd.Parameters.AddWithValue("@pMemberEmail", pObjParamter.objMember.memberEmail);

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
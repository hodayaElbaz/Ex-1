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
    /// This class intended for create  only one member
    /// </summary>
    public class CreateMemberResponse : ClassResponse
    {

    }
    public class CreateMemberParameter
    {
        public ClassMember objMember { get; set; }
    }
    public static class CreateMember
    {
        public static CreateMemberResponse Create(CreateMemberParameter pObjParamter)
        {
            CreateMemberResponse _response = new CreateMemberResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);
                
                try
                {
                string oString = "inssert DBCorona.dbo.[Member]  (memberID,memberName,memberTel1,memberTel2,memberAddress,memberEmail)  values" +
                                                                "(@pMemberID,@pMemberName,@pmemberTel1=@pMemberTel1,@pmemberTel2,@pMemberAddress,@pMemberEmail";

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
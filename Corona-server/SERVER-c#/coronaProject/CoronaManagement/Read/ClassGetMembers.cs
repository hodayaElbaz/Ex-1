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
    /// This class intended for geting all members
    /// קלאס לצורך הבאה של כל החברים
    /// </summary>
    /// 

     //כדי שיהיה לו רשימת שגיאות מערכת,הקלאס הנוכחי ירש ממנו
    public class GetMembersResponse : ClassResponse
    {
        public GetMembersResponse()
        {

            listMembers = new List<ClassMember>();
        }

        public List<ClassMember> listMembers;
    }

    //במידה ויש צורך שליפה לפי פרמטררים מסוימים 
    public class GetMembersParameter
    {
       
    }

    public static class GetMembers
    {
        public static GetMembersResponse Query(GetMemberParameter pObjParamter)
        {
            GetMembersResponse _response = new GetMembersResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);

            try
            {
                //שאילתה -לצורך שליפה מבסיס נתונים
                string oString = "Select * from DBCorona.dbo.[Member]  ";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                
                //נפתח חיבור לבסיס הנתונים
                myConnection.Open();
                ClassMember obj;
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    //כאן נשתמש בלולאה לצורך שליפת כל הנתונים  
                    while (oReader.Read())
                    {
                        obj = new ClassMember();

                        obj.memberID    = (int)oReader["memberID"];
                        obj.memberName  = oReader["memberName"].ToString();
                        obj.memberTel1  = oReader["memberTel1"].ToString();
                        obj.memberTel2  = oReader["memberTel2"].ToString();
                        obj.memberEmail = oReader["memberEmail"].ToString();
                        obj.memberAddress = oReader["memberAddress"].ToString();

                        //הוספת החבר לאוביקט של רספונס
                        _response.listMembers.Add(obj);
                    }
                }
                return _response;
            }
            //במידה ויש שגיאת מערכת,נוסיף אותו לרשימת השגיאות באוביקט רספונס
            catch (Exception ex)
            {
                _response.systemErrors.Add(ex.Message);
                return _response;
            }
            //נסגור את החיבור למסד נתונים
            finally
            {
                myConnection.Close();
            }              
        }              
      
    }
}
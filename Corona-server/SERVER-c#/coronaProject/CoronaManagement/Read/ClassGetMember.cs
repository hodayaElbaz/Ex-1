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
    /// This class intended for geting only one member's details
    /// קלאס לצורך הבאת פרטים של חבר אחד בלבד
    /// </summary>
    public class GetMemberResponse : ClassResponse
    {
        public GetMemberResponse()
        {

            memberObj = new ClassMember();
        }
      
        public ClassMember memberObj;
    }

    //הפרמטר שאיתו נשתמש
    public class GetMemberParameter
    {
        public int memberID { get; set; }
    }
    public static class GetMember
    {
        public static GetMemberResponse Query(GetMemberParameter pObjParamter)
        {
            GetMemberResponse _response = new GetMemberResponse();

            var con = WebConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection myConnection = new SqlConnection(con);
            
            try
            {
                //שאילתה -לצורך שליפה מבסיס הנתונים
                //לצורך אבטחה ,האופרטור @ מונע להזין נתונים ע"י המשתמש,מניעת פעולת זדון
                string oString = "Select * from DBCorona.dbo.[Member] where memberID=@pmemberID ";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                //השמה של הערך מהקומנד לצורך ביצוע התנאי בשאילה
                oCmd.Parameters.AddWithValue("@pmemberID", pObjParamter.memberID);
                
                //יצירת קשר עם בסיס הנתונים
                myConnection.Open();
                ClassMember obj;
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    //קריאת הנתונים מהטבלה,אוביקט אחד בלבד,ע"פ התנאי בשאילתה
                    oReader.Read();
                    {
                        obj = new ClassMember();

                        obj.memberID        = (int)oReader["memberID"];
                        obj.memberName      = oReader["memberName"].ToString();
                        obj.memberTel1      = oReader["memberName"].ToString();
                        obj.memberTel1      = oReader["memberTel1"].ToString();
                        obj.memberTel2      = oReader["memberTel2"].ToString();
                        obj.memberEmail     = oReader["memberEmail"].ToString();
                        obj.memberAddress   = oReader["memberAddress"].ToString();

                        _response.memberObj = obj;
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
            //סגירת הקשר עם מסד הנתונים
            finally
            {
                myConnection.Close();
            }              
        }              
      
    }
}
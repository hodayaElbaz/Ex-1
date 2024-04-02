using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using QueryServer.Quries;
using QueryServer.Updates;
using QueryServer.Create;
using QueryServer.Delete;
using QueryServer.Models;

namespace QueryServer
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        /*[WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }*/

        #region Queries
        [WebMethod]
        public GetMemberResponse ReadOneMember(GetMemberParameter pObjParamter)
        {
            return GetMember.Query(pObjParamter);
        }

        [WebMethod]
        public GetMemberExaminationResponse ReadAllMemberExaminations(GetMemberExaminationParameter pObjParamter)
        {
            return Quries.GetMemberExamination.Query(pObjParamter);
        }

        [WebMethod]
        public GetMembersResponse ReadMembers(GetMemberParameter pObjParamter)
        {
            return Quries.GetMembers.Query(pObjParamter);
        }
        #endregion

        #region Updates
        [WebMethod]
        public UpdateMemberResponse UpdateOneMember(UpdateMemberParameter pObjParamter)
        {
            return UpdateMember.Update(pObjParamter);
        }

        [WebMethod]
        public UpdateMemberExaminationResponse UpdateOneMemberExamination(UpdateMemberExaminationParameter pObjParamter)
        {
            return UpdateMemberExamination.Update(pObjParamter);
        }
        #endregion

        #region Create
        [WebMethod]
        public CreateMemberResponse CreateOneMember(CreateMemberParameter pObjParamter)
        {
            return CreateMember.Create(pObjParamter);
        }

        [WebMethod]
        public CreateMemberExaminationResponse CreateOneMemberExaminationResponse(CreateMemberExaminationParameter pObjParamter)
        {
            return CreateMemberExamination.Create(pObjParamter);
        }
        #endregion

        #region Delete
        [WebMethod]
        public DeleteMemberResponse DeleteOneMember(DeleteMemberParameter pObjParamter)
        {
            return DeleteMember.Delete(pObjParamter);
        }

        [WebMethod]
        public DeleteMemberExaminationResponse DeleteOneMemberExamination(DeleteMemberExaminationParameter pObjParamter)
        {
            return DeleteMemberExamination.Delete(pObjParamter);
        }

        #endregion

    }
}

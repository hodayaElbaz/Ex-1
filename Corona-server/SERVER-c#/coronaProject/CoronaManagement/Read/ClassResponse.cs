using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryServer.Quries
{
    //תגובה של המערכת,הודעות שגיאה במידה ויש
    public class ClassResponse
    {
        public ClassResponse()
        {
            systemErrors = new List<string>();
        }
        public List<String> systemErrors;
    }
}
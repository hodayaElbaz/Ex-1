using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryServer.Models
{
    public class ClassMember
    {
        public int memberID         { get; set; }
        public string memberName    { get; set; }
        public string memberTel1    { get; set; }
        public string memberTel2    { get; set; }
        public string memberAddress { get; set; }
        public string memberEmail   { get; set; }
    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueryServer.Models
{
    public class ClassExamination
    {
        public int memberID         { get; set; }
        public int examinationID    { get; set; }
        public DateTime dateTimeResult { get; set; }
        public bool result { get; set; }
        public DateTime dateTimeVaccination { get; set; } 
        public DateTime dateTimeaRecovery { get; set; }
        public string manufacturer { get; set; }
    }
}
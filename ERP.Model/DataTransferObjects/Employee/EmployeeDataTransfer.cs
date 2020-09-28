using ERP.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Model.DataTransferObjects
{
    public class EmployeeDataTransfer : Employee
    {
        public string Religion { get; set; }

        public string Department { get; set; }

        public string Group { get; set; }

        public string Nation { get; set; }

        public string Nationality { get; set; }

        public string Status { get; set; }

        public string Supervisor { get; set; }

        public string Position { get; set; }

        public string Bank { get; set; }

        public string Job { get; set; }

        public string LaborGroup { get; set; }

        public string Title { get; set; }

        public string Gender { get; set; }
    }
}

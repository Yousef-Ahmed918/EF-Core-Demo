using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Demo.Data.Models
{
    
    public class EmployeesDepartments
    {
        public int DepartmentId { get; set; }
        public int? EmployeeId { get; set; }
        public string  DepartmentName { get; set; }
        public string? EmployeeName { get; set; }
    }
}

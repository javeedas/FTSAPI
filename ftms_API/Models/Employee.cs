using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ftms_API.Models
{
    public class Employee
    {
        
        public int empId { get; set; }

    
        public string empName { get; set; }

  
        public string category { get; set; }

    
        public string tool { get; set; }


        public string designation { get; set; }

        public DateTime dob { get; set; }

    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Task.Models
{
    public class EmployeeModel
    {
        public int Eid {  get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name conatins letters only")]
        public string EName { get; set; }

        [Required(ErrorMessage = "EmployeeID is required")]
        public int EmployeeID { get; set; }
        //[Required(ErrorMessage = "DepartmentName is required")]
        public string Department { get; set; }
        //[Required(ErrorMessage = "Date of Birth is required")]
        
        public DateTime DOB { get; set; }


        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Phone is required")]
       
        public long Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[A-Za-z0-9\s]+$",ErrorMessage ="Address conatins only character and numbers no symbols")]
        public string EAddres { get; set; } 

        public int deptId {  get; set; }

        public string deptName { get; set; }

    }
}
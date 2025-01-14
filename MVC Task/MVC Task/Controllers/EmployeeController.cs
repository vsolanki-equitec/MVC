using MVC_Task.Models;
using MVC_Task.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Web.UI;

namespace MVC_Task.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepo _employeeRepo = new EmployeeRepo();
        private readonly EmployeeRepo emph = new EmployeeRepo();
        // GET: Employee

        public EmployeeController (EmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public EmployeeController()
        {

        }

        public ActionResult Index(int page=1)
        {
           
            int pageSize = 5;
            var employe = _employeeRepo.GetAllEmployees();
            var employes = employe.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalCount = employe.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            return View(employes);
        }


        [HttpGet]
        public ActionResult GetElementById(int id)
        {
            var employe = _employeeRepo.GetElementById(id);
            return View(employe);
        }

        public ActionResult AddEmployee()
        {
            string con = ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString;
            using (var conn = new SqlConnection(con))
            {
                string sql = "select * from Department";
                var ex = conn.Query<EmployeeModel>(sql);
                ViewBag.dept = ex;
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel em)
        {
            
            
                _employeeRepo.AddEmployee(em);
                return RedirectToAction("Index");
            
          
          
        }
      



        public ActionResult DeleteEmployee(int id)
        {
            _employeeRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
     
        public ActionResult DeletedData()
        {
            var emp = _employeeRepo.DeletedItems();
            return View(emp);
        }

        public ActionResult DeleteBack(int id)
        {
            _employeeRepo.DeleteBack(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            
            return View(emph.GetElementById(id));
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel em)
        {
            _employeeRepo.editData(em);
            return RedirectToAction("Index");
        }
    }
}
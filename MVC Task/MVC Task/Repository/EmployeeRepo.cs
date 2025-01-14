using MVC_Task.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace MVC_Task.Repository
{
    public class EmployeeRepo
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["EmpDB"].ConnectionString;

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                string sql = "select e.EName,e.EmployeeId,e.Eid,d.deptId,d.deptName,e.DOB,e.Age,e.Gender,e.Phone,e.EAddres from employes e join Department d on e.deptId = d.deptId";
                return connection.Query<EmployeeModel>(sql).ToList();
            }
        }

        public EmployeeModel GetElementById(int Eid)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                string sql = "select e.Eid, e.EName,e.EmployeeId,d.deptName,e.DOB,e.Age,e.Gender,e.Phone,e.EAddres from employes e join Department d on e.deptId = d.deptId where Eid=@Eid";
                return connection.QueryFirstOrDefault<EmployeeModel>(sql, new {Eid});
            }
        }
        public void AddEmployee(EmployeeModel em)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO employes (EName, EmployeeID, deptId, DOB, Gender, Phone, EAddres) " +
                         "VALUES (@EName, @EmployeeID, @deptId, @DOB, @Gender, @Phone, @EAddres)";

                connection.Execute(sql, new
                {

                    em.EName,
                    em.EmployeeID,
                    em.deptId,
                    em.DOB,
                    em.Gender,
                    em.Phone,
                    em.EAddres,
                });
            }
        }
        public void DeleteEmployee(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "delete from employes where Eid=@id";
                connection.Execute(sql, new { id = @id });
            }
        }

        public IEnumerable<EmployeeModel> DeletedItems()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                string sql = "select * from employesBackup";
                return connection.Query<EmployeeModel>(sql).ToList();
            }
        }


        public void DeleteBack(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "delete from employesBackup where Eid=@id";
                connection.Execute(sql, new { id = @id });
            }
        }
        public void editData(EmployeeModel em)
        {
          
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "update employes set EName=@EName,EmployeeID=@EmployeeID,Gender=@Gender,Phone=@Phone,EAddres=@EAddres WHERE Eid =@Eid";

                connection.Execute(sql, em);

                
            }
        }
    }
    }

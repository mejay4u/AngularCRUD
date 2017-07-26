using AngularCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AngularCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee  
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>  
        ///   
        /// Get All Employee  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult Get_AllEmployee()
        {
            using (AngularEntiti Obj = new AngularEntiti())
            {
                List<Employee> Emp = Obj.Employees.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Get Employee With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult Get_EmployeeById(string Id)
        {
            using (AngularEntiti Obj = new AngularEntiti())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Employees.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Insert New Employee  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public string Insert_Employee(Employee Employe)
        {
            if (Employe != null)
            {
                using (AngularEntiti Obj = new AngularEntiti())
                {
                    Obj.Employees.Add(Employe);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }
        /// <summary>  
        /// Delete Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Delete_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (AngularEntiti Obj = new AngularEntiti())
                {
                    var Emp_ = Obj.Entry(Emp);
                    if (Emp_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.Employees.Attach(Emp);
                        Obj.Employees.Remove(Emp);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Update_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using (AngularEntiti Obj = new AngularEntiti())
                {
                    var Emp_ = Obj.Entry(Emp);
                    Employee EmpObj = Obj.Employees.Where(x => x.Id == Emp.Id).FirstOrDefault();
                    EmpObj.Name = Emp.Name;
                    EmpObj.Salary = Emp.Salary;
                    EmpObj.Gender = Emp.Gender;
                    EmpObj.City = Emp.City;
                    EmpObj.DateofBirth = Emp.DateofBirth;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
    }
}
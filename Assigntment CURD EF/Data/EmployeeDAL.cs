using Assigntment_CURD_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigntment_CURD_EF.Data
{
    public class EmployeeDAL
    {
        ApplicationDbContext db;
        public EmployeeDAL(ApplicationDbContext db)
        {
            this.db = db;
        }


        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }


        public Employee GetEmployeeById(int id)
        {
            Employee p = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }


        public int AddEmployee(Employee emp)
        {
            // add prod object in the produts collections
            db.Employees.Add(emp);
            // reflect the change in DB
            int result = db.SaveChanges();
            return result;
        }



        public int UpdateEmployee(Employee emp) // new data
        {
            int result = 0;
            // p object hold old data
            Employee p = db.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = emp.Name;
                p.Salary = emp.Salary;
                result = db.SaveChanges();
            }
            return result;
        }


        public int DeleteEmployee(int id)
        {
            int result = 0;
            Employee p = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                db.Employees.Remove(p);
                result = db.SaveChanges();
            }
            return result;
        }






    }
}

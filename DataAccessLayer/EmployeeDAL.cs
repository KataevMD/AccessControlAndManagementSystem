using AcmsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class EmployeeDAL
    {
        //public void AddEmployee(AcmsAPI.Entities )
        //{

        //}
        public List<Employee> GetAllEmployee()
        {
            using AccessСontrolАndManagementInformationSystemContext db = new();
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
            using AccessСontrolАndManagementInformationSystemContext db = new();
            return db.Employees.FirstOrDefault(e => e.EmployeeGuid == id);
        }

        public Employee GetEmployeeByLoginAndPassword(string login, string hashPassword)
        {
            Employee employee = new Employee();
            using (AccessСontrolАndManagementInformationSystemContext db = new())
            {
                employee = db.Employees.Where(a => a.Login == login && a.Password == hashPassword).FirstOrDefault();
            }
            return employee;
        }
        public void AddEmployee(Employee employee)
        {
            using (AccessСontrolАndManagementInformationSystemContext db = new())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }
    }
}

using AcmsAPI.Entities;
using AutoMapper;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer
{
    public class EmployeeBLL
    {
        private DataAccessLayer.EmployeeDAL _EmployeeDAL;
        private Mapper _EmployeeMapper;

        public EmployeeBLL()
        {
            _EmployeeDAL = new DataAccessLayer.EmployeeDAL();
            var _configEmployee = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeModel>().ReverseMap());
            _EmployeeMapper = new Mapper(_configEmployee);
        }

        public void AddEmployee(EmployeeModel employeeModel)
        {
            Employee employee = _EmployeeMapper.Map<EmployeeModel, Employee>(employeeModel);
            employee.Password = Hash.GenerateHashPassword(employee.Password);
            _EmployeeDAL.AddEmployee(employee);
        }

        public EmployeeModel GetEmployeeById(Guid id)
        {
            var employeeEntity = _EmployeeDAL.GetEmployeeById(id);

            EmployeeModel employeeModel = _EmployeeMapper.Map<Employee, EmployeeModel>(employeeEntity);

            return employeeModel;
        }

        public EmployeeModel GetEmployeeByLoginAndPassword(string login, string password)
        {
            var employeeEntity = _EmployeeDAL.GetEmployeeByLoginAndPassword(login, Hash.GenerateHashPassword(password));

            EmployeeModel employeeModel = _EmployeeMapper.Map<Employee, EmployeeModel>(employeeEntity);

            return employeeModel;
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            var employeesFromDB = _EmployeeDAL.GetAllEmployee();
            List<EmployeeModel> employeesModel = _EmployeeMapper.Map<List<Employee>, List<EmployeeModel>>(employeesFromDB);
            return employeesModel;
        }



    }
}

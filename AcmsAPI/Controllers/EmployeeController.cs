using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcmsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private BusinessLogicLayer.EmployeeBLL _EmployeeBLL;
        public EmployeeController() 
        {
            _EmployeeBLL = new BusinessLogicLayer.EmployeeBLL();
        }

        //[HttpPost(Name = "AddEmployee")]
        //public async Task<ActionResult> AddEmployee(ViewModels.EmployeeAccount employeeAccount)
        //{
        //    if (employeeAccount == null)
        //    {
        //        return BadRequest();
        //    }

        //    _EmployeeBLL.AddEmployee(employeeAccount.EmployeeModel, employeeAccount.AuthorizationModel);
        //}

        [Authorize(Roles = "1")]        
        [HttpGet(Name = "getEmployees")]
        public ActionResult<List<EmployeeModel>> GetAllEmployees()
        {
            return Ok(_EmployeeBLL.GetAllEmployee());
        }

        [HttpGet(Name = "getEmployeeById")]
        public ActionResult<EmployeeModel> GetEmployeeById(Guid id)
        {
            var employee = _EmployeeBLL.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound("Invalid ID");
            }
            return Ok(employee);
        }
    }
}

using AcmsAPI.ViewModels;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AcmsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthorizeController : Controller
    {
        private BusinessLogicLayer.EmployeeBLL _EmployeeBLL;
        public AuthorizeController()
        {
            _EmployeeBLL = new BusinessLogicLayer.EmployeeBLL();
        }

        [HttpGet(Name = "Authorization")]
        public ActionResult Authorization(string login, string password)
        {
            var employee = _EmployeeBLL.GetEmployeeByLoginAndPassword(login, password);
            if (employee == null)
                return NotFound();
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, employee.Login),
                                            new Claim(ClaimTypes.Role, employee.PostId.ToString())};
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

        [HttpPost(Name = "Registration")]
        public ActionResult Registration(EmployeeModel newEmployee)
        {

            _EmployeeBLL.AddEmployee(newEmployee);       
            return Ok();
        }
    }
}

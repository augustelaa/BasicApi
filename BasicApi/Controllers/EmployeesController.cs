using BasicApi.Application.RequestModels;
using BasicApi.DataBase.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        public IEnumerable<EmployeeRequestModel> Get()
        {
            return new EmployeeRequestModel[] {  };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] EmployeeRequestModel employee)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeRequestModel employee)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

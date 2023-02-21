using BasicApi.Application.RequestModels;
using BasicApi.DataBase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BasicApi.Controllers
{
    /// <summary>
    /// The EmployeesController controllers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;

        /// <summary>
        /// 
        /// </summary>
        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        // GET api/employees/{id}
        /// <summary>
        /// Searchs one empployee by the given id.
        /// </summary>
        /// <param name="id">Eployee's id</param>
        /// <returns>The employee</returns>
        /// <response code="200">Employee</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeRequestModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<EmployeeRequestModel> Get([Range(1, long.MaxValue)] long id)
        {
            
            try
            {
                var employee = _employeesRepository.Select(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    Id = employee.Id,
                    Age = employee.Age,
                    Name = employee.Name
                });
            }
            catch(Exception)
            {
                return Problem("Internal error, please contact us.", statusCode: 500);
            }
        }

        // POST api/employees
        /// <summary>
        /// Creates one empployee.
        /// </summary>
        /// <param name="employee"></param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] EmployeeRequestModel employee)
        {
            var result = _employeesRepository.Insert(employee.ToSchema());
            return Created($"https://localhost:7224/api/Employees/{result}", result);
        }

        // PUT api/employees/{id}
        /// <summary>
        /// Updates one empployee.
        /// </summary>
        /// <param name="id">Eployee's id</param>
        /// <param name="employee"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] EmployeeRequestModel employee)
        {
            if (id <= 0)
            {
                return BadRequest("Field id is not valid.");
            }
            employee.Id = id;
            _employeesRepository.Update(employee.ToSchema());
            return Ok();
        }

        // DELETE api/employees/{id}
        /// <summary>
        /// Deletes one empployee.
        /// </summary>
        /// <param name="id">Eployee's id</param>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete([Range(1, long.MaxValue)] long id)
        {
            _employeesRepository.Delete(id);
            return Accepted();
        }
    }
}

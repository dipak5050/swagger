using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger.Controllers
{
    public class EmployeeController : Controller
	{
		/// <summary>
		/// Creates an Employee.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /Employee
		///     {
		///       "firstName": "Test",
		///       "lastName": "Name",
		///       "emailId": "Test.Name@gmail.com"
		///     }
		/// </remarks>
		/// <param name="employee"></param>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		[HttpGet("WithOutId")]
		[Produces("application/json")]
		public IEnumerable<Employe> Get()
		{
			return (IEnumerable<Employe>)GetEmployeesDeatils();
		}

		/// <summary>
		/// Creates an Employee.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /Employee
		///     {
		///       "firstName": "Test",
		///       "lastName": "Name",
		///       "emailId": "Test.Name@gmail.com"
		///     }
		/// </remarks>
		/// <param name="employee"></param>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		[HttpGet("{id}")]
		[Produces("application/json")]
		public Employe Get(int id)
		{
			return GetEmployeesDeatils().Find(e => e.Id == id);
		}



		private List<Employe> GetEmployeesDeatils()
		{
			return new List<Employe>()
		{
			new Employe()
			{
				Id = 1,
				FirstName= "Shubham",
				LastName = "BOrkar",
				EmailId ="S@gmail.com"
			},
			new Employe()
			{
				Id = 2,
				FirstName= "Dipak",
				LastName = "Bapodara",
				EmailId ="d@gmail.com"
			}
		};
		}
		/// <summary>
		/// Creates an Employee.
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /Employee
		///     {
		///       "firstName": "Test",
		///       "lastName": "Name",
		///       "emailId": "Test.Name@gmail.com"
		///     }
		/// </remarks>
		/// <param name="employee"></param>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		[HttpPost("Insert")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
		public IActionResult Post([FromBody] Employe employee)
		{
			if (employee == null)
			{
				return BadRequest("Invalid data provided.");
			}

			
			var createdEmployee = new Employe()
			{
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				EmailId = employee.EmailId
			};

			return CreatedAtAction("Get", new { id = createdEmployee.Id }, createdEmployee);
		}
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
		public IActionResult Delete(int id)
		{
			// Your implementation here
			// Check if the employee exists and delete them

			//if (Employe==null)
			//{
			//	return NotFound("Employee not found");
			//}

			// If deletion is successful, return a 204 No Content response
			return NoContent();
		}


	}
}

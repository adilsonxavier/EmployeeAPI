using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeRegister.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EmployeeRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeeController(EmployeeDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromForm]Employee employee)
        {
            employee.Image = await SaveImage(employee.ImageFile);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();


            return StatusCode(201);
            // return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
                      
            // Obs : se por o nome errado do método "GetEmployee" da erro 500 de servidor no postman mas o objeto é alimentado
            // no banco mesmo assim
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        [NonAction]
        // public string SaveImage(IFormFile imageFile, HttpContext httpContext)
        // Ao invéz de receber o parânetro httpContext o autor achou melhor usar um objeto IWebHostEnvironment que foi injetado 
        // com injeção de dependência no construtor
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            //Procedimento para deixar o nome da imagem sendo único:
            //Primeiro pega o nome da imagem, tira a extensão, pega os 10 primeiros catacteres e troca espaços por hifens
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(" ","-");
            // Depois adiciona a data com milisegundos e adiciona a extensão ( veja que não preciso concatenar o ponto )
            imageName = imageName + DateTime.Now.ToString("yyyymmddssfff") + Path.GetExtension(imageFile.FileName);

            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "images", imageName);

            using(var fileStream = new FileStream(imagePath, FileMode.Create))
            {
               await  imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo_EF.Data;
using Demo_EF.Models;
using Microsoft.IdentityModel.Tokens;

namespace Demo_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public GradesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()//obtiene todas las instancias de Grade de la base de datos y las devuelve como una lista.
        {
            return await _context.Grades.ToListAsync();//es un método asíncrono de Entity Framework Core que convierte la consulta en una lista.
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id) //busca una instancia de Grade por su id
        {
            var grade = await _context.Grades.FindAsync(id);//es un método asíncrono que busca una entidad por su clave primaria.

            if (grade == null)
            {
                return NotFound(); //Si grade es null, devuelve un NotFound() 
            }

            return grade; //de lo contrario, devuelve la instancia de Grade.
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")] 
        public async Task<IActionResult> PutGrade(int id, Grade grade)//PutGrade actualiza una instancia de Grade
        {
            if (id != grade.GradeId) //Verifica que el id del parámetro coincida con el GradeId de la entidad grade
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified; //Marca la entidad grade como modificada con EntityState.Modified

            try
            {
                await _context.SaveChangesAsync();
                //Intenta guardar los cambios.  si no, devuelve NotFound()
            }
            catch (DbUpdateConcurrencyException) //Si ocurre una DbUpdateConcurrencyException, verifica si la entidad Grade todavía existe;
            {
                if (!GradeExists(id))
                {
                    return NotFound(); //, de lo contrario, lanza la excepción.
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); //Devuelve NoContent() si la actualización es exitosa.
        }

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade) //agrega una nueva instancia de Grade a la base de datos.
        {
            _context.Grades.Add(grade); //Añade la entidad grade al contexto 
            await _context.SaveChangesAsync();//Guarda los cambios de forma asíncrona

            return CreatedAtAction("GetGrade", new { id = grade.GradeId }, grade);
            //Devuelve CreatedAtAction para indicar que se ha creado una nueva entidad, proporcionando la ubicación del nuevo recurso.
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)//elimina una instancia de Grade por su id
        {
            var grade = await _context.Grades.FindAsync(id); //Busca la entidad con FindAsync(id). Si no la encuentra, devuelve NotFound().
            if (grade == null)
            {
                return NotFound();
            }

            _context.Grades.Remove(grade); //Elimina la entidad con _context.Grades.Remove(grade).
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }
        //GradeExists es un método privado que verifica si una instancia de Grade existe en la base de datos por su id.
        //Utiliza Any para comprobar si alguna entidad Grade tiene el id especificado.
    }
}

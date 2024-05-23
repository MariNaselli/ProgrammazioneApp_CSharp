using AdopcionesApi.Services;
using AdopcionesDAL;
using AdopcionesModels;
using Microsoft.AspNetCore.Mvc;

namespace AdopcionesApi.Controllers
{
    [Route("api/animales")]
    [ApiController]
    public class AnimalesController : ControllerBase
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        private readonly SqlAnimales _sqlAnimales;
        private readonly SqlAnimalesTipos _sqlAnimalesTipos;

        public AnimalesController(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
            string connectionString = _connectionStringProvider.GetConnectionString();
            _sqlAnimales = new SqlAnimales(connectionString);
            _sqlAnimalesTipos = new SqlAnimalesTipos(connectionString);
        }


        [HttpGet(Name = "GetAnimalesList")]
        public async Task<ActionResult<List<Animal>>> Get(string textoBuscar)
        {
            try
            {
                if (string.IsNullOrEmpty(textoBuscar))
                {
                    textoBuscar = string.Empty;
                }

                var animales = await _sqlAnimales.GetAnimalesListAsync(textoBuscar);
                return Ok(animales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost]
        public IActionResult Insert(Animal animal)
        {
            try
            {
                _sqlAnimales.InsertAnimal(animal);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Animal animal)
        {
            try
            {
                animal.Id_animal = id;
                _sqlAnimales.UpdateAnimal(animal);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _sqlAnimales.DeleteAnimal(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("tipos", Name = "GetAnimalesTiposList")]
        public IActionResult GetAnimalesTiposList()
        {
            try
            {
                // Llamamos al método en SqlAnimalesTipos para obtener los tipos de animales
                var tiposAnimales = _sqlAnimalesTipos.GetAnimalesTiposList();
                return Ok(tiposAnimales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



    }
}

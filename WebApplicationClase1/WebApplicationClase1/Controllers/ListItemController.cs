using Microsoft.AspNetCore.Mvc;
using WebApplicationClase1.Models;
using static System.Net.WebRequestMethods;

namespace WebApplicationClase1.Controllers
{

    [ApiController]
    [Route("[controller]/lista/{listaId:guid}")]
    public class ListItemController : ControllerBase
    {
        private readonly IMyStorage myStorage;

        public ListItemController(IMyStorage myStorage)
        {
            this.myStorage = myStorage;
        }


        [HttpPut]
        public IActionResult Put(Guid listaId, ListItem entity)
        {
            if (listaId == null || listaId.Equals(Guid.Empty))
            {
                return BadRequest("Specificare Id lista");
            }
            if (!(entity.Id == null || entity.Id.Equals(Guid.Empty)))
            {
                return BadRequest("Non usare Id");
            }
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return BadRequest("Inserire il nome");
            }

            var lista = myStorage._ToDoList.SingleOrDefault(pippo => pippo.Id == listaId);
            if (lista == null)
                return NotFound();

            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;
            lista.ListItems.Add(entity);

            return Ok(lista);
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_ListoneGiordano.ToList());
        //}

        //[HttpGet]
        //[Route("{id:guid}")]
        //public IActionResult Get(Guid id)
        //{
        //    if (id == Guid.Empty | id == null)
        //        return BadRequest();

        //    //var entity = _ListoneGiordano.FirstOrDefault(x => x.Id == id);
        //    //var entity = _ListoneGiordano.Any(pippo => pippo.Id == id);
        //    //var entity = _ListoneGiordano.All(pippo => pippo.Id == id);

        //    var entity = _ListoneGiordano.SingleOrDefault(pippo => pippo.Id == id);
        //    if (entity == null)
        //        return NotFound();

        //    return Ok(entity);
        //}

        //[HttpPost]
        //[Route("{id:guid}")]
        //public IActionResult Post(Guid Id, string nome, string descrizione)
        //{
        //    if (Id == null || Id.Equals(Guid.Empty))
        //    {
        //        return BadRequest("Bad Id");
        //    }
        //    if (string.IsNullOrWhiteSpace(nome))
        //    {
        //        return BadRequest("nome non valido");
        //    }
        //    if (string.IsNullOrWhiteSpace(descrizione))
        //    {
        //        return BadRequest("descrizione non valida");
        //    }

        //    var lista = _ListoneGiordano.SingleOrDefault(pippo => pippo.Id == Id);
        //    if (lista == null)
        //        return NotFound();
        //    lista.Name = nome;
        //    lista.Description = descrizione;
        //    lista.CreatedDate = DateTime.Now;

        //    return Ok(lista);
        //}

        //[HttpDelete]
        //public IActionResult Delete(Guid Id)
        //{
        //    if (Id == null || Id.Equals(Guid.Empty))
        //    {
        //        return BadRequest("bad req.");
        //    }
        //    var lista = _ListoneGiordano.SingleOrDefault(pippo => pippo.Id == Id);
        //    if (lista == null)
        //    {
        //        return NotFound("passo di qui");
        //    }
        //    _ListoneGiordano.Remove(lista);
        //    return NoContent();
        //}
    }
}



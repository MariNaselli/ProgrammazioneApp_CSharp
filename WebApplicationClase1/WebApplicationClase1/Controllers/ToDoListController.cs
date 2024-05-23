using Microsoft.AspNetCore.Mvc;
using WebApplicationClase1.Models;

namespace WebApplicationClase1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        //private static List<ToDoList> _ToDoList { get; set; } = new List<ToDoList>();

        private readonly IMyStorage myStorage;

        public ToDoListController(IMyStorage myStorage)
        {
            this.myStorage = myStorage;
        }


        //[HttpPut]
        //public IActionResult Put(ToDoList entity)
        //{
        //    if (entity.id == null || entity.id.Equals(Guid.Empty))
        //    {
        //        entity.id = Guid.NewGuid();
        //        entity.CreateDate = DateTime.Now;
        //        _ToDoList.Add(entity);
        //        return Ok(entity);

        //    }
        //    return BadRequest("Non usare Id");


        //    if (string.IsNullOrWhitSpace(entity.Name))
        //    {
        //        return BadRequest("Inserire il nome");
        //    }

        //}

        [HttpPut]
        public IActionResult Put(ToDoList entity)
        {
            if (!(entity.Id == null || entity.Id.Equals(Guid.Empty)))
            {
                return BadRequest("Non usare Id");
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                return BadRequest("Inserire il nome");
            }
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;
            //_ToDoList.Add(entity);
            myStorage._ToDoList.Add(entity);
            return Ok(entity);
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_ToDoList.ToList());
        //}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(myStorage._ToDoList.ToList());
        }


        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult Get(Guid Id)
        {
            if (Id == Guid.Empty | Id == null)
            {
                return BadRequest();
            }
            //firstOrDe.. el primero.. 
            //var entity = _ToDoList.SingleOrDefault(t => t.Id == Id);//busca un solo elemento segun lo que le paso en ()
            //if (entity == null)
            //    return NotFound();

            //return Ok(Id);

            var entity = myStorage._ToDoList.SingleOrDefault(pippo => pippo.Id == Id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        [Route("{id:guid}")]
        public IActionResult Post(Guid Id, string Name, string Description)
        {
            if (Id == null || Id.Equals(Guid.Empty))
            {
                return BadRequest("Bad Id");
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest("Nome non valido");
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                return BadRequest("Descrizione non valida");
            }

            //var lista = _ToDoList.SingleOrDefault(t => t.Id == Id);
            //if (lista == null)
            //{
            //    return NotFound();
            //}

            //lista.Name = Name;
            //lista.Description = Description;
            //lista.CreatedDate = DateTime.Now;

            //return Ok(lista);

            var lista = myStorage._ToDoList.SingleOrDefault(pippo => pippo.Id == Id);
            if (lista == null)
                return NotFound();
            lista.Name = Name;
            lista.Description = Description;
            lista.CreatedDate = DateTime.Now;

            return Ok(lista);
        }

        //[HttpDelete]
        //public IActionResult Delete(Guid Id)
        //{
        //    if (Id == null || Id.Equals(Guid.Empty))
        //    {
        //        return BadRequest();
        //    }
        //    var lista = _ToDoList.SingleOrDefault(t => t.Id == Id);
        //    if (lista == null)
        //    {
        //        return NotFound("bad req.");
        //    }

        //    return NoContent();

        //}

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            if (Id == null || Id.Equals(Guid.Empty))
            {
                return BadRequest("bad req.");
            }
            var lista = myStorage._ToDoList.SingleOrDefault(pippo => pippo.Id == Id);
            if (lista == null)
            {
                return NotFound("passo di qui");
            }
            myStorage._ToDoList.Remove(lista);
            return NoContent();
        }

    }
}



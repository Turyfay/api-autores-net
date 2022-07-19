using Microsoft.AspNetCore.Mvc;
using autores_api.Entidades;
using autores_api.Data;
using Microsoft.EntityFrameworkCore;

namespace autores_api.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public AutoresController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await dbContext.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            dbContext.Add(autor);
            await dbContext.SaveChangesAsync();
            return Ok();

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Autor autor)
        {
            if(autor.Id != id)
            return BadRequest("El ID del autor no coincide con el id de la URL");

            dbContext.Update(autor);
            await dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id){
            var existe = await dbContext.Autores.AnyAsync(x => x.Id == id);

            if(!existe)
            return NotFound();

            dbContext.Remove(new Autor(){Id = id});
            await dbContext.SaveChangesAsync();
            return Ok();
        }


    }
}
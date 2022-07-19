using autores_api.Data;
using autores_api.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace autores_api.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public LibrosController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id){

            return await dbContext.Libros.FirstOrDefaultAsync(x => x.Id == id);

        }

    }
}
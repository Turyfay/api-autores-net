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


    }
}
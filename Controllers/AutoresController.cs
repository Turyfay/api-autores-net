using Microsoft.AspNetCore.Mvc;
using autores_api.Entidades;

namespace autores_api.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Autor>> Get(){
            return new List<Autor>() {
                new Autor() {Id=1,Nombre="Claudia"},
                new Autor(){Id=2,Nombre="David"}
            };
        }
        
        
    }
}
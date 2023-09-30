using Microsoft.AspNetCore.Mvc;

namespace Parcial2API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class Parcial2Api : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Models.VistaElecciones2019> Get()
        {
            using (var db = new Models.Ms101720Context())
            {
                IEnumerable<Models.VistaElecciones2019> EleccionesResult = db.VistaElecciones2019s.ToList();
                return EleccionesResult;
            }
        }
    }
}

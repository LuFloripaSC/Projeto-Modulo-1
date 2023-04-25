using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
        }

        [HttpPut] ActionResult Put(string id) 
        {
            return Ok();
        }
        [HttpDelete] ActionResult Delete() 
        {
            return Ok();
        }
            
    }
}

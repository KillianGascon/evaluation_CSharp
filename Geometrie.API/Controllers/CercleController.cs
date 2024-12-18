using Geometrie.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Cercle_Controller : Controller
    {
        private readonly ICercle_Service service;

        public Cercle_Controller(ICercle_Service service)
        {
            this.service = service;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Cercle_DTO> GetAllCercles()
        {
            return service.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public Cercle_DTO? GetCercleById(int id)
        {
            return service.GetById(id);
        }

        [HttpPost("Add")]
        public Cercle_DTO AddCercle(Cercle_DTO cercle)
        {
            return service.Add(cercle);
        }

        [HttpPost("DeleteById")]
        public IActionResult DeleteCercle(int id)
        {
            return Ok(service.Delete(id));
        }

        [HttpPost("DeleteByObject")]
        public IActionResult DeleteCercle(Cercle_DTO cercle)
        {
            return Ok(service.Delete(cercle));
        }

        [HttpPost("Update")]
        public Cercle_DTO UpdateCercle(Cercle_DTO cercle)
        {
            return service.Update(cercle);
        }

        [HttpPost("CalculateArea")]
        public double CalculerAireCercle(Cercle_DTO cercle)
        {
            return service.CalculerAire(cercle);
        }
    }
}

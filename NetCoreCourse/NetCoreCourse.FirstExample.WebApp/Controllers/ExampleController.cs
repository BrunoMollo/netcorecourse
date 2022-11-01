using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreCourse.FirstExample.WebApp.Configuration;

namespace NetCoreCourse.FirstExample.WebApp.Controllers
{
    


    [Route("api/[controller]")] //Este decorador permite que el Middleware UseRouting pueda encontrar este endpoint.
    //Mira! Estamos heredando de ControllerBase
    public class ExampleController : ControllerBase

    {
        private readonly NewSection newSection;

        public ExampleController(IOptions<NewSection> section) 
        {
            this.newSection = section?.Value
                ?? throw new ArgumentNullException("NewSection was not properly set."); ;
        }

        [HttpGet]
        public IActionResult Hey()
        {
            return Ok("Hola Dev!.");
        }

        [HttpGet("another")]
        public IActionResult AnotherHey()
        {
            return Ok("Hey Este es otra accion de tu controlador.");
        }


        [HttpGet("bruno")]
        public IActionResult BrunoHey() => Ok("Hola soy Bruno");

        [HttpGet("newSection")]
        public IActionResult sendNewSection() => Ok(this.newSection);
        
    }
}
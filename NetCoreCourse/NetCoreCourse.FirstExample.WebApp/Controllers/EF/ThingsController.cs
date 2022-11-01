using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using NetCoreCourse.FirstExample.WebApp.DataAccess;
using NetCoreCourse.FirstExample.WebApp.Entities;
using System.Xml;

namespace NetCoreCourse.FirstExample.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ThingsController : ControllerBase
    {
        private readonly ThingsContext thingsContext;

        public ThingsController(ThingsContext context)
        {
            thingsContext = context;
        }

        [HttpPost]
        public Thing Create([FromBody]Thing thing) //Tengamos presente que normalmente las entidades NO se utilizan como request de APIs
        {
            thingsContext.Things.Add(thing);
            thingsContext.SaveChanges();

            return thing; //Observar que devuelve el ID. Como es posible?
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Remove(int id)
        {
            var cat = thingsContext.Things.Find(id);
            if(cat is null)
                return NotFound();

            thingsContext.Things.Remove(cat);
            thingsContext.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Thing>> GetAll()
        {
            return thingsContext.Things.ToList();
        }

        [HttpPut("{id}")]
        public IActionResult updateThing(int id, [FromBody] Thing thing) {
            if (id <= 0)
                return BadRequest("Id must be higher than 0");

            try {
                thing.Id = id;
                thingsContext.Update(thing);
                thingsContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
  
        }

        [HttpGet("search")]
        public IActionResult GetByCategoryId([FromQuery] int categoryId)
        {
            try
            {
                var thing = thingsContext.Things.FirstOrDefault(thing => thing.CategoryId == categoryId);
                return Ok(thing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getThing(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be higher than 0");

            try
            {
                var thing=thingsContext.Things.FirstOrDefault(thing => thing.Id == id);
                return Ok(thing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
    }
}
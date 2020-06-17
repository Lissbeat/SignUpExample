using System.Linq;
using assignment_5.Data;
using assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Xml;

namespace assignment_5.Controllers
{
   
    [Route("api/Participants")] 
    [ApiController] //hele klassen er en api kontroller, trenger ikke s
    public class Participants: ControllerBase
    {
        private readonly StoreDbContext _db;

        public Participants(StoreDbContext db)
        {
            _db = db; 
        }

        //gets all
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_db.Event.ToList());
        }

        //
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //search for the given participants
            var signup = _db.Event.Find(id); 
            //check if it exists
            if (signup==null)

            {
                return NotFound(); 
            }
            return Ok(signup); 
        }

        [HttpPost]
        public IActionResult Post(Signup signup)
        {
            //Check if id is set
            if (signup.Id != 0)
            {
                return BadRequest(); 
            }
            //Add product to database
            _db.AddRange(signup);
            _db.SaveChanges();
          
            // Return 201 Created with the location of the new item
            return CreatedAtAction(nameof(Get), new { id = signup.Id }, signup);

        }

        //Update
        [HttpPut("{id}")]
        public IActionResult Put(Signup signup)
        {
            // Return 404 Not Found if the item isn't in the database
            if (!_db.Event.Any(p => p.Id == signup.Id))
                return NotFound();

            // Product exists, so let's update it
            _db.Update(signup);
            _db.SaveChanges();

            // Return the modified item with 200 OK
            return Ok(signup);
        }
        // Handles DELETE requests to /api/Products/<id>, e.g. /api/Products/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Look for the item we are deleting
            var @signup = _db.Event.Find(id);

            // Return 404 Not Found if the item isn't in the database
            if (@signup == null)
                return NotFound();

            // Product exists, so let's remove it
            _db.Remove(@signup);
            _db.SaveChanges();

            // Return the deleted item with 200 OK
            return Ok(@signup);
        }

    }
}
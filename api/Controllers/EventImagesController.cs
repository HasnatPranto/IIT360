using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IIT360_api.Models;

namespace IIT360_api.Controllers
{
    [Route("api/EventImages/[action]")]
    [ApiController]
    public class EventImagesController : ControllerBase
    {
        private readonly iit360Context _context;

        public EventImagesController(iit360Context context)
        {
            _context = context;
        }

        // GET: api/EventImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventImage>>> GetEventImage()
        {
            return await _context.EventImage.ToListAsync();
        }

        // GET: api/EventImages/5
      /*  [HttpGet("{id}")]
        public async Task<ActionResult<EventImage>> GetEventImage(int id)
        {
            var eventImage = await _context.EventImage.FindAsync(id);

            if (eventImage == null)
            {
                return NotFound();
            }

            return eventImage;
        }*/

        [HttpGet("{event_id}")]
        public async Task<IActionResult> GetEventImages(int event_id) {

            var i = _context.EventImage.Where(s => s.FkEventEvemge == event_id).ToList();
            return Ok(i);
        }
        // PUT: api/EventImages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutEventImage(int id, EventImage eventImage)
        {
            if (id != eventImage.IdeventImage)
            {
                return BadRequest();
            }

            _context.Entry(eventImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventImages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventImage>> PostEventImage(EventImage eventImage)
        {
            _context.EventImage.Add(eventImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventImage", new { id = eventImage.IdeventImage }, eventImage);
        }

        // DELETE: api/EventImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventImage>> DeleteEventImage(int id)
        {
            var eventImage = await _context.EventImage.FindAsync(id);
            if (eventImage == null)
            {
                return NotFound();
            }

            _context.EventImage.Remove(eventImage);
            await _context.SaveChangesAsync();

            return eventImage;
        }
        */

        private bool EventImageExists(int id)
        {
            return _context.EventImage.Any(e => e.IdeventImage == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend;

namespace Controllers
{
    [Route("Comments")]
    public class CommentController : Controller
    {
        private readonly praktikaContext _context;

        public CommentController(praktikaContext context)
        {
            _context = context;
        }

        // GET: Comments
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Comments>>> GetAllComments()
        {

            return await _context.Comments.ToListAsync();
        }

        // GET: Comments/5
        [HttpGet("{fkRecord}")]
        public async Task<ActionResult<IEnumerable<Comments>>> GetCommentsOnRecord(long? fkRecord)
        {
            if (fkRecord == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments.ToListAsync();
            List<Comments> fkComments = new List<Comments>();
            //.FirstOrDefaultAsync(m => m.FkRecord == fkRecord);
            foreach (Comments comment in comments) // query executed and data obtained from database
            {
                if (comment.FkRecord == fkRecord)
                {
                    fkComments.Add(comment);
                }
            }
            if (fkComments == null)
            {
                return NotFound();
            }

            return fkComments;
        }
        // PUT: Comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(long id, [FromBody] Comments comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
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

        // POST: Comments
        [HttpPost]
        public async Task<ActionResult<Comments>> PostComment([FromBody] Comments comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllComments), new { id = comment.Id }, comment);
        }

        // DELETE: Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comments>> DeleteComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentsExists(long id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}

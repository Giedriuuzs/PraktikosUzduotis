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
    [Route("Records")]
    public class RecordController : Controller
    {
        private readonly praktikaContext _context;

        public RecordController(praktikaContext context)
        {
            _context = context;
        }

        // GET: Records
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Records>>> GetAllRecords()
        {



            // System.Console.WriteLine("GET**************************************************************");

            // var records = _context.Records.
            // FromSqlRaw("SELECT COUNT(comments.id)" +
            // "FROM comments,records " +
            // "WHERE comments.fk_record = records.id " +
            // "GROUP BY records.id;").ToList();
            // foreach (var record in records)
            // {
            //     System.Console.WriteLine("{0}", record);
            // }

            // List<Records> records = await _context.Records.ToListAsync();
            // foreach (var item in records)
            // {
            //     System.Console.WriteLine(_context.Records.FromSqlRaw("SELECT {id} FROM praktika.records;", item.Id));
            // }
            // var records = await _context.Records.ToListAsync();
            // var comments = await _context.Comments.ToListAsync();

            // foreach (var record in records)
            // {
            //     int i = 0;
            //     foreach (var comment in comments)
            //     {
            //         if (comment.FkRecord == record.Id)
            //         {
            //             i++;
            //         }
            //     }
            //     record.CommentsNr = i;
            //     _context.Entry(record).State = EntityState.Modified;

            // }
            var recordsList = await _context.Records.Include("Comments").ToListAsync();
            var convertedList = Records.ConvertList(recordsList);
            return convertedList;//await _context.Records.Include("Comments").ToListAsync();
        }

        // GET: Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Records>> GetRecord(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var records = await _context.Records
            .FirstOrDefaultAsync(m => m.Id == id);
            if (records == null)
            {
                return NotFound();
            }

            return records;
        }
        // PUT: Records/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(long id, [FromBody] Records record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordsExists(id))
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

        // POST: Records
        [HttpPost]
        public async Task<ActionResult<Records>> PostRecord([FromBody] Records record)
        {
            System.Console.WriteLine("POST***********************************************************************");
            _context.Records.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllRecords), new { id = record.Id }, record);
        }

        // DELETE: Records/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Records>> DeleteRecord(long id)
        {
            var record = await _context.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

            return record;
        }


        private bool RecordsExists(long id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}

using HadaManagerAPI.DB;
using HadaManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HadaManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HadaManagerController : ControllerBase
    {
        private readonly DBContext _context;

        public HadaManagerController(DBContext context)
        {
            _context = context;
        }

        [HttpGet("GetTables", Name = "GetTables")]
        public async Task<Table[]> GetTables()
        {
            return await _context.Tables.ToArrayAsync();
        }

        [HttpPost("AddTable", Name = "AddTable")]
        public async Task<IActionResult> AddTable(Table table)
        {
            await _context.Tables.AddAsync(table);

            await _context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpPost("DeleteTable", Name = "DeleteTable")]
        public async Task<IActionResult> DeleteTable(Table table = null, Guid? id = null)
        {
            if (table is not null)
            {
                _context.Tables.Remove(table);
            }
            else if (id is not null)
            {
                var tableFromDB = await _context.Tables.FindAsync(id);

                if (tableFromDB != default) _context.Tables.Remove(tableFromDB);
            }

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}

using HadaManagerAPI.DB;
using HadaManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Table> GetTables()
        {
            return _context.Tables.ToArray();
        }

        [HttpPost("AddTable", Name = "AddTable")]
        public bool AddTable(Table table)
        {
            _context.Tables.Add(table);

            return _context.SaveChanges() == 1;
        }
        
        [HttpPost("DeleteTable", Name = "DeleteTable")]
        public bool DeleteTable(Table table = null, Guid? id = null)
        {
            if (table is not null)
            {
                _context.Tables.Remove(table);
            }
            else if (id is not null)
            {
                var tableFromDB = _context.Tables.Find(id);
                if (tableFromDB != default) _context.Tables.Remove(tableFromDB);
            }

            return _context.SaveChanges() == 1;
        }

    }
}

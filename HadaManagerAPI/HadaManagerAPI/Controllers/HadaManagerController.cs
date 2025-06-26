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
            _context.Database.EnsureCreated();

            return [new Table() { Id=new Guid(), Capacity=50, Name="Test Table", Occupancy=20}];
        }
    }
}

using HadaManagerAPI.Controllers.BaseController;
using HadaManagerAPI.DB;
using HadaManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HadaManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class TablesController : AbstractController<Table>
    {
        public TablesController(DBContext context)
        {
            Context = context;
            ContextType = context.Tables;
        }
    }
}

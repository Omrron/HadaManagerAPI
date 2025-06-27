using HadaManagerAPI.Controllers.BaseController;
using HadaManagerAPI.DB;
using HadaManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HadaManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : AbstractController<Room>
    {
        public RoomsController(DBContext context)
        {
            Context = context;
            ContextType = context.Rooms;
        }
    }
}

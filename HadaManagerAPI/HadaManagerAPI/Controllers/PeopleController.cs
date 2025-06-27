using HadaManagerAPI.Controllers.BaseController;
using HadaManagerAPI.DB;
using HadaManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HadaManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class PeopleController : AbstractController<Person>
    {
        public PeopleController(DBContext context)
        {
            Context = context;
            ContextType = context.People;
        }
    }
}

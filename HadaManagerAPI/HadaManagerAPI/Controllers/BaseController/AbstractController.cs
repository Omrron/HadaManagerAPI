using HadaManagerAPI.DB;
using HadaManagerAPI.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HadaManagerAPI.Controllers.BaseController
{
    public abstract class AbstractController<T> : ControllerBase where T: class , IIndexable
    {
        protected DBContext Context { get;  init; }
        protected DbSet<T> ContextType;

        [HttpGet]
        public async Task<T[]> Get()
        {
            return await ContextType.ToArrayAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Add(T item)
        {
            if (ContextType.Find(item.Id) is not null)
                return BadRequest("Item already exists");

            await ContextType.AddAsync(item);

            return await SaveChanges();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(T item = null, Guid? id = null)
        {
            if (item is not null)
            {
                ContextType.Remove(item);
            }
            else if (id is not null)
            {
                var itemFromDB = await ContextType.FindAsync(id);

                if (itemFromDB != default) ContextType.Remove(itemFromDB);
            }

            return await SaveChanges();
        }


        protected async Task<IActionResult> SaveChanges()
        {
            var numOfChanges = await Context.SaveChangesAsync();

            return Ok(numOfChanges);
        }

    }
}

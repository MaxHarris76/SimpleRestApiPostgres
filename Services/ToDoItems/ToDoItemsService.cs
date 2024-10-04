using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SimpleRestApiPostgres.Data;
using SimpleRestApiPostgres.Models;

namespace SimpleRestApiPostgres.Services.ToDoItems
{
    public class ToDoItemsService : IToDoItemsService
    {
        /// <summary>
        /// Fields
        /// </summary>

        private readonly AppDbContext appDbContext;


        /// <summary>
        /// Constructor
        /// </summary>

        public ToDoItemsService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        /// <summary>
        /// Public Methods
        /// </summary>

        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAllToDoItemsAsync()
        {
            return await appDbContext.ToDoItem.ToListAsync();
        }

        public async Task<ActionResult<ToDoItem?>?> GetToDoItemByIdAsync(long id)
        {
            ToDoItem? toDoItem = await appDbContext.ToDoItem.FindAsync(id);

            if(toDoItem == null)
            {
                return null;
            }
            return toDoItem;
        }

        public async Task<bool> PutToDoItemAsync(long id, ToDoItem toDoItem)
        {

            appDbContext.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ToDoItem?> AddToDoItemAsync(ToDoItem item)
        {
            appDbContext.ToDoItem.Add(item);

            try
            {
                await appDbContext.SaveChangesAsync();
                return item;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteToDoItemAsync(long id)
        {
            var toDoItem = await appDbContext.ToDoItem.FindAsync(id);

            if (toDoItem == null)
            {
                return false;
            }

            appDbContext.ToDoItem.Remove(toDoItem);

            try
            {
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Private Methods
        /// </summary>

        private bool ToDoItemExists(long id)
        {
            return appDbContext.ToDoItem.Any(e => e.Id == id);
        }
    }
}

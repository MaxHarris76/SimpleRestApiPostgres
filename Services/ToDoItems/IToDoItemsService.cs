using Microsoft.AspNetCore.Mvc;
using SimpleRestApiPostgres.Models;

namespace SimpleRestApiPostgres.Services.ToDoItems
{
    public interface IToDoItemsService
    {
        Task<ActionResult<IEnumerable<ToDoItem>>> GetAllToDoItemsAsync();
        Task<ActionResult<ToDoItem?>?> GetToDoItemByIdAsync(long id);
        Task<bool> PutToDoItemAsync(long id, ToDoItem toDoItem);
        Task<ToDoItem?> AddToDoItemAsync(ToDoItem item);
        Task<bool> DeleteToDoItemAsync(long id);
    }
}
 
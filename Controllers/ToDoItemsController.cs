using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleRestApiPostgres.Data;
using SimpleRestApiPostgres.Models;
using SimpleRestApiPostgres.Services.ToDoItems;

namespace SimpleRestApiPostgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {

        /// <summary>
        /// Fields
        /// </summary>

        private readonly IToDoItemsService toDoItemsService;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>

        public ToDoItemsController(IToDoItemsService service)
        {
            toDoItemsService = service;
        }


        /// <summary>
        /// Public Methods
        /// </summary>
        /// <returns></returns>

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAllToDoItemsAsync()
        {
            return await toDoItemsService.GetAllToDoItemsAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItemByIdAsync(long id)
        {
            return await toDoItemsService.GetToDoItemByIdAsync(id);
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItemAsync(long id, ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            bool result = await toDoItemsService.PutToDoItemAsync(id, toDoItem);

            if(!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> AddToDoItemAsync(ToDoItem toDoItem)
        {
            bool result = await toDoItemsService.AddToDoItemAsync(toDoItem);

            if (!result)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetToDoItemByIdAsync), new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItemAsync(long id)
        {
            bool result = await toDoItemsService.DeleteToDoItemAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

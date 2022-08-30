using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

using First.Contexts;
using First.Models;
using Microsoft.EntityFrameworkCore;

namespace First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : Controller
    {
        readonly MyDBContext _dbContext;
        //new sytnax
        public CommandsController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> GetString()
        //{
        //    return new string[] { "this", "is", "hard", "coded" };
        //}


        //GET:    api/commands

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {
            return _dbContext.Commands;
        }

        //GET:  api/commands/n
        [HttpGet("ById/{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _dbContext.Commands.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return commandItem;
        }

        //post:   api/commands

        [HttpPost]
        public ActionResult<Command>PostCommandItem(Command command)
        {
            _dbContext.Commands.Add(command);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetCommandItem",new Command { ID=command.ID},command);
        }
        //PUT: api/commands/n 
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id,Command command)
        {
            if(id!=command.ID)
                return BadRequest();
            _dbContext.Entry(command).State=EntityState.Modified;
            _dbContext.SaveChanges();
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem=_dbContext.Commands.Find(id);
            if(commandItem==null)
            {
                return NotFound();
            }
            _dbContext.Commands.Remove(commandItem);
            _dbContext.SaveChanges();

            return commandItem;

        }

    }
}

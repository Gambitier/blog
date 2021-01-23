using Blog.Application.Services;
using Blog.CommandQueryHandler.Handler.Query;
using Blog.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var data = await mediator.Send(new GetUsers()).ConfigureAwait(false);
            return Ok(data);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserByIdAsync(int id)
        {
            var data = await mediator.Send(new GetUserById { Id = id }).ConfigureAwait(false);
            return Ok(data);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

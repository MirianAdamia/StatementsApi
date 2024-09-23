using Application.Commands.CreateState;
using Application.Commands.UpdateState;
using Application.Queries;
using Application.Queries.GetStateListById;
using Application.Queries.GetStateListsOrFilterByTitle;
using Azure.Core;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace StatementsApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class StatementsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public StatementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateState")]
        public async Task<IActionResult> CreateState([FromForm] CreateStateCommand request)
        {
           var stateId = await _mediator.Send(request);

           return Ok(stateId);
        }
        [HttpGet("GetStateDetailById")]
        public async Task<IActionResult> GetStateDetailById(int id)
        {
            var states = await _mediator.Send(new GetStatesListByIdQuery(id));
            return Ok(states);
        }
        [HttpGet("GetStateListsOrFilterByTitleQuery")]
        public async Task<IActionResult> GetStateListsOrFilterByTitleQuery(string? title)
        {
            var states = await _mediator.Send(new GetStateListsOrFilterByTitleQuery(title));
            return Ok(states);
        }

        [HttpPut("UpdateState")]
        public async Task<IActionResult> UpdateState([FromForm] UpdateStateCommand request)
        {
            var stateId = await _mediator.Send(request);
            if (stateId == -1)
                return BadRequest();

            return Ok(stateId);
        }
    }
}

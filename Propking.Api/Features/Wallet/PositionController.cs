using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propking.Api.Features.Wallet;

namespace Propking.Api.Features.Position
{
    [Route("api/position")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Index.Model>> Index()
        {
            return await _mediator.Send(new Index.Query());
        }

        //[HttpGet]
        //public async Task<ActionResult<Details.Model>> Details(Details.Query query)
        //{
        //    return await _mediator.Send(query);
        //}

        [HttpPost]
        public async Task<ActionResult<int>> Register(Register.Command command)
        {
            return await _mediator.Send(command);
        }
    }
}
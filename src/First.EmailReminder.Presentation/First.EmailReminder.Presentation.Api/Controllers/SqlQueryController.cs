using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Features.ReminderRule.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace First.EmailReminder.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SqlQueryController : ControllerBase
    {
        public readonly IMediator _mediator;

        public SqlQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Execute([FromBody] ExecuteSqlQueryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
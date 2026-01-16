using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Features.ReminderRule.Commands;
using First.EmailReminder.Application.Features.ReminderRule.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace First.EmailReminder.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderRuleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReminderRuleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReminderRule(CreateReminderRuleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReminderRules()
        {
            var reminderRules = await _mediator.Send(new GetReminderRulesQuery());
            return Ok(reminderRules);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveReminderRules()
        {
            var activeReminderRules = await _mediator.Send(new GetActiveReminderRulesQuery());  
            return Ok(activeReminderRules); 
        }

        [HttpGet("due")]
        public async Task<IActionResult> GetDueReminderRules()
        {
            var dueReminderRules = await _mediator.Send(new GetDueReminderRulesQuery());  
            return Ok(dueReminderRules); 
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReminderRuleById(int id)
        {
            var reminderRule = await _mediator.Send(new GetReminderRuleByIdQuery(id));
            return Ok(reminderRule);
        }
    }
}
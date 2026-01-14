using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using MediatR;
using First.EmailReminder.Domain.Enums;

namespace First.EmailReminder.Application.Features.Email.Commands
{
    public class UpdateEmailStatusCommand : IRequest<UpdateEmailStatusDto>
    {
        public UpdateEmailStatusDto Dto {get;}

        public UpdateEmailStatusCommand(UpdateEmailStatusDto _dto )
        {
            Dto = _dto;
        }
    }
}
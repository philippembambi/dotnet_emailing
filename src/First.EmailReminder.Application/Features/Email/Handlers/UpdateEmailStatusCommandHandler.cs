using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Exceptions;
using First.EmailReminder.Application.Features.Email.Commands;
using First.EmailReminder.Application.Interfaces;
using MediatR;

namespace First.EmailReminder.Application.Features.Email.Handlers
{
    public class UpdateEmailStatusCommandHandler : IRequestHandler<UpdateEmailStatusCommand, UpdateEmailStatusDto>
    {
        public readonly IEmailRepository _emailRepository;
        public readonly IMapper _mapper;
        public UpdateEmailStatusCommandHandler(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public async Task<UpdateEmailStatusDto> Handle(UpdateEmailStatusCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var email = await  _emailRepository.GetByIdAsync(dto.Id) ?? throw new FirstValidationException("Not found", new[] {"Account not found"});
            
            email.Status = dto.Status;
            email.UpdatedAt = DateTime.UtcNow;
            
            await _emailRepository.UpdateAsync(email);
            return _mapper.Map<UpdateEmailStatusDto>(email);
        }
    }
}
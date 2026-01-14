using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.Email.Commands;
using First.EmailReminder.Application.Interfaces;
using MediatR;

namespace First.EmailReminder.Application.Features.Email.Handlers
{
    public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, EmailDto>
    {
        public readonly IEmailRepository _emailRepository;
        public readonly IMapper _mapper;

        public CreateEmailCommandHandler(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public async Task<EmailDto> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
        {
            var email = _mapper.Map<Domain.Entities.Email>(request);
            
            email.CreatedAt = DateTime.UtcNow;

            await _emailRepository.CreateAsync(email);
            return _mapper.Map<EmailDto>(email);
        }
    }
}
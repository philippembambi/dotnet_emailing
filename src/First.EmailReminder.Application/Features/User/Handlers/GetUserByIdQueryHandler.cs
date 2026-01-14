using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.User.Queries;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Application.Exceptions;
using MediatR;

namespace First.EmailReminder.Application.Features.User.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        public readonly IUserRepository userRepository;
        public readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id) ?? throw new FirstValidationException("Not found", new[] {$"No user found with id {request.Id}"});
            return _mapper.Map<UserDto>(user); 
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Application.Features.User.Commands;
using First.EmailReminder.Domain.Entities;
using MediatR;
using AutoMapper;

namespace First.EmailReminder.Application.Features.User.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);
            user.PasswordHash = _passwordHasher.CryptPassword(request.PasswordHash);
            var createdUser = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }
    }
}
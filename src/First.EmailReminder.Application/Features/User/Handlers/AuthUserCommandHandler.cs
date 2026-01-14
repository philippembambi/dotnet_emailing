using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.EmailReminder.Application.Dto;
using First.EmailReminder.Application.Features.User.Commands;
using First.EmailReminder.Application.Interfaces;
using First.EmailReminder.Application.Exceptions;
using MediatR;
using AutoMapper;

namespace First.EmailReminder.Application.Features.User.Handlers
{
    public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, AuthDtoResponseDto>
    {
        public readonly IUserRepository _userRepository;
        public readonly IPasswordHasher _passwordHasher;
        public readonly IJwtService _jwtService;

        public AuthUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<AuthDtoResponseDto> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null || !_passwordHasher.Verify(user.PasswordHash, request.PasswordHash))
                throw new FirstValidationException("Authentification failed", new[] { "Email ou mot de passe incorrect." });

            var accessToken = _jwtService.GenerateAccessToken(user);

            return new AuthDtoResponseDto
            {
                AccessToken = accessToken,
                Name = user.Name,
                Role = user.Role.ToString()
            };
        }
    }
}
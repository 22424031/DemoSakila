using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sakila.Application.Contracts.Staffs;
using Sakila.Application.Dtos.Staff;
using Sakila.Application.Feature.Staff.Request;
using Sakila.Domain;

namespace Sakila.Application.Feature.Staff.Handler
{
    public class LoginHandler : IRequestHandler<LoginRequest, StaffDto>
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;
        public LoginHandler(IMapper mapper, IStaffRepository staffRepository)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
        }
        public async Task<StaffDto> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _staffRepository.Login(request.UserName, request.Password);
            if(user == null) return null;
            return _mapper.Map<StaffDto>(user);
        }
    }
}

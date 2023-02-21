using asp_code_base.Core.Contracts;
using asp_code_base.Dtos.User;
using asp_code_base.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace asp_code_base.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            (User res, String token) = await _unitOfWork.User.Login(loginDto);
            var userDto = _mapper.Map<UserDto>(res);
            return Ok(new { data = res, token = token, message = "Login success" });
        }
    }
}

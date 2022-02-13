﻿using API_CRUD.Infrastructure.Repositories.Interfaces;
using API_CRUD.Models.Concrete;
using API_CRUD.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_CRUD.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public AccountController(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationDTO model)
        {
            var appuser = _mapper.Map<AppUser>(model);
            var user = await _authRepository.Authentication(appuser.UserName, appuser.Password);
            
            if (user == null)
            {
                return BadRequest(new { message = "Kullanıcı adı veya şifre hatalı" });
            }
            return Ok(user);
        }
    }
}
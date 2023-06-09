﻿using Microsoft.AspNetCore.Mvc;
using StatusCodes.API.Models;
using StatusCodes.API.Services;
using System.Security.Claims;

namespace StatusCodes.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public AuthController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
      
        [HttpPost("logon")]
        public ActionResult Logon(AuthReqDto loginReq)
        {
            var result = _statusRepository.AuthLogonUser(loginReq);
            if (!result.IsSuccess)
            {
                return Unauthorized(result);
            }
            return Ok(result);
        }

        [HttpPost("logout")] 
        public ActionResult Logout(UserDto findUser)
        {
            var result = _statusRepository.InvalidateUser(findUser);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

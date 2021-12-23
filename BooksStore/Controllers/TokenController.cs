using BooksStore.Models.Users;
using BooksStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
       

        private const string Secret = "this is my custom Secret key for authentication";
        private readonly TokenService _tokenService;

        public TokenController(TokenService tokenService)
        {
            this._tokenService = tokenService ??
                throw new ArgumentNullException(nameof(tokenService));
        }


        [AllowAnonymous]
        [Route("token")]
        [HttpPost()]
        public async Task<ActionResult> GetToken([FromBody] UserLoginModel login)
        {
            string accessToken = await _tokenService.GetAccessTokenAsync(login.UserName, login.Password);

            if (string.IsNullOrEmpty(accessToken))
            {
                return Forbid();
            }

            return Ok(new
            {
                token = accessToken,
            });
        }
    }
}
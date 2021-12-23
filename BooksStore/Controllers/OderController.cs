using BooksStore.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BooksStore.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class OderController : ControllerBase
    {
        private IOderRepository _repository;
        private readonly ILogger<OderController> _logger;


        public OderController(IOderRepository repository, ILogger<OderController> logger)
        {
            _repository = repository;
            _logger = logger;

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var oder = _repository.GetAll();
            return Ok(oder);
        }
    }
}

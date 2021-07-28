using GoldenGateAPI.Entities;
using GoldenGateAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoldenGateAPI.Controllers
{
   
    [ApiController]
    public class GoUserController : Controller
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        //Database ORMs


        private readonly IGoRepository _goRepository;

        public GoUserController(IGoRepository goRepository, ILogger<GoUserController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _goRepository = goRepository;

            _logger.LogInformation("CONSTRUCTOR - GoUserController");
        }

        [HttpGet("go/api/AuthorizeGoUser")]
        public async Task<IActionResult> AuthorizeUser([FromQuery] GoUser u)
        {
            
            _logger.LogInformation("[{1}][HttpGet] Consulting - AuthorizeUser({2})", DateTime.Now.ToString(),u.user);


            return Ok(await _goRepository.AutohorizeGoUser(u.user, u.key));
        }
    }
}

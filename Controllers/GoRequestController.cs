using GoldenGateAPI.Entities;
using GoldenGateAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Controllers
{
    [ApiController]
    public class GoRequestController : Controller
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        //Database ORMs


        private readonly IGoRequestRepository _goRequestRepository;

        public GoRequestController(IGoRequestRepository goRequestRepository, ILogger<GoUserController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _goRequestRepository = goRequestRepository;

            _logger.LogInformation("CONSTRUCTOR - GoRequestController");
        }

        [HttpPost("go/api/GoRequest")]
        public async Task<IActionResult> PostGoRequest([FromBody] GoRequest r)
        {

            _logger.LogInformation("[{1}][HttpGet] Posting - PostGoRequest({2})", DateTime.Now.ToString(), r.ruc);


            return Ok(await _goRequestRepository.InsertGoRequest(r.id_funcionario, r.fecha, r.id_estado, r.razon_social, r.ruc, r.telefono1, r.telefono2, r.email, r.direccion, r.representante, r.cargo, r.tipo));
        }
    }
}

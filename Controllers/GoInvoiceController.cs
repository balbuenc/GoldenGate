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
    public class GoInvoiceController : Controller
    {

        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        //Database ORMs


        private readonly IGoInvoiceRepository _goInvoiceRepository;

        public GoInvoiceController(IGoInvoiceRepository goRepository, ILogger<GoUserController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _goInvoiceRepository = goRepository;

            _logger.LogInformation("CONSTRUCTOR - GoUserController");
        }

        [HttpGet("go/api/invoice")]
        public async Task<IActionResult> GoInvoiceDetails()
        {

            _logger.LogInformation("[{1}][HttpGet] Consulting - GoInvoiceDetails()", DateTime.Now.ToString());


            return Ok(await _goInvoiceRepository.GetAllInvoices());
        }
    }
}

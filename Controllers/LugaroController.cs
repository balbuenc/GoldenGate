using GoldenGateAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenGateAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class LugaroController : ControllerBase
    {
        private readonly ILogger<FraccionesController> _logger;
        private readonly IConfiguration _config;

        //Database ORMs


        private readonly ILugaroRepository _LugaroRepository;

        public LugaroController(ILugaroRepository lugaroRepository, ILogger<FraccionesController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _LugaroRepository = lugaroRepository;
        }

        [HttpGet("lugaro/api/Productos")]
        public async Task<IActionResult> GetAllProductos()
        {

            _logger.LogInformation("[{1}][HttpGet] GetAllProductos()", DateTime.Now.ToString());
           

            return Ok(await _LugaroRepository.GetAllProductos());
        }
    }
}

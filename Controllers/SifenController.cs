﻿using GoldenGateAPI.Entities;
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
    public class SifenController : ControllerBase
    {

        private readonly ILogger<SifenController> _logger;
        private readonly IConfiguration _config;

        //Database ORMs


        private readonly ISifenRepository _SifenRepository;

        public SifenController(ISifenRepository sifenRepository, ILogger<SifenController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _SifenRepository = sifenRepository;
        }

        [HttpGet("api/dte")]
        public async Task<IActionResult> GetAllDtes()
        {

            _logger.LogInformation("[{1}][HttpGet] GetAllDtes()", DateTime.Now.ToString());

            return Ok(await _SifenRepository.GetAllDtes());
        }

        [HttpGet("api/dte/item/{Id}")]
        public async Task<IActionResult> GetDteByID(Int32 Id)
        {

            _logger.LogInformation("[{1}][HttpGet] GetDteByID()", DateTime.Now.ToString());


            return Ok(await _SifenRepository.GetDteByID(Id));
        }

        [HttpPost("api/dte")]
        public async Task<IActionResult> InsertDTE([FromBody] Dte dte)
        {
            if (dte == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _SifenRepository.InsertDTE(dte));

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedagogController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IConfiguration _configuration;
        public PedagogController(IGeneralRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
            if (!_repository.isSetConnectionString())
                _repository.SetConnectionString(configuration.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// Merr gjithe emrat nga db
        /// </summary>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<string>))]
        public IActionResult GetPedagogNames()
        {
            try
            {
                var pedagog = _repository.GetPedagog();
                return Ok(pedagog);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Merr orarin per pedagog
        /// </summary>
        [HttpGet("{name}/orari")]
        [Produces("application/json", Type = typeof(List<string>))]
        public IActionResult GetPedagogOrari(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest();

                var pedagog = _repository.GetOrarPedagog(name);
                return Ok(pedagog);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
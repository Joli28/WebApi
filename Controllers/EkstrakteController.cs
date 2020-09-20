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
    public class EkstrakteController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IConfiguration _configuration;
        public EkstrakteController(IGeneralRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
            if (!_repository.isSetConnectionString())
                _repository.SetConnectionString(configuration.GetConnectionString("DefaultConnection"));

        }

        /// <summary>
        /// Merr ditet
        /// </summary>
        [HttpGet("ditet")]
        [Produces("application/json", Type = typeof(List<string>))]
        public IActionResult GetDitet()
        {
            try
            {
                var ditet = _repository.GetDitet();
                return Ok(ditet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        /// <summary>
        /// Merr Sallat
        /// </summary>
        [HttpGet("salla")]
        [Produces("application/json", Type = typeof(List<string>))]
        public IActionResult GetSalla()
        {
            try
            {
                var sallat = _repository.GetKlasa();
                return Ok(sallat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Merr Orarin per salle dhe dite
        /// </summary>
        [HttpGet("{salla}/{ditet}/orari")]
        [Produces("application/json", Type = typeof(List<string>))]
        public IActionResult GetOrari(int salla, int ditet)
        {
            try
            {
                var orari = _repository.GetOrariDateKlaseDtos(salla, ditet);
                return Ok(orari);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
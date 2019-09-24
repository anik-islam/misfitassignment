using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MisfitsAssignment.Models;
using MisfitsAssignment.Models.Repository;

namespace MisfitsAssignment.Controllers
{
    [Route("api/calculation")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationDataRepository<Calculation> _calculationDataRepository;

        public CalculationController(ICalculationDataRepository<Calculation> repository)
        {
            _calculationDataRepository = repository;
        }

        // GET: api/Calculation
        [HttpGet]
        public IActionResult GetCalculation()
        {
            IEnumerable<Calculation> calculations = _calculationDataRepository.GetAll();

            return Ok(calculations);
        }

        // GET: api/Calculation/5
        [HttpGet("{id}")]
        public IActionResult GetCalculation(int id)
        {
            Calculation calculation = _calculationDataRepository.Get(id);
            if (calculation == null)
            {
                return NotFound("No record found.");
            }
            return Ok(calculation);
        }
        [HttpGet("getbyuser/{userid}")]
        [Route("getbyuser")]
        public IActionResult GetCalculationByUser(string userid)
        {
            Calculation calculation = _calculationDataRepository.GetByUser(userid);
            if (calculation == null)
            {
                return NotFound("No record found.");
            }
            return Ok(calculation);
        }
        // PUT: api/Calculation/5
        [HttpPut("{id}")]
        public IActionResult PutCalculation(int id, [FromBody]Calculation calculation)
        {
            if (calculation == null)
            {
                return BadRequest("Parameter is null.");
            }

            Calculation calculationToUpdate = _calculationDataRepository.Get(id);
            if (calculationToUpdate == null)
            {
                return NotFound("No record found.");
            }

            _calculationDataRepository.Update(calculationToUpdate, calculation);
            return NoContent();
        }

        // POST: api/Calculation
        [HttpPost]
        public IActionResult PostCalculation(Calculation calculation)
        {
            if (calculation == null)
            {
                return BadRequest("Parameter is null.");
            }

            _calculationDataRepository.Add(calculation);
            return CreatedAtRoute( "Get", new { Id = calculation.ID }, calculation); if (calculation == null)
            {
                return BadRequest("Parameter is null.");
            };
        }

        // DELETE: api/Calculation/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCalculation(int id)
        {
            Calculation calculation = _calculationDataRepository.Get(id);
            if (calculation == null)
            {
                return NotFound("No record found.");
            }

            _calculationDataRepository.Delete(calculation);
            return NoContent();
        }

       
    }
}

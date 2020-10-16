
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QuantumWebAPI.Models;
using QuantumWebAPI.Repositories;

using System.Data.Entity;


using System.Threading.Tasks;


namespace QuantumWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class QuantumController : ApiController
    {

        private readonly IQuantumRepository _iQuantumRepository;

        public QuantumController()
        {
            _iQuantumRepository = new QuantumRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iQuantumRepository"></param>
        public QuantumController(IQuantumRepository iQuantumRepository)
        {
            _iQuantumRepository = iQuantumRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IEnumerable<EmployeeQuotes></returns>
        /// <response code="200"></response>
        [ResponseType(typeof(IEnumerable<PartNumberHit>))]
        public IHttpActionResult GetPartNumberHits(int id)
        {
            return Ok(_iQuantumRepository.GetPartNumberHits());
        }

        //[ResponseType(typeof(IEnumerable<EmployeeQuotes))]
        //public  Task<IHttpActionResult> GetSugarLevel(int id)
        //{
        //    EmployeeQuotes sugarLevel = _iQuantumRepository.GetEmployeeMTDQuotes();
        //    if (sugarLevel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(sugarLevel);
        //}


        //    [ResponseType(typeof(void))]
        //    public async Task<IHttpActionResult> PutSugarLevel(int id, SugarLevel sugarLevel)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != sugarLevel.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _db.Entry(sugarLevel).State = EntityState.Modified;

        //        try
        //        {
        //            await _db.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (SugarLevelExists(id))
        //            {
        //                throw;
        //            }

        //            return NotFound();
        //        }

        //        return StatusCode(HttpStatusCode.NoContent);
        //    }


        //    [ResponseType(typeof(SugarLevel))]
        //    public async Task<IHttpActionResult> PostSugarLevel(SugarLevel sugarLevel)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _db.SugarLevels.Add(sugarLevel);
        //        await _db.SaveChangesAsync();

        //        return CreatedAtRoute("DefaultApi", new { id = sugarLevel.Id }, sugarLevel);
        //    }
        //}
    }
}

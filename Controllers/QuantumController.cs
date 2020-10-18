
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
using System.Web.Mvc;

namespace QuantumWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class QuantumController : ApiController
    {

        private readonly IQuantumRepository _iQuantumRepository;

        /// <summary>
        /// 
        /// </summary>
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
          //  return NotFound();
            return Ok(_iQuantumRepository.GetPartNumberHits());
        }


        
    }
}

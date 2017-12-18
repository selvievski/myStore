using Store.Services;
using System.Net;
using System.Web.Http;
using Store.WebApi.Extensions;
using Store.Models;
using System.Collections.Generic;
using Store.Domain.ORM;
using System.Net.Http;
using System;
using System.Linq;

namespace Store.WebApi.Controllers
{
    //[RoutePrefix("API/V1/Customer")] - example for versioning 
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult Get()
        {
            var customers = _customerService.GetAll().ToDtos();
            if (customers.Count() == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer = _customerService.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer.ToDto());
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult Post([FromBody]CustomerDto customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            customer.CustomerId = _customerService.Add(customer.ToEntity());
            if(customer.CustomerId > 0)
            {
                string uri = Url.Link("DefaultApi", new { id = customer.CustomerId });
                return Created(uri, customer);
            }

            return BadRequest();
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _customerService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            _customerService.Update(id, customer.ToEntity(entity));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _customerService.Delete(id);

            return Ok();
        }
    }
}

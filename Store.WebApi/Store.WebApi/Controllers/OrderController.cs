using Store.Models;
using Store.Services;
using Store.WebApi.Extensions;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Store.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public IHttpActionResult Get()
        {
            var orders = _orderService.GetAllOrders().ToDtos();
            if (orders.Count() == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Order = _orderService.GetOrder(id);
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order.ToDto());
        }

        // POST: api/Order
        [HttpPost]
        public IHttpActionResult Post([FromBody]OrderDto order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            order.Id = _orderService.AddOrder(order.ToEntity());
            if (order.Id > 0)
            {
                string uri = Url.Link("DefaultApi", new { id = order.Id });
                return Created(uri, order);
            }

            return BadRequest();
        }

        // PUT: api/Order/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]OrderDto Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _orderService.GetOrder(id);
            if (entity == null)
            {
                return NotFound();
            }

            _orderService.UpdateOrder(id, Order.ToEntity(entity));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Order/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _orderService.DeleteOrder(id);

            return Ok();
        }
    }
}

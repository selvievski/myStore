using Store.Domain.DataModels;
using Store.Services;
using System.Net;
using System.Web.Http;
using Store.WebApi.Extensions;
using Store.Models;
using System.Linq;

namespace Store.WebApi.Controllers
{
    //[RoutePrefix("API/V1/OrderItem")] - example for versioning 
    public class OrderItemController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderItemController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/OrderItem
        [HttpGet]
        public IHttpActionResult Get()
        {
            var orderItems = _orderService.GetAllOrdersItems().ToDtos();
            if (orderItems.Count() == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(orderItems);
        }

        // GET: api/OrderItem/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var OrderItem = _orderService.GetOrderItem(id);
            if (OrderItem == null)
            {
                return NotFound();
            }

            return Ok(OrderItem.ToDto());
        }

        // POST: api/OrderItem
        [HttpPost]
        public IHttpActionResult Post([FromBody]OrderItemDto orderItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            orderItem.Id = _orderService.AddOrderItem(orderItem.ToEntity());
            if (orderItem.Id > 0)
            {
                string uri = Url.Link("DefaultApi", new { id = orderItem.Id });
                return Created(uri, orderItem);
            }

            return BadRequest();
        }

        // PUT: api/OrderItem/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]OrderItemDto OrderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _orderService.GetOrderItem(id);
            if (entity == null)
            {
                return NotFound();
            }

            _orderService.UpdateOrderItem(id, OrderItem.ToEntity(entity));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/OrderItem/RemoveAll/5
        [HttpDelete]
        public IHttpActionResult RemoveAll(int id)
        {
            var entity = _orderService.GetOrder(id);
            if (entity == null)
            {
                return NotFound();
            }

            _orderService.RemoveAllOrderItems(id);

            return Ok();
        }
    }
}

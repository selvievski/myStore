using Store.Domain.DataModels;
using Store.Services;
using System.Net;
using System.Web.Http;
using Store.WebApi.Extensions;
using Store.Models;
using System.Linq;

namespace Store.WebApi.Controllers
{
    //[RoutePrefix("API/V1/Item")] - example for versioning 
    public class ItemController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/Item
        [HttpGet]
        public IHttpActionResult Get()
        {
            var items = _itemService.GetAll().ToDtos();
            if (items.Count() == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(items);
        }

        // GET: api/Item/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Item = _itemService.Get(id);
            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item.ToDto());

        }

        // POST: api/Item
        [HttpPost]
        public IHttpActionResult Post([FromBody]ItemDto item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            item.Id = _itemService.Add(item.ToEntity());
            if (item.Id > 0)
            {
                string uri = Url.Link("DefaultApi", new { id = item.Id });
                return Created(uri, item);
            }

            return BadRequest();
        }

        // PUT: api/Item/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]ItemDto Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _itemService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            _itemService.Update(id, Item.ToEntity(entity));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Item/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _itemService.Delete(id);

            return Ok();
        }
    }
}

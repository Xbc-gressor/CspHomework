using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext ctx;

        public OrderController(OrderContext context)
        {
            ctx = context;
            new OrderService(ctx);
        }

        // GET: api/Order
        [HttpGet] // 查询所有的订单
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return new OrderService(ctx).Search();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = new OrderService(ctx).SearchById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        // GET: api/Order/5
        [HttpGet("goods")]
        public ActionResult<IEnumerable<Good>> GetGoods()
        {
            return ctx.Goods;
        }

        [HttpGet("clients")]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return ctx.Clients;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutOrder(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            new OrderService(ctx).Modify(id, order);

            try
            {
                ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            new OrderService(ctx).Add(order);
            try
            {
                ctx.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(string id)
        {
            var order = new OrderService(ctx).Delete(id);
            if (order == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool OrderExists(string id)
        {
            return ctx.Orders.Any(e => e.OrderId == id);
        }
    }
}

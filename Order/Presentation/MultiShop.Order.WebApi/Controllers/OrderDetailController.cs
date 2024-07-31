using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailQueryHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailQueryHandler;
        public OrderDetailController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, RemoveOrderDetailCommandHandler removeOrderDetailQueryHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailQueryHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _removeOrderDetailQueryHandler = removeOrderDetailQueryHandler;
            _updateOrderDetailQueryHandler = updateOrderDetailQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            var values =await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderDetail(int id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);  

        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailQueryHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailQueryHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Sipariş detayı başarıyla silindi");
        }

    }
   
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAdressByIdQueryHandler _getAdressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        public AddressesController(GetAddressQueryHandler handler, GetAdressByIdQueryHandler getAdressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAdressCommandHandler updateAdressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressQueryHandler = handler;
            _getAdressByIdQueryHandler = getAdressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAdressCommandHandler = updateAdressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var values = await _getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAdressCommand command)
        {
           await _updateAdressCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAdressCommand(id));
            return Ok("Adres bilgisi başarıyla silindi");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dto.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dto.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values=_customerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var value = _customerService.GTetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer=new CargoCustomer()
            {
                Name=createCargoCustomerDto.Name,
                District=createCargoCustomerDto.District,   
                Address=createCargoCustomerDto.Address, 
                City=createCargoCustomerDto.City,   
                Email=createCargoCustomerDto.Email, 
                Phone=createCargoCustomerDto.Phone, 
                Surname=createCargoCustomerDto.Surname,     
            };
            _customerService.TInsert(cargoCustomer);
            return Ok("Kargo müşteri ekleme işlemi başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _customerService.TDelete(id);
            return Ok("Kargo müşteri silme işlemi başarıyla tamamlandı");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = updateCargoCustomerDto.Address,
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Surname = updateCargoCustomerDto.Surname,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone
            };
            _customerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşteri güncelleme işlemi başarıyla tamamlandı");
        }
    }
}

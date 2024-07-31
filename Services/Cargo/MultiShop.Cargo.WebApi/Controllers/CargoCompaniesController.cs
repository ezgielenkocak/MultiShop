using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dto.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.GTetById(id);
            return Ok(value);
        }
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto cargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName=cargoCompanyDto.CargoCompanyName,
            };
            _cargoCompanyService.TInsert(cargoCompany); 
            return Ok("Kargo şirketi başarıyla oluşturuldu");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id) 
        {
             _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateCargoCompant(UpdateCargoCompanyDto updateCargoCompanyDto) 
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyId=updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName=updateCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(cargoCompany); ;
            return Ok("Kargo şirketi başarıyla güncellendi");
        }
    }
}

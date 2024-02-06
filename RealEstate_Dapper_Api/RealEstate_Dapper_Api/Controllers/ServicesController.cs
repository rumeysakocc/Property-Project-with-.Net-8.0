using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Repositories.ServicesRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        public readonly IServicesRepository _servicesRepository;

        public ServicesController(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ServicesList()
        {
            var values = await _servicesRepository.GetAllServiceAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateServices(CreateServiceDto createServiceDto )
        {
            _servicesRepository.CreateService(createServiceDto);
            return Ok("Hizmet Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServices(int id)
        {
            _servicesRepository.DeleteService(id);
            return Ok("Hizmet Kısmı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            _servicesRepository.UpdateService(updateServiceDto);
            return Ok("Hizmet Kısmı Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServices(int id)
        {
            var value = await _servicesRepository.GetService(id);
            return Ok(value);
        }
    }
}

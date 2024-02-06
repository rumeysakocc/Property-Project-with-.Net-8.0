using RealEstate_Dapper_Api.Dtos.ServicesDto;

namespace RealEstate_Dapper_Api.Repositories.ServicesRepository
{
    public interface IServicesRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto createServiceDto);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto updateServiceDto);
        Task<GetByIDServiceDto> GetService(int id);
    }
}

using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<Last4ContactResultDto>> GetAllLast4Contact();
        void CreateContact(CreateContactDto createContactDto );
        void DeleteContact(int id);
        Task<GetByIDContactDto> GetContact(int id);
    }
}

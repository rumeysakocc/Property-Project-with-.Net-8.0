using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository ToDoListRepository)
        {
            _toDoListRepository = ToDoListRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ToDoListList()
        {
            var values = await _toDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            _toDoListRepository.CreateToDoList(createToDoListDto);
            return Ok("ToDoList Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteToDoList(id);
            return Ok("ToDoList Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            _toDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("ToDoList Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList(int id)
        {
            var value = await _toDoListRepository.GetToDoList(id);
            return Ok(value);
        }
    }
}

using RealEstate_Dapper_Api.Dtos.CategoryDto;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        //İlgili context sınıfını çağırıyoruz.
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category(CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            //Dapper'ın dinamik parametre atamaları
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                //Ekleme silme ve güncelleme işlemleri için ExecuteAsync kullanılır.
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async  void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection= _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection=_context.CreateConnection())
            {
                //Listeleme işlemi için QueryAsync kullandık
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@CategoryID";
            var parameters=new DynamicParameters();
            parameters.Add("CategoryID", id);
            using (var connection= _context.CreateConnection())
            {
                // QueryFirstOrDefaultAsync, bize geriye sadece 1 tane değer döndürecek, listeleme yapmasını istemiyoruz
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

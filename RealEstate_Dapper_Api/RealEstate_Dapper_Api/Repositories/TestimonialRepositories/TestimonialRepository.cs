﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGrid;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public void CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteTestimonial(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial ";
            using (var connection = _context.CreateConnection())
            {
                //Listeleme işlemi için QueryAsync kullandık
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDTestimonialDto> GetTestimonial(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList: ViewComponent
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string apiUrl;

        public _DefaultHomePageProductList(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            apiUrl = _configuration["ApiUrls:Url"];
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            //istemci örneği oluştur
            var client = _httpClientFactory.CreateClient();
            //Listelemek için Get kullanılır
            var responseMessage = await client.GetAsync(apiUrl + "Products/ProductListWithCategory");
            if(responseMessage.IsSuccessStatusCode)
            {
                //Gelen mesajları json formatında oku 
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                //json dan istediğimiz formata dönüştür.
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

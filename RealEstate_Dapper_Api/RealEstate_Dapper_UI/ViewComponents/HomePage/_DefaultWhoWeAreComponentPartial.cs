using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_UI.Dtos.ServiceDto;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string apiUrl;

        public _DefaultWhoWeAreComponentPartial(IConfiguration configuration,IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            apiUrl = _configuration["ApiUrls:Url"];
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            //İstemci oluşturuldu
            var client = _httpClientFactory.CreateClient();
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(apiUrl + "WhoWeAreDetail");
            var responseMessage2 = await client2.GetAsync(apiUrl + "Services");

            if(responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();
        }
    }
}

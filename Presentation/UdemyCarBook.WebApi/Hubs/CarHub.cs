using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44343/api/Statistics/GetCarCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
            await Clients.All.SendAsync("ReceiveCarCount", values.carCount);
        }
    }
}
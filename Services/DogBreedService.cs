using EjemploMVC.Models;
using Newtonsoft.Json;

namespace EjemploMVC.Services
{

    public class DogBreedService
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "https://dogapi.dog/api/v2/breeds";

        public DogBreedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<DogBreedListResponse> GetBreeds(int pageNumber, int pageSize = 10)
        {
            var url = $"{BaseUrl}?page[number]={pageNumber}&page[size]={pageSize}";
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<DogBreedListResponse>(response);
            return data ?? new DogBreedListResponse { Data = new List<DogBreedResource>() };
        }


        public async Task<DogBreedResource> GetBreed(string id)
        {
            var response = await _httpClient.GetStringAsync($"{BaseUrl}/{id}");
            var data = JsonConvert.DeserializeObject<DogBreedDetailResponse>(response);
            return data?.Data ?? new DogBreedResource();
        }
    }
}

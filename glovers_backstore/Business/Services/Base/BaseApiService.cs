using Newtonsoft;
using Newtonsoft.Json;

namespace glovers_backstore.Services.Base
{
    public abstract class BaseApiService
    {
        public static HttpClient _httpClient;
        public BaseApiService() 
        {
            _httpClient ??= new HttpClient();
        }

        public async Task<T> GetSingle<T>(string url) where T : class, new() 
        {
            T responseObject = new ();

            try
            {
                var response = await _httpClient.GetAsync(new Uri(url));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(content)) return responseObject;

                    var deserializedObject = JsonConvert.DeserializeObject<T>(content) ?? throw new Exception("Failed to deserialize");

                    responseObject = deserializedObject;
                }

            }catch(Exception ex) 
            { 
                //TODO: Log
            }
            return responseObject;
        }

        public async Task<List<T>> GetList<T>(string url) where T : class, new()
        {
            List<T> responseList = new List<T>();

            try
            {
                var response = await _httpClient.GetAsync(new Uri(url));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(content)) return responseList;

                    var deserializedList = JsonConvert.DeserializeObject<List<T>>(content) ?? throw new Exception("Failed to deserialize");

                    responseList = deserializedList;
                }

            }
            catch (Exception ex)
            {
                //TODO: Log
            }
            return responseList;
        }

        public async Task<List<string>> GetList(string url)
        {
            List<string> responseList = new List<string>();

            try
            {
                var response = await _httpClient.GetAsync(new Uri(url));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(content)) return responseList;

                    var deserializedList = JsonConvert.DeserializeObject<List<string>>(content) ?? throw new Exception("Failed to deserialize");

                    responseList = deserializedList;
                }

            }
            catch (Exception ex)
            {
                //TODO: Log
            }
            return responseList;
        }
    }
}

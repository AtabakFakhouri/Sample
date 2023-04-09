namespace AFS.SAMPLE.Helper.Shared;

public static class CommonHelper
{
    public static async Task<T> PostAsync<T>(string uri, IDictionary<string, string> requestData)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(requestData)
            };

            var response = await client.SendAsync(request);
            var responseJson = await response.Content.ReadAsAsync<T>();
            return responseJson;
        }
        catch (Exception exp)
        {
            throw exp;
        }      
    }
}

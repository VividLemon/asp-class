using System.Net.Http;
using System.Threading.Tasks;
namespace Lab_03.Models
{
    public class MyAsyncMethods
    {
        public async static Task<long?> GetPageLength ()
        {
            HttpClient client = new HttpClient();
            var httpTask = await client.GetAsync("http://apress.com");

            return httpTask.Content.Headers.ContentLength;
        }
    }
}

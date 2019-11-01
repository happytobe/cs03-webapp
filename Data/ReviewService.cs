using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TC_CS03_Blazor.Data
{
    public class ReviewService
    {
        string baseUrl = "https://tc-cs03-api.azurewebsites.net";

        public async Task<IReadOnlyCollection<ReviewRating>> GetReviewRatingTypesAsync()
        {
            HttpClient http = new HttpClient();
            string json = await http.GetStringAsync($"{baseUrl}/api/v1/ReviewRatingTypes");

            JObject data = JObject.Parse(json);

            // get JSON result objects into a list
            List<JToken> results = data["result"].Children().ToList();

            // serialize JSON results into .NET objects
            List<ReviewRating> ReviewRatingTypesResults = new List<ReviewRating>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                ReviewRatingTypesResults.Add(result.ToObject<ReviewRating>());
            }

            return ReviewRatingTypesResults.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<Review>> GetReviewsAsync()
        {
            HttpClient http = new HttpClient();
            string json = await http.GetStringAsync($"{baseUrl}/api/v1/Review");

            JObject data = JObject.Parse(json);

            // get JSON result objects into a list
            List<JToken> results = data["result"].Children().ToList();

            // serialize JSON results into .NET objects
            List<Review> ReviewsResults = new List<Review>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                ReviewsResults.Add(result.ToObject<Review>());
            }

            return ReviewsResults.AsReadOnly();
        }

        public async Task<Review> GetReviewByIdAsync(long? id)
        {
            HttpClient http = new HttpClient();
            string json = await http.GetStringAsync($"{baseUrl}/api/v1/Review/{id}");

            JObject data = JObject.Parse(json);

            return data["result"].ToObject<Review>();
        }

        public async Task<HttpResponseMessage> InsertReviewAsync(Review review)
        {
            HttpClient http = new HttpClient();
            return await http.PostAsync($"{baseUrl}/api/v1/Review", getStringContentFromObject(review));
        }

        private StringContent getStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}

using System;
using System.Net;
using System.Net.Http;
//using System.Security.Cryptography.X509Certificates;
//using Newtonsoft.Json;
//using RestSharp;
//using System.Net.Http;
using System.Threading.Tasks;
//using Google.Apis.Customsearch.v1;
//using Google.Apis.Services;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

class Program
{
    static async Task Main()
    {
        // Enter your Google Search API key here
        string apiKey = "AIzaSyCtj9-Q5SEuFA43dUmjRLU7pezJlNjwup8";

        // Enter your search query here
        Console.WriteLine("Enter url");
        string query = Console.ReadLine();

        // Create the HTTP client
        HttpClient httpClient = new HttpClient();

        // Set the base address and API key
        httpClient.BaseAddress = new Uri("https://www.googleapis.com/customsearch/v1");
        string url = $"?key={apiKey}&cx=d573652d45c254eb6&q={query}";

        try
        {
            // Send the GET request
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
               // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();

               // Process the response as needed
               // Console.WriteLine(responseBody);
               // Console.ReadLine();

                string text = responseBody;
                Console.WriteLine("Enter the keyword to search:");
                string keyword = Console.ReadLine();

                int count = CountKeyword(text, keyword);

                Console.WriteLine($"The keyword '{keyword}' appears {count} times in the text.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Request failed with status code {response.StatusCode}");
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadLine();
        }
        finally
        {
            // Dispose of the HTTP client when finished
            httpClient.Dispose();

        }
    }
    static int CountKeyword(string text, string keyword)
    {
        // Use case-insensitive search by specifying RegexOptions.IgnoreCase
        Regex regex = new Regex(keyword, RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(text);

        return matches.Count;
    }

    //static void Main()
    //{
    //    GetLinks();
    //}

    //public static void GetLinks()
    //{
    //    try
    //    {
    //        Console.WriteLine("Enter Your Search Keyword:-");
    //        string query = Console.ReadLine();
    //        string apiKey = "AIzaSyCtj9-Q5SEuFA43dUmjRLU7pezJlNjwup8";
    //        string cx = "d573652d45c254eb6";

    //        // Make the HTTP request to the Google Search API
    //        string url = $"https://www.googleapis.com/customsearch/v1?key={apiKey}&cx={cx}&q={WebUtility.UrlEncode(query)}";
    //        WebClient webClient = new WebClient();
    //        string jsonResponse = webClient.DownloadString(url);

    //        // Parse the JSON response
    //        JObject response = JObject.Parse(jsonResponse);
    //        JArray items = (JArray)response["items"];

    //        // Create a list to store the search results
    //        List<string> searchResults = new List<string>();

    //        // Extract the search result titles and URLs
    //        foreach (JToken item in items)
    //        {
    //            string title = (string)item["title"];
    //            string url1 = (string)item["link"];
    //            searchResults.Add($"Title: {title}, URL: {url1}");
    //        }

    //        // Display the search results
    //        foreach (string result in searchResults)
    //        {
    //            Console.WriteLine(result);

    //        }
    //        Console.ReadLine();
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"An error occurred: {ex.Message}");
    //        Console.ReadLine();
    //    }

    //}
}

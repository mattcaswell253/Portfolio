using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    [Table("Portfolio")]
    public class Project
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string html_url { get; set; }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/users/mattcaswell253/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", "mattcaswell253");

            var response = new RestResponse();
            
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray result = JsonConvert.DeserializeObject<JArray>(response.Content);
            var projectList = JsonConvert.DeserializeObject<List<Project>>(result.ToString());
            return projectList;
        }

        
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
  }


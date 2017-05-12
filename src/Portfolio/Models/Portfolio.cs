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
    public class Portfolio
    {
        [Key]
        public string Body { get; set; }
        public string User { get; set; }

        public static List<Portfolio> GetProjects()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/users/mattcaswell253/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
        }
    }
}

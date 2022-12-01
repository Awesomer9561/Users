using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Users.Models
{
    public class PagedResponse<T> where T : class
    {
        [JsonProperty("page")] public int Page { get; set; }
        [JsonProperty("per_page")] public int PerPage { get; set; }
        [JsonProperty("total")] public int Total { get; set; }
        [JsonProperty("total_pages")] public int TotalPages { get; set; }
        [JsonProperty("data")] public IEnumerable<T> Data { get; set; }
    }
}

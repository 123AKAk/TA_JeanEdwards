using System.Text.Json.Serialization;

namespace TA_JeanEdwards.Contract
{
    public record SearchModel
    {
        //[JsonPropertyName("Search")]
        public List<MovieModel> Search { get; set; } = [];
        public bool Response { get; set; }
    }
}

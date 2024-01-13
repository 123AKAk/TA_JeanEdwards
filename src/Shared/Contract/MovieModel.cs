using System.Text.Json.Serialization;

namespace TA_JeanEdwards.Contract
{
    public class MovieModel
    {
        public string Title { get; set; } = default!;
        public string Year { get; set; } = default!;
        public string Rated { get; set; } = default!;
        public string Released { get; set; } = default!;
        public string Runtime { get; set; } = default!;
        public string Genre { get; set; } = default!;
        public string Director { get; set; } = default!;
        public string Writer { get; set; } = default!;
        public string Actors { get; set; } = default!;
        public string Plot { get; set; } = default!;
        public string Language { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Awards { get; set; } = default!;
        public string Poster { get; set; } = default!;
        public List<RatingModel> Ratings { get; set; } = default!;
        public string Metascore { get; set; } = default!;
        public string ImdbRating { get; set; } = default!;

        public string ImdbVotes { get; set; } = default!;

        [JsonPropertyName("imdbID")]
        public string ImdbID { get; set; } = default!;

        public string Type { get; set; } = default!;
        public string DVD { get; set; } = default!;
        public string BoxOffice { get; set; } = default!;
        public string Production { get; set; } = default!;
        public string Website { get; set; } = default!;

        public bool Response { get; set; }

    }
}

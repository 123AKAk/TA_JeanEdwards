namespace TA_JeanEdwards.Contract
{
    public record MoviesModel
    {
        public List<MovieModel> Search { get; set; } = [];
        public bool Response { get; set; }
    }
}

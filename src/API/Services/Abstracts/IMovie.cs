using Refit;
using TA_JeanEdwards.Contract;

namespace TA_JeanEdwards.API.Services.Abstracts
{
    public interface IMovie
    {
        [Get("/")]
        Task<MoviesModel> Search([AliasAs("s")] string searchTerm);

        [Get("/")]
        Task<MovieModel> GetById([AliasAs("i")] string imdbId);
    }
}
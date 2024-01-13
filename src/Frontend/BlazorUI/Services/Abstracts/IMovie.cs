using Refit;
using TA_JeanEdwards.Contract;

namespace TA_JeanEdwards.BlazorUI.Services.Abstracts
{
    public interface IMovie
    {
        [Get("/Movie/Search")]
        Task<ServiceResponse<SearchModel>> Search(string searchTerm);

        [Get("/Movie/{imdbId}")]
        Task<ServiceResponse<MovieModel>> GetById(string imdbId);
    }
}
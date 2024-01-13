using Microsoft.AspNetCore.Mvc;
using Refit;
using TA_JeanEdwards.API.Services;
using TA_JeanEdwards.Contract;

namespace TA_JeanEdwards.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private ServiceResponse _response;
        private ApiService _apiService;
        public MovieController(ApiService apiService)
        {
            _response = new();
            _apiService = apiService;
        }

        [HttpGet]
        [Route(nameof(Search))]
        public async Task<IActionResult> Search(string searchTerm, CancellationToken cancellationToken)
        {
            try
            {
                SearchModel result = await _apiService.Movie.Search(searchTerm);
                if (result is null || result.Response is false)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Movie with title not found";
                    return NotFound(_response);
                }

                _response.IsSuccess = true;
                _response.Result = result;
                return Ok(_response);

            }
            catch (ApiException apiEx)
            {
                _response.IsSuccess = false;
                _response.Message = apiEx.Message;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return BadRequest(_response);
        }

        [HttpGet]
        [Route("{imdbId}")]
        public async Task<IActionResult> GetById(string imdbId, CancellationToken cancellationToken)
        {
            try
            {
                MovieModel result = await _apiService.Movie.GetById(imdbId);
                if (result is null || result.Response is false)
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Movie with imdb id \"{imdbId}\" not found";
                    return NotFound(_response);
                }

                _response.IsSuccess = true;
                _response.Result = result;
                return Ok(_response);
            }
            catch (ApiException apiEx)
            {
                _response.IsSuccess = false;
                _response.Message = apiEx.Message;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return BadRequest(_response);
        }
    }
}

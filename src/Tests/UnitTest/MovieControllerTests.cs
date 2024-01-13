namespace UnitTest
{
    [TestFixture] //TODO: Complete Tests
    internal class MovieControllerTests
    {
        private MovieController _movieController;
        private ApiService _apiService;

        [SetUp]
        public void SetUp()
        {
            //Dependencies
            _apiService = A.Fake<ApiService>();
            IMovie fakeMovie = A.Fake<IMovie>();
            A.CallTo(() => _apiService.Movie).Returns(fakeMovie);

            //SUT
            _movieController = new MovieController(_apiService);
        }

        [Test]
        public async Task Search_ReturnsOkResult_WhenMovieIsFound()
        {
            // Arrange
            SearchModel expectedResult = new() { Response = true, Search = [] };
            A.CallTo(() => _apiService.Movie.Search(A<string>._)).Returns(expectedResult);

            // Act
            ObjectResult? result = await _movieController.Search("joker", CancellationToken.None) as ObjectResult;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe((int)HttpStatusCode.OK);
            result.Value.ShouldBeAssignableTo<ServiceResponse>();
            result.Value.ShouldSatisfyAllConditions(
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.IsSuccess.ShouldBeTrue(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.Result.ShouldBe(expectedResult));
        }

        [Test]
        public async Task Search_ReturnsBadRequestResult_WhenExceptionOccurs()
        {
            // Arrange
            A.CallTo(() => _apiService.Movie.Search(A<string>._)).Throws(new Exception(""));

            // Act
            ObjectResult? result = await _movieController.Search("joker", CancellationToken.None) as ObjectResult;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
            result.Value.ShouldBeAssignableTo<ServiceResponse>();
            result.Value.ShouldSatisfyAllConditions(
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.IsSuccess.ShouldBeFalse(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.Result.ShouldBe(null));
        }

        [Test]
        public async Task Search_ReturnsNotFoundResult_WhenMovieIsNotFound()
        {
            // Arrange
            SearchModel expectedResult = new() { Response = false, Search = [] };
            A.CallTo(() => _apiService.Movie.Search(A<string>._)).Returns(expectedResult);

            // Act
            ObjectResult? result = await _movieController.Search("jooker", CancellationToken.None) as ObjectResult;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
            result.Value.ShouldBeAssignableTo<ServiceResponse>();
            result.Value.ShouldSatisfyAllConditions(
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.IsSuccess.ShouldBeFalse(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.Result.ShouldBe(null));
        }

        [Test]
        public async Task GetById_ReturnsOkResult_WhenMovieIsFound()
        {
            // Arrange
            MovieModel expectedResult = new() { Response = true };
            A.CallTo(() => _apiService.Movie.GetById(A<string>._)).Returns(expectedResult);

            // Act
            ObjectResult? result = await _movieController.GetById("tt7286456", CancellationToken.None) as ObjectResult;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe((int)HttpStatusCode.OK);
            result.Value.ShouldBeAssignableTo<ServiceResponse>();
            result.Value.ShouldSatisfyAllConditions(
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.IsSuccess.ShouldBeTrue(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.Result.ShouldBe(expectedResult));
        }

        [Test]
        public async Task GetById_ReturnsNotFoundResult_WhenMovieIsNotFound()
        {
            // Arrange
            MovieModel expectedResult = new() { Response = false };
            A.CallTo(() => _apiService.Movie.GetById(A<string>._)).Returns(expectedResult);

            // Act
            ObjectResult? result = await _movieController.GetById("tt7286456", CancellationToken.None) as ObjectResult;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe((int)HttpStatusCode.NotFound);
            result.Value.ShouldBeAssignableTo<ServiceResponse>();
            result.Value.ShouldSatisfyAllConditions(
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.IsSuccess.ShouldBeFalse(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.Result.ShouldBe(null));
        }

        [Test]
        public async Task GetById_ReturnsBadRequestResult_WhenExceptionOccurs()
        {
            // Arrange
            A.CallTo(() => _apiService.Movie.GetById(A<string>._)).Throws(new Exception(""));

            // Act
            ObjectResult? result = await _movieController.GetById("tt7286456", CancellationToken.None) as ObjectResult;

            // Assert
            result.ShouldNotBeNull();
            result.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
            result.Value.ShouldBeAssignableTo<ServiceResponse>();
            result.Value.ShouldSatisfyAllConditions(
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.IsSuccess.ShouldBeFalse(),
            () => result.Value.ShouldBeAssignableTo<ServiceResponse>()!.Result.ShouldBe(null));
        }
    }
}

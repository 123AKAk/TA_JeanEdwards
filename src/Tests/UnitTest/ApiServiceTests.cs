namespace UnitTest
{
    [TestFixture] //TODO: Complete Tests
    internal class ApiServiceTests
    {
        private ApiService _apiService;

        [SetUp]
        public void SetUp()
        {
            //Dependencies
            _apiService = A.Fake<ApiService>();
            IMovie fakeMovie = A.Fake<IMovie>();
            A.CallTo(() => _apiService.Movie).Returns(fakeMovie);
        }

        [Test]
        public async Task Movie_Search_WhenMovieIsFound()
        {
            // Arrange
            SearchModel expectedResult = new() { Response = true, Search = [] };
            A.CallTo(() => _apiService.Movie.Search(A<string>._)).Returns(expectedResult);

            // Act
            SearchModel result = await _apiService.Movie.Search("joker");

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeAssignableTo<SearchModel>();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeAssignableTo<SearchModel>(),
                () => result.ShouldBeAssignableTo<SearchModel>()!.Response.ShouldBeTrue(),
                () => result.ShouldBeAssignableTo<SearchModel>()!.ShouldBe(expectedResult));
        }

        [Test]
        public async Task Movie_Search_WhenMovieIsNotFound()
        {
            // Arrange
            SearchModel expectedResult = new() { Response = false, Search = [] };
            A.CallTo(() => _apiService.Movie.Search(A<string>._)).Returns(expectedResult);

            // Act
            SearchModel result = await _apiService.Movie.Search("jooker");

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeAssignableTo<SearchModel>();
            result.ShouldSatisfyAllConditions(
            () => result.ShouldBeAssignableTo<SearchModel>(),
            () => result.ShouldBeAssignableTo<SearchModel>()!.Response.ShouldBeFalse(),
            () => result.ShouldBeAssignableTo<SearchModel>()!.ShouldBe(expectedResult));
        }

        [Test]
        public async Task Movie_GetById_WhenMovieIsFound()
        {
            // Arrange
            MovieModel expectedResult = new() { Response = true };
            A.CallTo(() => _apiService.Movie.GetById(A<string>._)).Returns(expectedResult);

            // Act
            MovieModel result = await _apiService.Movie.GetById("tt7286456");

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeAssignableTo<MovieModel>();
            result.ShouldSatisfyAllConditions(
            () => result.ShouldBeAssignableTo<MovieModel>(),
            () => result.ShouldBeAssignableTo<MovieModel>()!.Response.ShouldBeTrue(),
            () => result.ShouldBeAssignableTo<MovieModel>()!.ShouldBe(expectedResult));
        }

        [Test]
        public async Task Movie_GetById_WhenMovieIsNotFound()
        {
            // Arrange
            MovieModel expectedResult = new() { Response = false };
            A.CallTo(() => _apiService.Movie.GetById(A<string>._)).Returns(expectedResult);

            // Act
            MovieModel result = await _apiService.Movie.GetById("rr7286456");

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeAssignableTo<MovieModel>();
            result.ShouldSatisfyAllConditions(
            () => result.ShouldBeAssignableTo<MovieModel>(),
            () => result.ShouldBeAssignableTo<MovieModel>()!.Response.ShouldBeFalse(),
            () => result.ShouldBeAssignableTo<MovieModel>()!.ShouldBe(expectedResult));
        }

    }
}

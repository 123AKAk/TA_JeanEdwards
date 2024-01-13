namespace TA_JeanEdwards.BlazorUI.Services
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            ErrorMessages = [];
        }

        public bool IsSuccess { get; set; }
        public T? Result { get; set; }
        public string? Message { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

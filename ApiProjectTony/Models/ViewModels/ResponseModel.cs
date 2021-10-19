namespace ApiProjectTony.Models.ViewModels
{
    public class ResponseModel<T> where T : class, new()
    {
        public T Data { get; set; }

        public bool Status { get; set; }

        public string Message { get; set; }
    }
}

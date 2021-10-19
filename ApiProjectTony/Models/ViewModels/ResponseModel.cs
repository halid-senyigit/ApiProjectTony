namespace ApiProjectTony.Models.ViewModels
{

    // we can use this class for our api / generic ajax response model.
    public class ResponseModel<T> where T : class, new()
    {
        public T Data { get; set; }

        public bool Status { get; set; }

        public string Message { get; set; }
    }
}

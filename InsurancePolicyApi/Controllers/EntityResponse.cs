namespace InsurancePolicyApi.Controllers
{
    public class EntityResponse<T>
    {
        public string Message { get; set; }
        public T Entity { get; set; }
        public int StatusCode { get; set; }

        
        public EntityResponse(string message, T entity, int statusCode)
        {
            Message = message;
            Entity = entity;
            StatusCode = statusCode;
        }

        
        public EntityResponse() { }
    }
}
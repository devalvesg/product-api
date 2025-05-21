namespace Application.Common
{
    public class BaseRequestObject
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

namespace CRUDify_API.Models
{
    public class User
        
    {
        public int Id { get; set; }

        required public string  Name { get; set; }

        public int Age { get; set; }

        public string? Color { get; set; }
    }
}

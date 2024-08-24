namespace ProjectE.API.DTOs.Customers
{
    public class CreateCustomerDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}

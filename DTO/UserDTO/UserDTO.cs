namespace DTO.UserDTO;

public class UserDTO
{
    public string UserId { get; set; }
    public string UserFullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Login { get; set; }
    //public string Password { get; set; }
}
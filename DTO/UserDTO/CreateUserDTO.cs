namespace DTO.UserDTO;

public class CreateUserDTO
{
    //public int UserId { get; set; }
    public string UserName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
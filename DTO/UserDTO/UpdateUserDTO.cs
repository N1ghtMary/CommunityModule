namespace DTO.UserDTO;

public class UpdateUserDTO
{
    public int UserId { get; set; }
    public string UserFullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
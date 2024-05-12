using Data;
using DTO.UserDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.UserRepository;

public class UserRepository(ApplicationContext context):IUserRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<User> _users = context.Set<User>();
    private DbSet<Article> _articles = context.Set<Article>();
    
    public UserDTO Get(int Id)
    {
        var user = _users.SingleOrDefault(u => u.UserId == Id);
        if (user == null) return null;
        return new UserDTO
        {
            UserId = user.UserId,
            UserFullName = user.UserFullName,
            BirthDate = user.BirthDate,
            City=user.City,
            Email = user.Email,
            Login = user.Login,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber
        };
    }

    public List<UserDTO> GetAll()
    {
        var users = _users.ToList();
        List<UserDTO> userDtos = new List<UserDTO>();
        foreach (var user in users)
        {
            userDtos.Add(new UserDTO
            {
                UserId = user.UserId,
                UserFullName = user.UserFullName,
                BirthDate = user.BirthDate,
                City=user.City,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber
            });   
        }

        return userDtos;
    }

    public void Insert(CreateUserDTO dto)
    {
        User user = new User
        {
            UserFullName = dto.UserFullName,
            BirthDate = dto.BirthDate,
            City = dto.City,
            Email = dto.Email,
            Login = dto.Login,
            Password = dto.Password,
            PhoneNumber = dto.PhoneNumber
        };
        _users.Add(user);
        context.SaveChanges();
    }

    public void Update(UpdateUserDTO dto)
    {
        var user = _users.SingleOrDefault(u => u.UserId == dto.UserId);
        if (user == null) return;
        user.UserFullName = dto.UserFullName;
        user.BirthDate = dto.BirthDate;
        user.City = dto.City;
        user.Email = dto.Email;
        user.Login = dto.Login;
        user.Password = dto.Password;
        user.PhoneNumber = dto.PhoneNumber;
        _users.Update(user);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        var user =_users.SingleOrDefault(u => u.UserId == Id);
        if (user == null) return;
        var articlesList = _articles.Where(a => a.UserId == user.UserId)
            .ToList();
        _articles.RemoveRange(articlesList);
        _users.Remove(user);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}
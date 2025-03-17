using LibraryAPI.Models;
using LibraryAPI.Data;
using LibraryAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt; // manejar JWT 
using Microsoft.IdentityModel.Tokens;  // define seguridad del token
using System.Security.Claims;          // definir claims del token
using System.Text;                     // convertir la clave secreta a bytes
using BCrypt.Net;                      // cifrar la clave secreta
public class UserService(LibraryContext context) : IUserService
{
  readonly LibraryContext _context = context;
  private readonly string _secretKey = "y9pmfobF1gIzjJyGDecxBLC8lh2estASerN8vlqGVNzyNP2Rz8eo2T+ktDa/RV3S";

  public bool UserExist(string email)
  {
    return _context.Users.Any(u => u.Email == email);
  }

  public async Task<IEnumerable<ResponseUserDto>> GetUsers()
  {
    return await _context.Users.Select(u => new ResponseUserDto
    {
      Id = u.Id,
      Name = u.Name,
      Email = u.Email,
      IdNumber = u.IdNumber
    }).ToListAsync();
  }

  public async Task Register(RegisterUserDto user)
  {

    bool alreadyRegister = UserExist(user.Email);

    if (alreadyRegister)
    {
      throw new Exception("User is already registered");
    }

    var userAdd = new User
    {
      Name = user.Name,
      Email = user.Email,
      Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
      IdNumber = user.IdNumber,
      Role = user.Role
    };

    _context.Users.Add(userAdd);
    await _context.SaveChangesAsync();
  }


  public async Task<string> SignIn(string email, string password)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
    {
      throw new Exception("Invalid credentials");
    }

    var token = GenerateJwtToken(user);
    return token;
  }

  private string GenerateJwtToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler(); // Crear manejador para el token
    var key = Encoding.UTF8.GetBytes(_secretKey);     // Conviertir la clave en array de bytes

    var claims = new List<Claim>                      // Lista de claims
    {
      new(ClaimTypes.Email, user.Email),
      new(ClaimTypes.Role, user.Role),
      new("UserId", user.Id.ToString())
    };

    var tokenDescriptor = new SecurityTokenDescriptor // define el payload   
    {
      Subject = new ClaimsIdentity(claims),           // define claims
      Expires = DateTime.UtcNow.AddHours(1),          // define tiempo de expiracion
      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(key),                // firmar token con la clave
        SecurityAlgorithms.HmacSha256Signature        // algoritmo de firma
      )
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);            // retorna token en string
  }

  public async Task DeleteUser(int id)
  {
    User editUser = await _context.Users.FindAsync(id);

    if (editUser == null)
    {
      throw new Exception("User doesn't exist");
    }
    _context.Users.Remove(editUser);
    await _context.SaveChangesAsync();
  }

}

public interface IUserService
{
  Task<IEnumerable<ResponseUserDto>> GetUsers();
  Task Register(RegisterUserDto user);
  Task<string> SignIn(string email, string password);
  Task DeleteUser(int id);
}
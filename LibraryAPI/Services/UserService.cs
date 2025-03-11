using LibraryAPI.Models;
using LibraryAPI.Data;
using System.IdentityModel.Tokens.Jwt;  // manejar los JWT 
using Microsoft.IdentityModel.Tokens;  // Para definir la seguridad del token
using System.Security.Claims;  // definir los datos (claims) dentro del token
using System.Text;  //  Para trabajar con texto (como convertir la clave secreta a bytes)
using Microsoft.AspNetCore.DataProtection;  //  Para cifrar contraseñas (como `bcrypt` en Node.js)
using BCrypt.Net;
using LibraryAPI.DTOs;
public class UserService : IUserService
{
  readonly LibraryContext _context;
  private readonly string _secretKey = "TuClaveSuperSecretaConAlMenos16Caracteres";
  public UserService(LibraryContext context, IConfiguration configuration)
  {
    _context = context;
  }

  // registar un usuario
  public async Task Register(RegisterUserDto user)
  {
    Console.WriteLine($"Intentando registrar: {user.Email}, {user.IdNumber}, {user.Name}");

    var alreadyRegister = UserExist(user.Email);

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


  public async Task<string> Login(string email, string password)
  {
    var user = _context.Users.FirstOrDefault(u => u.Email == email);

    if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
    {
      throw new Exception("Credenciales inválidas");
    }

    var token = GenerateJwtToken(user);
    return token;
  }

  private string GenerateJwtToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler(); // Crea un manejador para el token
    var key = Encoding.UTF8.GetBytes(_secretKey); // Convierte la clave secreta en un array de bytes

    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, user.Email), // Email del usuario
        new(ClaimTypes.Role, user.Role), // Rol del usuario
        new("UserId", user.Id.ToString())

    };

    var tokenDescriptor = new SecurityTokenDescriptor // define los datos (payload) del token
    {
      Subject = new ClaimsIdentity(claims), // define los claims
      Expires = DateTime.UtcNow.AddHours(1), // define el tiempo de expiracion
      SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key), // firma el token con la clave
            SecurityAlgorithms.HmacSha256Signature // algoritmo de firma
        )
    };

    var token = tokenHandler.CreateToken(tokenDescriptor); // crea el token
    return tokenHandler.WriteToken(token); // retorna el token como un string
  }

  public bool UserExist(string email)
  {
    return _context.Users.Any(u => u.Email == email);
  }
}

public interface IUserService
{
  Task Register(RegisterUserDto user);
  Task<string> Login(string email, string password);

}
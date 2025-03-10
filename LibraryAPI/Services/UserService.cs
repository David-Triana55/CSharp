using Microsoft.Extensions.Configuration;
using LibraryAPI.Models;
using System.IdentityModel.Tokens.Jwt;  // manejar los JWT 
using Microsoft.IdentityModel.Tokens;  // Para definir la seguridad del token
using System.Security.Claims;  // definir los datos (claims) dentro del token
using System.Text;  //  Para trabajar con texto (como convertir la clave secreta a bytes)
using BCrypt.Net;  //  Para cifrar contraseñas (como `bcrypt` en Node.js)
public class UserService : IUserService
{
  private readonly IConfiguration _configuration;
  LibraryContext _libraryContext;
  private readonly string _secretKey = "TuClaveSuperSecretaConAlMenos16Caracteres";
  public UserService(LibraryContext context, IConfiguration configuration)
  {
    _libraryContext = context;
    _configuration = configuration;
  }

  // registar un usuario
  public async Task Register(User user)
  {
    Console.WriteLine($"Intentando registrar: {user.Email}, {user.IdNumber}, {user.Name}");

    var alreadyRegister = UserExist(user);

    if (alreadyRegister)
    {
      throw new Exception("User is already registered");
    }

    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

    _libraryContext.Users.Add(user);
    await _libraryContext.SaveChangesAsync();
  }


  public async Task<string> Login(string email, string password)
  {
    var user = _libraryContext.Users.FirstOrDefault(u => u.Email == email);

    if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
    {
      throw new Exception("Credenciales inválidas");
    }

    return GenerateJwtToken(user);
  }


  private string GenerateJwtToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler(); // Crea un manejador para el token
    var key = Encoding.UTF8.GetBytes(_secretKey); // Convierte la clave secreta en un array de bytes

    var tokenDescriptor = new SecurityTokenDescriptor //  Define los datos (payload) del token
    {
      Subject = new ClaimsIdentity(
        [
          new Claim(ClaimTypes.Name, user.Email) // agrega el email del usuario como un claim
        ]),
      Expires = DateTime.UtcNow.AddHours(1), // define que eel token expire en 1 hora
      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)), //  Usa la clave secreta para firmar el token
        SecurityAlgorithms.HmacSha256Signature // algoritmo de firma
        )
    };

    var token = tokenHandler.CreateToken(tokenDescriptor); // crea el token
    Console.WriteLine(tokenHandler.WriteToken(token));
    return tokenHandler.WriteToken(token); // devuelve el token como un string
  }


  public bool UserExist(User user)
  {
    return _libraryContext.Users.Any(u => u.Email == user.Email);
  }


}

public interface IUserService
{
  Task Register(User user);
  Task<string> Login(string email, string password);

}
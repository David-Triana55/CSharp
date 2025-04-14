namespace LibraryAPI.App.Services;
using LibraryAPI.Domain.Entities;
using LibraryAPI.App.DTOs;
using LibraryAPI.Domain.Entities.ValueObjects;
using System.IdentityModel.Tokens.Jwt; // manejar JWT 
using Microsoft.IdentityModel.Tokens;  // define seguridad del token
using System.Security.Claims;          // definir claims del token
using System.Text;                     // convertir la clave secreta a bytes
using BCrypt;     // cifrar la clave secreta
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Common;
using LibraryAPI.App.Interfaces;
using LibraryAPI.Domain.Exceptions;

public class UserService : IUserService
{
  private readonly IUserRepository _repository;
  private readonly string _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY")!;

  public UserService(IUserRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<ResponseUserDto>> GetUsers()
  {
    var userEntityList = await _repository.GetUsers();

    return userEntityList.Select(u => new ResponseUserDto
    {
      Id = u.Id.Value,
      Name = u.Name,
      Email = u.Email,
      IdNumber = u.IdNumber
    }).ToList();
  }


  public async Task Register(RegisterUserDto user)
  {

    await _repository.Register(new User(
      user.Email,
      user.Name,
      BCrypt.Net.BCrypt.HashPassword(user.Password),
      user.IdNumber, user.Role
    ));
  }


  public async Task<string> SignIn(string email, string password)
  {
    var user = await _repository.GetByEmail(email);

    if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
    {
      throw new InvalidCredentialsException();
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
      new("UserId", user.Id.ToString()!)
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

  public async Task DeleteUser(UserId id)
  {
    await _repository.DeleteUser(id);
  }

}

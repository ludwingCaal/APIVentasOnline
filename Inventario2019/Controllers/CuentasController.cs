using Inventario2019.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Inventario2019.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CuentasController:ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager; //para autenticar la BD.
		private readonly SignInManager<ApplicationUser> _signManager;
		private readonly IConfiguration _configuration;

		public CuentasController(UserManager<ApplicationUser> userManager, //objeto a inyectar
			SignInManager<ApplicationUser> signManager,//objeto a inyectar
			IConfiguration configuration)//objeto a inyectar
		{
			this._userManager = userManager;
			this._signManager = signManager;
			this._configuration = configuration;
		}

		[HttpPost("Crear")]
	 	public async Task<ActionResult<UserToken>> CreateUser([FromBody]UserInfo model)
		{
			var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
			var result = await _userManager.CreateAsync(user, model.Password);
			if(result.Succeeded)//se creo sin dificultad
			{
				return BuildToken(model);//token
			}
			else
			{
				return BadRequest("Username or password invalid");
			}
		} 

		//metodo para validar el login
		[HttpPost("Login")]
		public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
		{
			var result = await _signManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				return BuildToken(userInfo);
			}
			else
			{
				ModelState.AddModelError(String.Empty, "Invalid login attempt.");
				return BadRequest(ModelState);
			}
		}

		private UserToken BuildToken(UserInfo userInfo)
		{
			var claims = new[] //reclamadores, sirven para personalizar el token
			{
				new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
				new Claim("CualquierValor","Valor de la llave"),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expiration = DateTime.UtcNow.AddHours(1);
			JwtSecurityToken token = new JwtSecurityToken(
				issuer: null,
				audience: null,
				claims: claims,
				expires: expiration,
				signingCredentials: creds
				);
			return new UserToken()
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = expiration
			};
		}
	}
}

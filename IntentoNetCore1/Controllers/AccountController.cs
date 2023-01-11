using IntentoNetCore1.Models.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IntentoNetCore1.Controllers
{
		public class AccountController : Controller
		{
				private IntranetDB dB;
				public AccountController(IntranetDB _db)
				{
						dB = _db;//Inicializa base de datos
				}

				public IActionResult Login()
				{
				//Limpia la variable de error
						ViewBag.Error = "";
						return View(); 
				}

				[HttpPost]



				//Toma los valores del index para poder ingresar, por ahora el if(user_input=="Usuario" && pass_input == "1234")
				//Sirve de forma local, no hace la petición de verificar datos de la tabla de usuarios, porque no existe aún
				public IActionResult Login(string user_input, string pass_input)
				{
						ClaimsIdentity identity = null;
						bool isAuthenticate = false;

						/*Valida las credenciales, eventualmente se hace aquí, lo ideal es obtener los datos*
						  de la tabla de la base de datos*/
						if (user_input == "Usuario" && pass_input == "1234")
						{
								identity = new ClaimsIdentity(new[]
													 {
										new Claim(ClaimTypes.Name,user_input),
											new Claim(ClaimTypes.NameIdentifier,pass_input)
								}, CookieAuthenticationDefaults.AuthenticationScheme);
								isAuthenticate = true;
								/*Se le asigna el rol de administrador, en este caso, mas adelante, se va a asignar el 
								 * rol a cada usuario*/
								identity.AddClaim(new Claim(ClaimTypes.Role, "administrador"));

						}
						//Si se ha autenticado:..
						if (isAuthenticate)
						{
								//Credenciales son enviadas sa las cookie
								var authProperties = new AuthenticationProperties
								{
										IsPersistent = false
								};
								var principal = new ClaimsPrincipal(identity);
								var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
								return RedirectToAction("Index", "Home");//Redirecciona a la vista index de la careta Home
						}
						//Crea una label que aparece cuando hay un error
						ViewBag.Error = "Usuario y contraseña incorrectos";
						return View();
				}
				//LogOut, hace que te redirija a la vista de Login
				public IActionResult Logout()
				{
						HttpContext.SignOutAsync();
						//Redirecciona a una vista
						return RedirectToAction("Login", "Account");
				}
		}
}

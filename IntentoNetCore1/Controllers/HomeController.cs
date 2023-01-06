using IntentoNetCore1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Controllers
{
		public class HomeController : Controller
		{
				private readonly ILogger<HomeController> _logger;

				public HomeController(ILogger<HomeController> logger)
				{
						_logger = logger;
				}

				public IActionResult Index()
				{
						if (!User.Identity.IsAuthenticated)
						{
								return RedirectToAction("Login", "Account");//Redirige al login
						}
						Datos Misdatos = new Datos();
						Misdatos.Nombre = User.Identity.Name;//Toma el valor del nombre del usuario
						Misdatos.ApellidoP = "Perez";
						return View(Misdatos);//Envía el objeto Misdatos a la vista Index de Home
				}

				//Declara los roles existentes
				[Authorize(Roles ="Administrador")]

				//Lleva a la vista Privacy
				public IActionResult Privacy()
				{
						return View();
				}


				[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
				public IActionResult Error()
				{
						return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
				}
		}
}

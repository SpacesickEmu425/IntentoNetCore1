using IntentoNetCore1.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Controllers
{
		public class SeccionesController : Controller
		{
				private static IntranetDB dB;
				public IActionResult Index()
				{
						return View();
				}

				public SeccionesController(IntranetDB _db)
				{
						dB = _db;
				}

				public IActionResult TodasPag(/*int option = 0*/)
				{
						//if (option != 0)
						//{
						//		option = option * 10;
						//}
						//ViewBag.total = (dB.Paginas.Count() - 1) / 10;
						//List<Paginas> paginas = dB.Paginas.Skip(option).Take(10).ToList();//Hace una consulta a la tabla Menus de la base de datos y la guarda en la clase (tipo lista) Menu
						//return View(paginas);
						List<Paginas> paginas = dB.Paginas.ToList();//Hace una consulta a la tabla Menus de la base de datos y la guarda en la clase (tipo lista) Menu
						return View(paginas);
				}
				public IActionResult AdministradorMenus(int option = 0)
				{
						//if (option != 0) {
						//		option = option * 10;
						//}
						//ViewBag.total = (dB.Menus.Count()-1) / 10;
						//List<Menus> menus = dB.Menus.Skip(option).Take(10).ToList();//Hace una consulta a la tabla Menus de la base de datos y la guarda en la clase (tipo lista) Menu
						List<Menus> menus = dB.Menus.ToList();
						return View(menus);
				}

				public IActionResult AllContents(int option = 0)
				{
						if (option != 0)
						{
								option = option * 10;
						}
						ViewBag.total = (dB.Contenido.Count() - 1) / 10;
						List<Contenido> cont = dB.Contenido.Skip(option).Take(10).ToList();//Por alguna razón no trae toda la lista de los contenidos entera, solo jala los primero 10 en este caso
						return View(cont);
				}

				public IActionResult ContenidosPagina(int cla_pag)
				{
						List<Contenido> contenidos = dB.Contenido.Where(m => m.Cla_pag == cla_pag).ToList();
						ViewBag.Pagina = dB.Paginas.Where(m => m.cla_pag == cla_pag).FirstOrDefault();
						return View(contenidos);
				}

				//Sección AGREGAR
				public IActionResult AgregarMenuNuevo()//Es el número de registros de la tabla menús +1
				{
						MenuNuevo menu = new MenuNuevo();
						menu.menus = dB.Menus.ToList();
						return View(menu);
				}
				public IActionResult AgregarSubMenuNuevo(int cla_menu)
				{
						MenuNuevo submenu = new MenuNuevo();
						submenu.menus = dB.Menus.ToList();
						submenu.menu = new Menus();
						submenu.menu.cla_papa = cla_menu;
						return View(submenu);
				}
				public IActionResult AgregarSeccionContenidoNueva(int cla_pag)
				{
						ContenidoNuevo cont = new ContenidoNuevo();
						cont.contenido = new Contenido();
						cont.contenido.Cla_pag = cla_pag;
						ViewBag.ClavSecc = dB.Contenido.Count() + 1;
						
						ViewBag.Pagina = dB.Paginas.Where(m => m.cla_pag == cla_pag).FirstOrDefault();
						List<Contenido> lista = dB.Contenido.ToList();
						cont.contenido.ID_Contenido = lista.Count() + 1;
						return View(cont);
				}
				public IActionResult PagNueva()
				{
						Paginas pagina = new Paginas();
						List<Menus> menupadre = dB.Menus.Where(m => m.cla_papa == 0).ToList();
						ViewBag.menupadre = menupadre;
						return View(pagina);
				}

				[Route("Secciones/BuscarSubmenus/{cla_papaMenu}")]
				public IActionResult BuscarSubmenus(int cla_papaMenu)
				{
						var menus_hijos = dB.Menus.Where(m => m.cla_papa == cla_papaMenu).Select(menus => new
						{
								id = menus.cla_menu,
								Nombre = menus.Menu
						}).ToList();
						return new JsonResult(menus_hijos);
				}
				public IActionResult BorrarMenu(int cla_menu)//Recibe la clave del menú
				{
						Menus menu = dB.Menus.Where(menu => menu.cla_menu == cla_menu).FirstOrDefault();
						return View(menu);
				}

				public IActionResult ComprobarSubmenus(int cla_menu)
				{
						List<Menus> menus_hijos = dB.Menus.Where(m => m.cla_papa == cla_menu).ToList();
						if (menus_hijos.Count()>0)
						{
								ViewBag.Alert = "";
								ViewBag.menuApa = dB.Menus.Where(m => m.cla_menu == cla_menu).FirstOrDefault();
								return View(menus_hijos);
						}
						else
						{
								Menus menu = dB.Menus.Where(m => m.cla_menu == cla_menu).FirstOrDefault();
								return RedirectToAction ("BorrarMenu","Secciones", new { cla_menu = menu.cla_menu });
						}
				}

				public IActionResult BorrarSeccionContenido(int ID_Contenido)//Recibe la clave del contenido a modificar
				{
						Contenido contenido = dB.Contenido.Where(m => m.ID_Contenido == ID_Contenido).FirstOrDefault();
						return View(contenido);
				}
				public IActionResult BorrPag(int cla_pag)//Recibe la clave de la página a modificar
				{
						Paginas miPagina = dB.Paginas.Where(m => m.cla_pag == cla_pag).FirstOrDefault();
						List<Menus> menupadre = dB.Menus.Where(m => m.cla_papa == 0).ToList();
						ViewBag.menupadre = menupadre;
						return View(miPagina);
				}
				//Sección MODIFICAR
				public IActionResult ModificarMenu(int cla_menu)//Recibe la clave del menú
				{
						Menus menu = dB.Menus.Where(menu => menu.cla_menu == cla_menu).FirstOrDefault();//
						return View(menu);
				}
				public IActionResult ModificarSeccionContenido(int ID_Contenido)//Recibe la clave del contenido a modificar
				{
						Contenido contenido = dB.Contenido.Where(m => m.ID_Contenido == ID_Contenido).FirstOrDefault();

						return View(contenido);
				}
				public IActionResult ModPag(int cla_pag)//Recibe la clave de la página a modificar
				{
						Paginas datos = new Paginas();
						datos = dB.Paginas.Where(m => m.cla_pag == cla_pag).FirstOrDefault();
						List<Menus> menupadre = dB.Menus.Where(m => m.cla_papa == 0).ToList();
						ViewBag.menupadre = menupadre;
						List<Menus> subMenus = dB.Menus.Where(n => n.cla_papa == datos.cla_menupapa).ToList();
						ViewBag.subMenus = subMenus;
						return View(datos);
				}

				//AtionResult MODIFICAR, AGREGAR Y BORRAR PÁGINA
				[HttpPost]
				public ActionResult ModPag(Paginas pag)
				{
						Paginas miPagina = dB.Paginas.Where(m => m.cla_pag == pag.cla_pag).FirstOrDefault();
						miPagina.TituloBrowser = pag.TituloBrowser;
						miPagina.TituloEncabeza = pag.TituloEncabeza;
						miPagina.cla_menupapa = pag.cla_menupapa;
						miPagina.cla_menu = pag.cla_menu;
						miPagina.TituloEncabeza = pag.TituloEncabeza;
						miPagina.Primer_Parrafo = pag.Primer_Parrafo;
						miPagina.publicar = pag.publicar;
						miPagina.fecha_publicacion = pag.fecha_publicacion;
						miPagina.fecha_actualizacion = pag.fecha_actualizacion;
						miPagina.fuente_publicacion = pag.fuente_publicacion;
						//dB.Entry(miPagina).State = System.Data.Entity.EntityState.Modified;
						dB.SaveChanges();
						return RedirectToAction("TodasPag", "Secciones");
				}
				[HttpPost]
				public ActionResult PagNueva(Paginas pag)
				{
						var maximo = (from li in dB.Paginas select li.cla_pag).Max();//Lenguaje linq
						maximo = (int)maximo + 1;
						pag.cla_pag = maximo;
						dB.Add(pag);
						dB.SaveChanges();
						return RedirectToAction("TodasPag", "Secciones");
				}
				[HttpPost]
				public ActionResult BorrPag(Paginas pag)
				{
						List<Contenido> cont = dB.Contenido.Where(m => m.Cla_pag == pag.cla_pag).ToList();
						dB.Remove(cont);
						dB.Remove(pag);
						return RedirectToAction("TodasPag", "Secciones");
				}
				//AtionResult MODIFICAR, AGREGAR Y BORRAR MENÚ

				[HttpPost]
				public ActionResult ModMenu(Menus menuu)
				{
						Menus miMenu = dB.Menus.Where(m => m.cla_menu == menuu.cla_menu).FirstOrDefault();
						miMenu.orden = menuu.orden;
						miMenu.Menu = menuu.Menu;
						miMenu.Desc_Larga = menuu.Desc_Larga;
						miMenu.link = menuu.link;
						miMenu.tipomenu = menuu.tipomenu;
						miMenu.activo = menuu.activo;
						dB.SaveChanges();
						return RedirectToAction("AdministradorMenus", "Secciones");
				}

				[HttpPost]
				public ActionResult AgrMenu(Menus menuu)
				{
						//List < Menus > lista = dB.Menus.ToList();
						var maximo = (from li in dB.Menus select li.cla_menu).Max();//Lenguaje linq
						maximo = (int)maximo + 1;
						menuu.cla_menu = maximo;
						dB.Add(menuu);
						dB.SaveChanges();
						return RedirectToAction("AdministradorMenus", "Secciones");
				}

				[HttpPost]
				public ActionResult AgrSubMenu(Menus submenuu)
				{
						var maximo = (from li in dB.Menus select li.cla_menu).Max();//Lenguaje linq, que es basicamente hacer cuna consulta a la BD
						maximo = (int)maximo + 1;
						submenuu.cla_menu = maximo;
						dB.Add(submenuu);
						dB.SaveChanges();
						return RedirectToAction("AdministradorMenus", "Secciones");
				}

				[HttpPost]
				public ActionResult BorrMenu(Menus menuu)
				{
						//Esta parte del código revisa si hay submenús para borrar, si es así los busca uno por uno y los va borrando
						List<Menus> menus = dB.Menus.Where(m => m.cla_papa == menuu.cla_menu).ToList();
						for (var i = 0; i <= menus.Count(); i++)
						{
								if(i < menus.Count())
								{
										dB.Remove(menus[i]);
								}
						}
						dB.Remove(menuu);
						dB.SaveChanges();
						return RedirectToAction("AdministradorMenus", "Secciones");
				}
				//AtionResult MODIFICAR, AGREGAR Y BORRAR CONTENIDO
				[HttpPost]
				public ActionResult ModContenido(Contenido contenidoo)
				{
						Contenido MiContenido = dB.Contenido.Where(m => m.ID_Contenido == contenidoo.ID_Contenido).FirstOrDefault();
						MiContenido.Titulo = contenidoo.Titulo;
						MiContenido.Orden = contenidoo.Orden;
						MiContenido.contenido = contenidoo.contenido;
						dB.SaveChanges();
						return RedirectToAction("TodasPag", "Secciones");
				}

				[HttpPost]
				public ActionResult AgrContenido(Contenido contenidoo)
				{
						var maximoSec = (from li in dB.Contenido select li.cla_sec).Max();
						maximoSec = (int)maximoSec + 1;
						contenidoo.cla_sec = maximoSec;
						dB.Add(contenidoo);
						dB.SaveChanges();
						return RedirectToAction("TodasPag", "Secciones");
				}

				[HttpPost]
				public ActionResult BorrContenido(Contenido contenidoo)
				{
						dB.Remove(contenidoo);
						dB.SaveChanges();
						return RedirectToAction("TodasPag", "Secciones");
				}

		}
}

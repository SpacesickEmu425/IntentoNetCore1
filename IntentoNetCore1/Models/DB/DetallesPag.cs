using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Models.DB
{
		public class DetallesPag
		{
				public List<Menus> submenus { get; set; }
				public List<Menus> menus { get; set; }
				public Paginas pagina { get; set; }


		}
}

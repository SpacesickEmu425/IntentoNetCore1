using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Models.DB
{
		public class ListPag
		{
				public Paginas pagina { get; set; }
				public List<Menus> menus { get; set; }
		}
}

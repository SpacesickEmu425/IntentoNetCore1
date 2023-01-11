using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Models.DB
{
		public class Cont
		{
				public int cla_sec { get; set; }
				public int cla_pag { get; set; }
				public Int16 Orden { get; set; }
				[StringLength (160)]public string Titulo { get; set; }
				public String Contenido { get; set; }
				[Key] public int ID_Contenido { get; set; }
		}
}

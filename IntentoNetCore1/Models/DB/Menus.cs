using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Models.DB
{
		public class Menus
		{
				//Columnas de la tabla
				//Declara qué variable es la clave primaria
				[Key] 
				public int cla_menu { get; set; }//Clave menu
																				 //Especifica cada vez, qué tan largo puede ser las variablies tipo string
				[StringLength(100)]
				public string Menu { get; set; }
				[StringLength(100)]
				public string Desc_Larga { get; set; }
				public int orden { get; set; }
				public int cla_papa { get; set; }
				[StringLength(100)]
				public string link { get; set; }
				public int tipomenu { get; set; }
				[StringLength(10)]
				public string activo { get; set; }
		}
}

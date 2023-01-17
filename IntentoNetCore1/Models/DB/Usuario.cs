using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Models.DB
{
		public class Usuario
		{
				[Key]
				//Columnas de la tabla
				[StringLength(50)]
				public string Nombre { get; set; }
				[StringLength(100)]
				public string Contra { get; set; }
				public Int16 Estado { get; set; }
		}
}

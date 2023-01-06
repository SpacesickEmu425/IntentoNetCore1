using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace IntentoNetCore1.Models.DB
{
		//Nombre de la tabla a usar
		public class Paginas
		{
				//Columnas de tabla
				[Key]//Declara qué variable es la clave primaria
				public int cla_pag { get; set; }//Clave de pagina
				//Especifica cada vez, qué tan largo puede ser las variablies tipo string
				[StringLength(100)]
				public string TituloBrowser { get; set; }
				[StringLength(200)]
				public string TituloEncabeza { get; set; }
				public int cla_menu { get; set; }//Clave del menu al que pertenece
				public int cla_menupapa { get; set; }//Clave del menu padre
				[StringLength(50)]
				public string publicar { get; set; }
				public DateTime fecha_publicacion { get; set; }
				[StringLength(100)]
				public string hora_publicacion { get; set; }
				public DateTime fecha_actualizacion { get; set; }
				[StringLength(255)]
				public string fuente_publicacion { get; set; }
				[StringLength(255)]
				public string Titulo_Boletin { get; set; }
				public string Primer_Parrafo { get; set; }

		}
}

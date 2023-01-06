using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Models.DB
{
		public class Contenido
		{
				public int cla_sec { get; set; }//Clave de sección
				public int Cla_pag { get; set; }//Clave de página a la que pertenece
				public Int16? Orden { get; set; }//Clave del menu al que pertenece
				[StringLength(100)] public string Titulo { get; set; }
				[Column ("Contenido")] public string contenido { get; set; }
				[StringLength(50)] public string? TextoLink { get; set; }
				[StringLength(90)] public string? Link { get; set; }
				public DateTime? FechaIni { get; set; }
				public DateTime? FechaFin { get; set; }
				public string? contenidoLigado { get; set; }
				[StringLength(100)] public string? Multimedia { get; set; }
				[StringLength(100)] public string? descmultimedia { get; set; }
				[StringLength(100)] public string? Otros { get; set; }
				[StringLength(100)] public string? descotros { get; set; }
				[StringLength(100)] public string? hiperotro { get; set; }
				//Declara qué variable es la clave primaria
				[Key] public int ID_Contenido { get; set; }
		}
}

using System;

namespace IntentoNetCore1.Models
{
		public class ErrorViewModel
		{
				public string RequestId { get; set; }

				public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
		}
		 public class Datos
		{
				public string Nombre { get; set; }
				public string ApellidoP { get; set; }
		}


}


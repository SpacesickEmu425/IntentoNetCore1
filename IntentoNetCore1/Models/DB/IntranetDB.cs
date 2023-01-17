using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntentoNetCore1.Models.DB
{
		public partial class IntranetDB:DbContext
		{
				public IntranetDB()
				{

				}
				public IntranetDB(DbContextOptions<IntranetDB> options): base(options)
				{
						
				}
				public virtual DbSet<Menus> Menus { get; set; }
				//SE comentó en su momento para no crear conflictos:
				public virtual DbSet<Contenido> Contenido { get; set; }
				public virtual DbSet<Paginas> Paginas { get; set; }
				public virtual DbSet<Cont> Cont { get; set; }
				public virtual DbSet<Usuario> Usuario { get; set; }

				protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
				{
						if (!optionsBuilder.IsConfigured)
						{
								optionsBuilder.UseSqlServer("Data Source=10.2.1.140;Initial Catalog=IntraCont;User ID=intra_admin;Password=Jn1.Ef/mp51");//Cadena de conexión, hay otra en el .json
						}
				}
				

		}


}

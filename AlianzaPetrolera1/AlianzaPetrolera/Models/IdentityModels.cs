using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using AlianzaPetrolera.Controllers.Enum;
using AlianzaPetrolera.Models.Admin;
using AlianzaPetrolera.Models.AlianzaBD;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AlianzaPetrolera.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nombres")]
        public string Pers_Nom { get; set; }

        [Display(Name = "Primer Apellido")]
        public string Pers_Lstn1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string Pers_Lstn2 { get; set; }

        [Display(Name = "Tipo Documento")]
        public TipoDoc Pers_TypeDoc { get; set; }
        
        [Display(Name = "Documento")]
        public string Pers_Doc { get; set; }

        [Display(Name = "Rol")]
        public Roles RolP_Id { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Pers_Birth { get; set; }

        [Display(Name = "Dirección")]
        public string Pers_Dir { get; set; }

        [Display(Name = "Celular")]
        public string Pers_Cel { get; set; }

        [Display(Name = "Teléfono")]
        public string Pers_Tel { get; set; }

        [Display(Name = "Ciudad")]
        public Ubic Ubic_Id { get; set; }

        [Display(Name = "Terminos y Condicones")]
        public int Term_Cond { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ConexAlianzapetroleV2snies", throwIfV1Schema: false)
        {
        }
        public DbSet<Persona> Personas { set; get; }
        public DbSet<Ubicacion> Ubicaciones { set; get; }
        public DbSet<Inscripcion> Inscripciones { set; get; }
        public DbSet<Categoria> Categorias { set; get; }
        public DbSet<Matricula> Matriculas { set; get; }
        public DbSet<ReciboCaja> RecibosCajas { set; get; }
        //public DbSet<Banco> Bancos { set; get; }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Matricula>().HasRequired(x => x.Insc_Id);
        }
    }
}
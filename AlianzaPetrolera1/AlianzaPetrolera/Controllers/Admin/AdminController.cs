using AlianzaPetrolera.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlianzaPetrolera.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //Vista principal Administrador
        public ActionResult AdminIndex()
        {
            return View();
        }
        public ActionResult AdminJefe()
        {
            return View();
        }
        public ActionResult Entrenador()
        {
            return View();
        }
        public ActionResult SuperAdmin()
        {
            return View();
        }

        public ActionResult BienvenidaPadre(string roles)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var userId = User.Identity.GetUserId();

                switch (roles)
                {
                    
                    case "Padre":

                        ////rear Role 
                        var resultado = roleManager.Create(new IdentityRole("Padre"));
                        ////Agregar Usuario A Role

                        resultado = userManager.AddToRole(userId, "Padre");
                        Response.Redirect("../RegistroPersona/PadreIndex");

                        break;

                    case "Admin":

                        var resultado1 = roleManager.Create(new IdentityRole("Administrador"));
                        resultado1 = userManager.AddToRole(userId, "Administrador");
                        Response.Redirect("../RegistroPersona");
                        break;

                    case "AdminJefe":

                        var resultado2 = roleManager.Create(new IdentityRole("AdminJefe"));
                        resultado2 = userManager.AddToRole(userId, "AdminJefe");
                        Response.Redirect("../RegistroPersona");
                        break;

                    case "Entrenador":

                        var resultado3 = roleManager.Create(new IdentityRole("Entrenador"));
                        resultado3 = userManager.AddToRole(userId, "Entrenador");
                        Response.Redirect("../RegistroPersona");
                        break;

                    //default:
                    //       ////rear Role 
                    //    var resultado7 = roleManager.Create(new IdentityRole("Padre"));
                    //    ////Agregar Usuario A Role

                    //    resultado7 = userManager.AddToRole(userId, "Padre");

                    //    break;

                    

                }


            }

            return View();
        }
        public ActionResult PaginaConstruccion()
        {
            return View();
        }
        public ActionResult PaginaConstruccionPadre()
        {
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }
    }
}
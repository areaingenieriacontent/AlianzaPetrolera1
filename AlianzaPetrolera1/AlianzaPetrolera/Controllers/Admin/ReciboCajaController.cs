﻿using AlianzaPetrolera.Models;
using AlianzaPetrolera.Models.Admin;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HiQPdf;
using System.Net;

namespace AlianzaPetrolera.Controllers.Admin
{

    public class ReciboCajaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        // GET: RegistroPersona
        public ActionResult Index()
        {
            var TodoRecibo = db.RecibosCajas.ToList();
            return View(TodoRecibo);
        }


        // GET: Recibo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                ReciboCaja X = db.RecibosCajas.Find(id);
                if (X == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(X);
                }
            }
        }
       


        // GET: Recibo/Create
        public ActionResult Create(string nombrecate, string nombreestu, string idcod, string documentoestud, string apellidoes, string ModoPago, string Banco)
        {
            var maxrecibirix = db.RecibosCajas.Max(x => x.Reci_Num);
            var max2 = maxrecibirix + 1;
            
            Session["maxrecibo"] = max2;
            Session["MySessionVariable"] = nombreestu;
            Session["MySessionVariable2"] = DateTime.Now;
            Session["MySessionVariable3"] = nombrecate;
            Session["MySessionVariable9"] = documentoestud;
            Session["MySessionVariable1"] = apellidoes;
            Session["matricula"] = 80000;
            Session["poliza"] = 10000;
            Session["uniforme"] = 50000;
            Session["mensualidad"] = 80000;
            Session["ModoPago"] = ModoPago;
            Session["Banco"] = Banco;
            //Session["CosMatri"] = totalma;
            //Session["CosPoli"] = totalp;
            //Session["CosUnif"] = totalu;
            //Session["CosMensu"] = totalme;
            return View();
        }



        // POST: Recibo/Create
        [HttpPost]
        public ActionResult Create(ReciboCaja ReciboCajas, float value1, float value2, float value3, float value4, float value5, float value6, float value7, float value8, String calc, string nombrecate, string nombreestu, string idcod, string documentoestud, string apellidoes, string ModoPago, string Banco )
        {
            var maxrecibirix = db.RecibosCajas.Max(x => x.Reci_Num);
            var max2 = maxrecibirix + 1;
            Session["maxrecibo"] = max2;
            Session["MySessionVariable"] = nombreestu;
            Session["MySessionVariable2"] = DateTime.Now;
            Session["MySessionVariable3"] = nombrecate;
            Session["MySessionVariable9"] = documentoestud;
            Session["MySessionVariable1"] = apellidoes;
            Session["MySessionVariable5"] = value2;
            Session["MySessionVariable6"] = value4;
            Session["MySessionVariable7"] = value6;
            Session["MySessionVariable8"] = value8;
            Session["ModoPago"] = ModoPago;
            Session["Banco"] = Banco;

            try
            {
                if (ModelState.IsValid)
                {

                    ReciboCaja r = new ReciboCaja();

                    //Operacion Matematica para efectuar los descuentos en la matricula del estudiante.
                    Calculadora c = new Calculadora();
                    float totalma = 0;
                    float totalp = 0;
                    float totalu = 0;
                    float totalme = 0;
                    float totalpago = 0;

                    totalma = c.Matricula(value1, value2);
                    totalp = c.Poliac(value3, value4);
                    totalu = c.Uniforme(value5, value6);
                    totalme = c.Mensualidad(value7, value8);
                    totalpago = (totalma + totalp + totalu + totalme);

                    //Variables para almacenar los datos en el pdf que se imprime
                    Session["MySessionVariable4"] = totalpago;
                    Session["MySessionVariable5"] = value2;
                    Session["MySessionVariable6"] = value4;
                    Session["MySessionVariable7"] = value6;
                    Session["MySessionVariable8"] = value8;
                    Session["matricula"] = 80000;
                    Session["poliza"] = 10000;
                    Session["uniforme"] = 50000;
                    Session["mensualidad"] = 80000;
                    Session["CosMatri"] = totalma;
                    Session["CosPoli"] = totalp;
                    Session["CosUnif"] = totalu;
                    Session["CosMensu"] = totalme;
                    //Registro de datos en la tabla recibo

                    r.Reci_Id = ReciboCajas.Reci_Id;
                    r.Costo_Matri = totalma;
                    r.Costo_Poli = totalp;
                    r.Costo_Unif = totalu;
                    r.Costo_Mensu = totalme;
                    r.Desc_Matri = value2;
                    r.Desc_Poli = value4;
                    r.Desc_Unif = value6;
                    r.Desc_Mensu = value8;
                    r.Matri_CosTota = totalpago;


                    //item.Reci_Id = ReciboCajas.Reci_Id;
                    //item.Reci_Num = model.Pers_Cod;
                    //item.Costo_Matri = model.Pers_NickNom;
                    //item.Costo_Poli = model.Pers_Pwd;
                    //item.Costo_Unif = model.Pers_Nom;
                    //item.Costo_Mensu = model.Pers_Lstn1;
                    //item.Desc_Matri = model.Pers_Lstn2;
                    //item.Desc_Poli = model.Pers_TypeDoc;
                    //item.Desc_Unif = model.Pers_Doc;
                    //item.Desc_Mensu = model.Pers_Birth;
                    //item. = model.Pers_Dir;
                    //item. = model.Pers_Tel1;
                    //item. = model.Pers_Tel2;
                    //item. = model.Pers_Mail1;
                    //item. = model.Pers_Mail2;
                    //item. = model.Pers_Ingreso;
                    //item. = model.Pers_TotalPoints;
                    //item. = model.Ubic_Id;
                    //item. = model.Rolp_Id;


                    db.RecibosCajas.Add(ReciboCajas);
                    db.SaveChanges();
                    return View();

                }
                return View(ReciboCajas);
            }
            catch
            {
                return View();
            }
        }

        // GET: Recibo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recibo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recibo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recibo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreatePdf2(string idcod)
        {
            //var user = ApplicationDbContext.Users.Find(GetActualUserId().Id);
            //var cert = ApplicationDbContext.Certifications.FirstOrDefault(x => x.Enrollment.Modu_Id == id && x.User_Id == user.Id);
            //var enrollments = ApplicationDbContext.Enrollments.Single(x => x.Modu_Id == id && x.User_Id == user.Id);

            Session["idcod"] = idcod;

            //var Nombrestu = ApplicationDbContext.Personas.First(x=> x.Pers_Cod == idcod );
            //ViewBag.Message = nombreestu;

            //var otro = "Estudiante" + ViewBag.Message;
            var inputString = @"<html>
                                <body> 
                                    <div class='form-horizontal'>
                                        <br />
                                        <br />
                                        <div class='form-row'>
                                            <div class='col-sm-6'>
                                                < img src='C:/Users/ADMIN/source/repos/AlianzaPetrolera12/AlianzaPetrolera1/AlianzaPetrolera/Content/images/logo.png'width='200px';height='250px'/>
                                            </ div >
                                    
                                            <div class='col-sm-6' style='margin-top:2em;'>
                                                <h5 ALIGN = 'RIGHT' style='font-family:Arial Black, Gadget, sans-serif; font-size: 35px;color:#0A122A;'>N° Recibo: " + Session["idcod"] + @"</h5>
                                            </div>
                                        </div>
                                        <hr />
                                        <br /> 
                                    <div class='row'>
                                        <div class='col-sm-8'>
                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>Estudiante:" + Session["idcod"] + @"</h6>
                                        </div>
                                    
                                        <div class='col-sm-4'>
                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>Fecha Y Generalización Recibo</h6>
                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>" + DateTime.Now + @"</h6>
                                        </div>
                                    </div>
                                    <hr />
                                    <br />
                                    <div class='row'>
                                        <div class='col-sm-8'>
                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>Tipo Cuenta: Ahorros</h6>
                                        </div>
                                        <div class='col-sm-4'>
                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>Bancolombia</h6>
                                        </div>
                                        <div class='col-sm-12'>
                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>#1215684-154541-12152</h6>
                                        </div>
                                    </div>
                                    <hr />
                                    <br />
                                    <div class='container' style=' border: 1px solid; border - color: #A59D9B; padding:10px 10px 10px 10px;'>
                                        <div class='container'>
                                            <form method='post'>
                                                <table class='egt'>  
                                                    <tr>
                                    
                                                    <th scope='row'>Matricula</th>
                                    
                                                    <th> Poliza Accidentes: </th>
                                      
                                                    <th> Uniforme : </th>
                                         
                                                    <th> Mensualidad : </th>
                                                    
                                                    </ tr >
                                                    
                                                    <tr>
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>$ 80.000</h6>
                                                        </td>
                                      
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>$ 10.000</h6>
                                                        </td>
                                    
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>$ 50.000</h6>
                                                         </td>
                                    
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>$ 80.000</h6>
                                                        </td>
                                    
                                                    </tr>
                                                    
                                                    <tr>
                                    
                                                        <th>Descuento </th>
                                    
                                                        <th>Descuento </th>
                                    
                                                        <th>Descuento </th>
                                    
                                                        <th>Descuento </th>
                                    
                                                    </tr>
                                    
                                                    <tr>
                                    
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>5 %</h6>
                                                        </td>
                                      
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>10 %</h6>
                                                        </td>
                                    
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>15 %</h6>
                                                        </td>
                                    
                                                        <td>
                                                            <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>20 %</h6>
                                                        </td>
                                    
                                                    </tr>
                                                </table>
                                                <div class='col-sm-12'>
                                                    <h6 style='font-family:Arial Black, Gadget, sans-serif; font-size: 15px;color:#0A122A;'>Total a Pagar: ""</h6>
                                                </div>
                                            </form >
                                        </div>
                                    </div>
                                </div>
                                </body>
                                </html>";

            //          < div  style = 'float:left;width:550px;height='200px; '>
            //                                         < h4 style = 'font-family:Arial Black, Gadget, sans-serif; font-size: 70px;color:#0A122A;' > CERTIFICADO </ h4 >

            //                                   </ div >

            //                                   < div style = 'float:right;' >

            //                                        < img src = 'http://localhost/SaludVida/Recursos/logo-campana.png'width = '150px'; height = '150px' />

            //                                         </ div >

            //                                         < H3 ALIGN = 'center'style = 'font-family:Arial Black, Gadget, sans-serif; font-size: 40px; margin: -20px;color:#0A122A;' >< strong > Otorgado a:</ strong >  </ H3 >

            //                                                 < br ></ br >

            //                                                 < h3 ALIGN = 'center' style = 'font-family:Britannic Bold; font-size: 30px;color:#FF9800;' ></ h3 >

            //                                                    < h4 ALIGN = 'center'style = 'font-family:Britannic Bold;' > Identificado(a) con cédula de ciudadanía número </ h4 >

            //                                                         < H4 ALIGN = 'center'style = 'font-family:Britannic Bold;' > Por haber aprobado el curso virtual de:</H4>
            //                                  < H4 ALIGN = 'center'style='font-family:Arial Black,Gadget,sans-serif; font-size: 60px;color:#0A122A;' > </ H4 >
            //                                  < h4 ALIGN = 'center'style='font-family:Britannic Bold;'>En testimonio de lo anterior se firma en</h4>
            //                                  <div ALIGN = 'center' >

            //                                        < br ></ br >< br ></ br >

            //                                        < h3 ALIGN= 'center'style= 'font-family:Arial Black, Gadget, sans-serif;color:#000;' > ________________________ </ h3 >

            //                                        < h3 ALIGN= 'center'style= 'font-family:Arial Black, Gadget, sans-serif;color:#000;' > Camilo Jaramillo Botero</h3>
            //                                      <h5 ALIGN = 'center'style= 'font-family:Arial Black, Gadget, sans-serif;color:#000;' > Gerente de Ventas y Mercadeo</h5>
            //                                  </div>  
            //                                  <div style = 'float:left' >

            //                                    </ div >
            //


            List<string> cssFiles = new List<string>();
            cssFiles.Add(@"/Content/bootstrap.css");
            var output = new MemoryStream();
            var input = new MemoryStream(Encoding.UTF8.GetBytes(inputString));
            Document document = new Document(PageSize.A4);
            var writer = PdfWriter.GetInstance(document, output);
            writer.CloseStream = false;
            document.Open();
            var htmlContext = new HtmlPipelineContext(null);
            htmlContext.SetTagFactory(iTextSharp.tool.xml.html.Tags.GetHtmlTagProcessorFactory());
            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
            cssFiles.ForEach(i => cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath(i), true));
            var pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
            var worker = new XMLWorker(pipeline, true);
            var p = new XMLParser(worker);
            p.Parse(input);
            document.Close();
            output.Position = 0;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Certificado.pdf");
            Response.BinaryWrite(output.ToArray());
            Response.Flush();
            Response.Close();
            Response.End();
            return RedirectToAction("Report_Person");
        }
        //public ApplicationUser GetActualUserId()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var user = UserManager.FindById(userId);
        //    return user;
        //}
        public ActionResult About()
        {
            return View();
        }

        public string RenderViewAsString(string viewName, object model)
        {
            // create a string writer to receive the HTML code
            StringWriter stringWriter = new StringWriter();

            // get the view to render
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
            // create a context to render a view based on a model
            ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    new ViewDataDictionary(model),
                    new TempDataDictionary(),
                    stringWriter
                    );

            // render the view to a HTML code
            viewResult.View.Render(viewContext, stringWriter);

            // return the HTML code
            return stringWriter.ToString();
        }

        [HttpPost]
        public ActionResult ConvertThisPageToPdf(string idcod)
        {
            // get the HTML code of this view
            string htmlToConvert = RenderViewAsString("Create", null);

            // the base URL to resolve relative images and css
            String thisPageUrl = this.ControllerContext.HttpContext.Request.Url.AbsoluteUri;
            String baseUrl = thisPageUrl.Substring(0, thisPageUrl.Length - "ReciboCaja/ConvertThisPageToPdf".Length);

            // instantiate the HiQPdf HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // hide the button in the created PDF
            htmlToPdfConverter.HiddenHtmlElements = new string[] { "#convertThisPageButtonDiv" };

            // render the HTML code as PDF in memory
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlToConvert, baseUrl);

            // send the PDF file to browser
            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
            fileResult.FileDownloadName = "Recibo_Alianza_Petrolera.pdf";

            return fileResult;
        }

        [HttpPost]
        public ActionResult ConvertAboutPageToPdf()
        {
            // get the About view HTML code
            string htmlToConvert = RenderViewAsString("About", null);

            // the base URL to resolve relative images and css
            String thisPageUrl = this.ControllerContext.HttpContext.Request.Url.AbsoluteUri;
            String baseUrl = thisPageUrl.Substring(0, thisPageUrl.Length - "ReciboCaja/ConvertAboutPageToPdf".Length);

            // instantiate the HiQPdf HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // render the HTML code as PDF in memory
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlToConvert, baseUrl);

            // send the PDF file to browser
            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
            fileResult.FileDownloadName = "Recibo_Alianza_Petrolera.pdf";

            return fileResult;
        }
    }
}

using AlianzaPetrolera.Models;
using AlianzaPetrolera.RPTDataSet;
using AlianzaPetrolera.RPTDataSet.DataReciboTableAdapters;
using AlianzaPetrolera.RPTDataSet.DataCategoriaTableAdapters;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AlianzaPetrolera.Controllers.Admin
{
    public class ReportController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Report
        public ActionResult ReporteReciboCaja()
        {
            try {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataRecibo.ReciboCajasDataTable data1 = new DataRecibo.ReciboCajasDataTable();
                ReciboCajasTableAdapter adapter = new ReciboCajasTableAdapter();
                adapter.Fill(data1);
                if (data1 != null && data1.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReciboCajaReport", data1.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportRecibo.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteCategoriaSemillero()
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataCategoria.MatriculasSemillerosDataTable data2 = new DataCategoria.MatriculasSemillerosDataTable();
                MatriculasSemillerosTableAdapter adapter = new MatriculasSemillerosTableAdapter();
                adapter.Fill(data2);
                if (data2 != null && data2.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataCategoriaSemilleros", data2.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportCateSemilleros.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteCategoriaPreBaby()
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataCategoria.MatriculasPreBabyDataTable data2 = new DataCategoria.MatriculasPreBabyDataTable();
                MatriculasPreBabyTableAdapter adapter = new MatriculasPreBabyTableAdapter();
                adapter.Fill(data2);
                if (data2 != null && data2.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataCategoriaPreBaby", data2.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportCatePreBaby.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteCategoriaBaby()
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataCategoria.MatriculasBabyDataTable data2 = new DataCategoria.MatriculasBabyDataTable();
                MatriculasBabyTableAdapter adapter = new MatriculasBabyTableAdapter();
                adapter.Fill(data2);
                if (data2 != null && data2.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataCategoriaBaby", data2.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportCateBaby.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteCategoriaPreInfantil()
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataCategoria.MatriculasPreInfantilDataTable data2 = new DataCategoria.MatriculasPreInfantilDataTable();
                MatriculasPreInfantilTableAdapter adapter = new MatriculasPreInfantilTableAdapter();
                adapter.Fill(data2);
                if (data2 != null && data2.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataCategoriaPreInfantil", data2.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportCatePreInfantil.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteCategoriaInfantil()
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataCategoria.MatriculasInfantilDataTable data2 = new DataCategoria.MatriculasInfantilDataTable();
                MatriculasInfantilTableAdapter adapter = new MatriculasInfantilTableAdapter();
                adapter.Fill(data2);
                if (data2 != null && data2.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataCategoriaInfantil", data2.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportCateInfantil.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteRecibopdf(int id)
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataRecibo.ReciboPDFDataTable data3 = new DataRecibo.ReciboPDFDataTable();
                ReciboPDFTableAdapter adapter3 = new ReciboPDFTableAdapter();
                adapter3.Fill(data3,id);
                if (data3 != null && data3.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataReciboPDF", data3.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportReciboPDF.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteReciboCreate(int Num)
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataRecibo.ReciboCreateDataTable data3 = new DataRecibo.ReciboCreateDataTable();
                ReciboCreateTableAdapter adapter3 = new ReciboCreateTableAdapter();
                adapter3.Fill(data3, Num);
                if (data3 != null && data3.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataReciboCreate", data3.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportReciboCreate.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
        public ActionResult ReporteCategoriaSub14()
        {
            try
            {
                ReportViewer reportViewer = new ReportViewer()
                {
                    ProcessingMode = ProcessingMode.Local,
                    SizeToReportContent = true,
                    Width = Unit.Percentage(100),
                    Height = Unit.Percentage(100)
                };

                DataCategoria.MatriculasSub14DataTable data2 = new DataCategoria.MatriculasSub14DataTable();
                MatriculasSub14TableAdapter adapter = new MatriculasSub14TableAdapter();
                adapter.Fill(data2);
                if (data2 != null && data2.Rows.Count > 0)
                {
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReportCateSub14", data2.CopyToDataTable()));
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"\RPTReports\ReportCateSub14.rdlc.";
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.TextError = "No hay datos validos para este reporte";
                }
            }
            catch (Exception ex)
            {
                ViewBag.TextError = ex.Message;
            }

            return View();
        }
    }
}

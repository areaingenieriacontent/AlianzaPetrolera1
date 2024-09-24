using AlianzaPetrolera.Controllers.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlianzaPetrolera.Models.Admin
{
    public class ReciboCaja
    {
        [Key]
        [Display(Name = "Id")]
        public int Reci_Id { get; set; }
        [Display(Name = "N° Recibo:")]
        public int Reci_Num { get; set; }
        [Display(Name = "Nombre Estudiante")]
        public string Reci_NomUs { get; set; }
        [Display(Name = "Apellido Estudiante")]
        public string Reci_ApeUs { get; set; }
        [Display(Name = "Documento")]
        public string Reci_DocUs { get; set; }
        [Display(Name = "Categoría")]
        public string Reci_CateUs { get; set; }
        [Display(Name = "Fecha de Pago")]
        public DateTime Matr_Fecha { get; set; }

        [Display(Name = "Mes Pago")]
        public string Mes_Pago { get; set; }

        [Display(Name = "Modo pago")]
        public string Reci_Mpago { get; set; }
        
        [Display(Name = "Matrícula")]
        public Nullable<float> Costo_Matri { get; set; }

        [Display(Name = "Póliza de Accidente")]
        public Nullable<float> Costo_Poli { get; set; }

        [Display(Name = "Uniforme")]
        public Nullable<float> Costo_Unif { get; set; }

        [Display(Name = "Mensualidad")]
        public Nullable<float> Costo_Mensu { get; set; }

        [Display(Name = "Descto. Matrícula")]
        public Nullable<float> Desc_Matri { get; set; }
        [Display(Name = "Descto. Póliza de Accidentes")]
        public Nullable<float> Desc_Poli { get; set; }
        [Display(Name = "Descto. Uniforme")]
        public Nullable<float> Desc_Unif { get; set; }
        [Display(Name = "Descto. Mensualidad")]
        public Nullable<float> Desc_Mensu { get; set; }

        [Display(Name = "Abonos u Otros")]
        public Nullable<float> Abonos_Otros { get; set; }

        [Display(Name = "Total a Pagar")]
        public Nullable<float> Matri_CosTota { get; set; }

        [Display(Name = "Observación")]
        public string Reci_Obse { get; set; }

        [Display(Name = "Banco")]
        public string Banco_Id { get; set; }
        //[ForeignKey("Banco")]
        //public int? Banco_Id { get; set; }
        //public Banco Banco { get; set; }



    }
    public class Calculadora
    {
        private float a, b;

        public float A
        {
            get
            {
                return a;
            }

            set
            {
                a = value;
            }
        }

        public float B
        {
            get
            {
                return b;
            }

            set
            {
                b = value;
            }

        }
        public Calculadora()
        {

        }

        public float Matricula(float a, float b)
        {
            float totaldesc = 0;
            float totalpag = 0;

            totaldesc = ((a * b) / 100);
            totalpag = (a - totaldesc);
            return totalpag;
        }

        public float Poliac(float a, float b)
        {
            float totaldesc = 0;
            float totalpag = 0;

            totaldesc = ((a * b) / 100);
            totalpag = (a - totaldesc);
            return totalpag;
        }
        public float Uniforme(float a, float b)
        {
            float totaldesc = 0;
            float totalpag = 0;

            totaldesc = ((a * b) / 100);
            totalpag = (a - totaldesc);
            return totalpag;
        }
        public float Mensualidad(float a, float b)
        {
            float totaldesc = 0;
            float totalpag = 0;

            totaldesc = ((a * b) / 100);
            totalpag = (a - totaldesc);
            return totalpag;
        }
        public float AbonosUotros(float a)
        {
            return a;
        }
    }
}
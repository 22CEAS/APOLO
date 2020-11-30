using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class IngresoDetalle
    {
        private long idIngresoDetalle;
        private LC laptop;
        private BindingList<String> series;
        private BindingList<String> windows;
        private BindingList<String> office;
        private BindingList<String> antivirus;
        private int cantidad;
        private double precio;
        private string caracteristica;
        private string observacion;
        private int estado;

        public IngresoDetalle()
        {
            this.Observacion = "";
            this.Caracteristica = "";
            this.Series = new BindingList<string>();
            this.Windows = new BindingList<string>();
            this.Office = new BindingList<string>();
            this.Antivirus = new BindingList<string>();
            this.Laptop = new LC();
            this.Estado = 1;
        }

        public long IdIngresoDetalle { get => idIngresoDetalle; set => idIngresoDetalle = value; }
        public LC Laptop { get => laptop; set => laptop = value; }
        public BindingList<String> Series { get => series; set => series = value; }
        public BindingList<string> Windows { get => windows; set => windows = value; }
        public BindingList<string> Office { get => office; set => office = value; }
        public BindingList<string> Antivirus { get => antivirus; set => antivirus = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Caracteristica { get => caracteristica; set => caracteristica = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }


        public int LaptopIdMarca { get => Laptop.IdMarca; set => Laptop.IdMarca = value; }
        public string LaptopMarcaLC { get => Laptop.MarcaLC; set => Laptop.MarcaLC = value; }
        public int LaptopIdModelo { get => Laptop.IdModelo; set => Laptop.IdModelo = value; }
        public string LaptopNombreModeloLC { get => Laptop.NombreModeloLC; set => Laptop.NombreModeloLC = value; }
        public int LaptopIdProcesador { get => Laptop.IdProcesador; set => Laptop.IdProcesador = value; }
        public string LaptopTipoProcesador { get => Laptop.TipoProcesador; set => Laptop.TipoProcesador = value; }
        public int LaptopIdVideo { get => Laptop.IdVideo; set => Laptop.IdVideo = value; }
        public string LaptopNombreModeloVideo { get => Laptop.NombreModeloVideo; set => Laptop.NombreModeloVideo = value; }
        public int LaptopCapacidadVideo { get => Laptop.CapacidadVideo; set => Laptop.CapacidadVideo = value; }
        public double LaptopTamanoPantalla { get => Laptop.TamanoPantalla; set => Laptop.TamanoPantalla = value; }
    }
}

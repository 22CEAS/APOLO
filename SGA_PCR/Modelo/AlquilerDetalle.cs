using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class AlquilerDetalle
    {
        private long idAlquilerDetalle;
        private LC laptop;
        private DateTime fechaIniContrato;
        private DateTime fechaFinContrato;
        private string caracteristica;
        private string guiaSalida;
        private string motivoNoRecojo;
        private string observacion;
        private int estado;

        public AlquilerDetalle()
        {
            this.Laptop = new LC();
            this.IdAlquilerDetalle = 0;
            this.GuiaSalida = "";
            this.MotivoNoRecojo = "";
            this.Observacion = "";
            this.Caracteristica = "";
        }

        public AlquilerDetalle(long idAlquilerDetalle, LC laptop, string caracteristica, string guiaSalida, string motivoNoRecojo, string observacion, int estado)
        {
            this.IdAlquilerDetalle = idAlquilerDetalle;
            this.Laptop = laptop;
            this.Caracteristica = caracteristica;
            this.GuiaSalida = guiaSalida;
            this.MotivoNoRecojo = motivoNoRecojo;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public long IdAlquilerDetalle { get => idAlquilerDetalle; set => idAlquilerDetalle = value; }
        public LC Laptop { get => laptop; set => laptop = value; }
        public string Caracteristica { get => caracteristica; set => caracteristica = value; }
        public string GuiaSalida { get => guiaSalida; set => guiaSalida = value; }
        public string MotivoNoRecojo { get => motivoNoRecojo; set => motivoNoRecojo = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public DateTime FechaIniContrato { get => fechaIniContrato; set => fechaIniContrato = value; }
        public DateTime FechaFinContrato { get => fechaFinContrato; set => fechaFinContrato = value; }


        public int IdLC { get => laptop.IdLC;}
        public string Codigo { get => laptop.Codigo; }
        public int IdMarca { get => laptop.Modelo.IdMarca; }
        public string MarcaLC { get => laptop.Modelo.NombreMarca; }
        public int IdModelo { get => laptop.Modelo.IdModelo; }
        public string NombreModeloLC { get => laptop.Modelo.NombreModelo; }
        public double TamanoPantalla { get => laptop.TamanoPantalla; }
        public int IdProcesador { get => laptop.Procesador.IdProcesador; }
        public string TipoProcesador { get => laptop.Procesador.Modelo.NombreModelo; }
        public int GeneracionProcesador { get => laptop.Procesador.Generacion; }
        public int IdVideo { get => laptop.Video.IdVideo; }
        public string NombreModeloVideo { get => laptop.Video.Modelo.NombreModelo; }
        public int CapacidadVideo { get => laptop.Video.Capacidad; }
    }
}

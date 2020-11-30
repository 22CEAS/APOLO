using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DevolucionDetalle
    {
        private int idDetalle;
        private int idDevolucion;
        private int idSalidaDetalle;
        private int idSucursal;
        private int idLC;
        private string codigoLC;
        private string marcaLC;
        private string modeloLC;
        private int seleccionado;
        private int danado;
        private int cobrar;
        private string caracteristicas;
        private int estadoLC;
        private string observacion;
        private int estado;
        private int pagaraCliente;

        public DevolucionDetalle()
        {
            this.IdDetalle = 0;
            this.IdDevolucion = 0;
            this.IdSalidaDetalle = 0;
            this.IdSucursal = 0;
            this.IdLC = 0;
            this.CodigoLC = "";
            this.MarcaLC = "";
            this.ModeloLC = "";
            this.Caracteristicas = "";
            this.EstadoLC = 2;
            this.Observacion = "";
            this.Estado = 0;
            this.PagaraCliente = 0;
            this.Seleccionado = 0;
            this.Danado = 0;
            this.Cobrar = 0;
        }

        public DevolucionDetalle(int idDetalle, int idDevolucion, int idLC, string caracteristicas, int estadoLC, string observacion, int estado, int pagaraCliente)
        {
            this.IdDetalle = idDetalle;
            this.IdDevolucion = idDevolucion;
            this.IdLC = idLC;
            this.Caracteristicas = caracteristicas;
            this.EstadoLC = estadoLC;
            this.Observacion = observacion;
            this.Estado = estado;
            this.PagaraCliente = pagaraCliente;
        }

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public int IdDevolucion { get => idDevolucion; set => idDevolucion = value; }
        public int IdLC { get => idLC; set => idLC = value; }
        public string Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public int EstadoLC { get => estadoLC; set => estadoLC = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public int PagaraCliente { get => pagaraCliente; set => pagaraCliente = value; }
        public int Seleccionado { get => seleccionado; set => seleccionado = value; }
        public int Danado { get => danado; set => danado = value; }
        public int Cobrar { get => cobrar; set => cobrar = value; }
        public string CodigoLC { get => codigoLC; set => codigoLC = value; }
        public string MarcaLC { get => marcaLC; set => marcaLC = value; }
        public string ModeloLC { get => modeloLC; set => modeloLC = value; }
        public int IdSalidaDetalle { get => idSalidaDetalle; set => idSalidaDetalle = value; }
        public int IdSucursal { get => idSucursal; set => idSucursal = value; }
    }
}

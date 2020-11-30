using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cambio
    {
        private int idCambio;
        private int idSalida;
        private int idSalidaDet;
        private int idLCAntiguo;
        private string codigoLCAntiguo;
        private int estadoLCAntiguo;
        private int idCliente;
        private int idSucursal;
        private string nombreCliente;
        private string rucDni;
        private string guiaCambio;
        private DateTime fechaCambio;
        private DateTime fechaIniContrato;
        private DateTime fechaFinContrato;
        private string ticketTecnico;
        private LC laptopNuevo;
        private int fueDevuelto;
        private int pagaraCliente;
        private int danoLC;
        private string observacion;
        private int estado;

        public Cambio()
        {
            this.LaptopNuevo = new LC();
            this.Estado = 1;

        }


        public Cambio(Cambio c)
        {
            this.IdCambio = c.IdCambio;
            this.IdSalida = c.IdSalida;
            this.IdSalidaDet = c.IdSalidaDet;
            this.IdLCAntiguo = c.IdLCAntiguo;
            this.CodigoLCAntiguo = c.CodigoLCAntiguo;
            this.EstadoLCAntiguo = c.EstadoLCAntiguo;
            this.IdCliente = c.IdCliente;
            this.IdSucursal = c.IdSucursal;
            this.NombreCliente = c.NombreCliente;
            this.RucDni = c.RucDni;
            this.GuiaCambio = c.GuiaCambio;
            this.FechaCambio = c.FechaCambio;
            this.TicketTecnico = c.TicketTecnico;
            this.LaptopNuevo = c.LaptopNuevo;
            this.FueDevuelto = c.FueDevuelto;
            this.PagaraCliente = c.PagaraCliente;
            this.DanoLC = c.DanoLC;
            this.Observacion = c.Observacion;
            this.Estado = c.Estado;
            this.FechaIniContrato = c.FechaIniContrato;
            this.FechaFinContrato = c.FechaFinContrato;
        }

        public Cambio(int idCambio, int idSalida, int idSalidaDet, int idLCAntiguo, string codigoLCAntiguo, int estadoLCAntiguo, int idCliente, int idSucursal, string nombreCliente, string rucDni, string guiaCambio, DateTime fechaCambio, string ticketTecnico, LC laptopNuevo, int fueDevuelto, int pagaraCliente, int danoLC, string observacion, int estado)
        {
            this.IdCambio = idCambio;
            this.IdSalida = idSalida;
            this.IdSalidaDet = idSalidaDet;
            this.IdLCAntiguo = idLCAntiguo;
            this.CodigoLCAntiguo = codigoLCAntiguo;
            this.EstadoLCAntiguo = estadoLCAntiguo;
            this.IdCliente = idCliente;
            this.IdSucursal = idSucursal;
            this.NombreCliente = nombreCliente;
            this.RucDni = rucDni;
            this.GuiaCambio = guiaCambio;
            this.FechaCambio = fechaCambio;
            this.TicketTecnico = ticketTecnico;
            this.LaptopNuevo = laptopNuevo;
            this.FueDevuelto = fueDevuelto;
            this.PagaraCliente = pagaraCliente;
            this.DanoLC = danoLC;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public int IdLC { get => LaptopNuevo.IdLC; }
        public string Codigo { get => LaptopNuevo.Codigo; }
        public int IdMarca { get => LaptopNuevo.Modelo.IdMarca; }
        public string MarcaLC { get => LaptopNuevo.Modelo.NombreMarca; }
        public int IdModelo { get => LaptopNuevo.Modelo.IdModelo; }
        public string NombreModeloLC { get => LaptopNuevo.Modelo.NombreModelo; }
        public double TamanoPantalla { get => LaptopNuevo.TamanoPantalla; }
        public int IdProcesador { get => LaptopNuevo.Procesador.IdProcesador; }
        public string TipoProcesador { get => LaptopNuevo.Procesador.Modelo.NombreModelo; }
        public int GeneracionProcesador { get => LaptopNuevo.Procesador.Generacion; }
        public int IdVideo { get => LaptopNuevo.Video.IdVideo; }
        public string NombreModeloVideo { get => LaptopNuevo.Video.Modelo.NombreModelo; }
        public int CapacidadVideo { get => LaptopNuevo.Video.Capacidad; }


        public int IdCambio { get => idCambio; set => idCambio = value; }
        public int IdSalida { get => idSalida; set => idSalida = value; }
        public int IdSalidaDet { get => idSalidaDet; set => idSalidaDet = value; }
        public int IdLCAntiguo { get => idLCAntiguo; set => idLCAntiguo = value; }
        public string CodigoLCAntiguo { get => codigoLCAntiguo; set => codigoLCAntiguo = value; }
        public int EstadoLCAntiguo { get => estadoLCAntiguo; set => estadoLCAntiguo = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdSucursal { get => idSucursal; set => idSucursal = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string RucDni { get => rucDni; set => rucDni = value; }
        public string GuiaCambio { get => guiaCambio; set => guiaCambio = value; }
        public DateTime FechaCambio { get => fechaCambio; set => fechaCambio = value; }
        public string TicketTecnico { get => ticketTecnico; set => ticketTecnico = value; }
        public LC LaptopNuevo { get => laptopNuevo; set => laptopNuevo = value; }
        public int FueDevuelto { get => fueDevuelto; set => fueDevuelto = value; }
        public int PagaraCliente { get => pagaraCliente; set => pagaraCliente = value; }
        public int DanoLC { get => danoLC; set => danoLC = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public DateTime FechaIniContrato { get => fechaIniContrato; set => fechaIniContrato = value; }
        public DateTime FechaFinContrato { get => fechaFinContrato; set => fechaFinContrato = value; }
    }
}

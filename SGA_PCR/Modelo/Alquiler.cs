using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Alquiler
    {
        private int idAlquiler;
        private int idCliente;
        private int idSucursal;
        private string rucDni;
        private DateTime fechaSalida;
        private DateTime fechaIniContrato;
        private DateTime fechaFinContrato;
        private string nroContrato;
        private string nroOC;
        private string observacion;
        private int estado;
        private Usuario usuarioRegistro;
        private BindingList<AlquilerDetalle> detalles;

        public Alquiler()
        {
            this.IdAlquiler = 0;
            this.IdCliente = 0;
            this.IdSucursal = 0;
            this.Estado = 6;
            this.NroOC = "";
            this.NroContrato = "";
            this.Observacion = "";
            this.RucDni = "";
            UsuarioRegistro = new Usuario();
            Detalles = new BindingList<AlquilerDetalle>();
        }

        public Alquiler(int idAlquiler, int idCliente, int idSucursal, string rucDni, DateTime fechaSalida, DateTime fechaIniContrato, DateTime fechaFinContrato, string nroContrato, string nroOC, string observacion, int estado, Usuario usuarioRegistro, BindingList<AlquilerDetalle> detalles)
        {
            this.IdAlquiler = idAlquiler;
            this.IdCliente = idCliente;
            this.IdSucursal = idSucursal;
            this.RucDni = rucDni;
            this.FechaSalida = fechaSalida;
            this.FechaIniContrato = fechaIniContrato;
            this.FechaFinContrato = fechaFinContrato;
            this.NroContrato = nroContrato;
            this.NroOC = nroOC;
            this.Observacion = observacion;
            this.Estado = estado;
            this.UsuarioRegistro = usuarioRegistro;
            this.Detalles = detalles;
        }

        public int IdAlquiler { get => idAlquiler; set => idAlquiler = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdSucursal { get => idSucursal; set => idSucursal = value; }
        public string RucDni { get => rucDni; set => rucDni = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public DateTime FechaIniContrato { get => fechaIniContrato; set => fechaIniContrato = value; }
        public DateTime FechaFinContrato { get => fechaFinContrato; set => fechaFinContrato = value; }
        public string NroContrato { get => nroContrato; set => nroContrato = value; }
        public string NroOC { get => nroOC; set => nroOC = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public Usuario UsuarioRegistro { get => usuarioRegistro; set => usuarioRegistro = value; }
        public BindingList<AlquilerDetalle> Detalles { get => detalles; set => detalles = value; }
    }
}

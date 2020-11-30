using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClienteSucursal
    {
        private int idSucursal;
        private int idCliente;
        private string nroDocumento;
        private string nombreContacto;
        private string direccion;
        private string telefono;
        private string email;
        private string observacion;
        private int estado;


        public ClienteSucursal()
        {
            observacion = "";
        }

        public ClienteSucursal(int idSucursal, int idCliente, string nroDocumento, string nombreContacto, string direccion, string telefono, string email, string observacion, int estado)
        {
            this.IdSucursal = idSucursal;
            this.IdCliente = idCliente;
            this.NroDocumento = nroDocumento;
            this.NombreContacto = nombreContacto;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public int IdSucursal { get => idSucursal; set => idSucursal = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string NroDocumento { get => nroDocumento; set => nroDocumento = value; }
        public string NombreContacto { get => nombreContacto; set => nombreContacto = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}

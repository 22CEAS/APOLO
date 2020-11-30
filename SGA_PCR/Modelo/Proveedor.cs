using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Proveedor
    {
        private int idProveedor;
        private string ruc;
        private string razonSocial;
        private string nombreComercial;
        private string abreviacion;
        private string direccion;
        private string telefono;
        private string fax;
        private string email;
        private string observacion;
        private string nombreContacto;
        private string telefonoContacto;
        private string emailContacto;
        private int estado;

        public Proveedor()
        {
            this.Observacion = "";
            this.Fax = "";
            this.Estado = 1;
        }

        public Proveedor(int idProveedor, string ruc, string razonSocial, string nombreComercial, string abreviacion, string direccion, string telefono, string fax, string email, string observacion, string nombreContacto, string telefonoContacto, string emailContacto, int estado)
        {
            this.IdProveedor = idProveedor;
            this.Ruc = ruc;
            this.RazonSocial = razonSocial;
            this.NombreComercial = nombreComercial;
            this.Abreviacion = abreviacion;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Fax = fax;
            this.Email = email;
            this.Observacion = observacion;
            this.NombreContacto = nombreContacto;
            this.TelefonoContacto = telefonoContacto;
            this.EmailContacto = emailContacto;
            this.Estado = estado;
        }

        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string NombreComercial { get => nombreComercial; set => nombreComercial = value; }
        public string Abreviacion { get => abreviacion; set => abreviacion = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Email { get => email; set => email = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string NombreContacto { get => nombreContacto; set => nombreContacto = value; }
        public string TelefonoContacto { get => telefonoContacto; set => telefonoContacto = value; }
        public string EmailContacto { get => emailContacto; set => emailContacto = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}

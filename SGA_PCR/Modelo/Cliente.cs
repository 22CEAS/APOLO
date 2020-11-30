using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        private int idCliente;
        private int tipoDocumento;
        private string nroDocumento;
        private string nombre_razonSocial;
        private string telefono;
        private string email;
        private string KAM;
        private Usuario kam;
        private bool seleccionar;
        private int estado;
        private BindingList<ClienteSucursal> sucursales;


        public Cliente()
        {
            this.Kam = new Usuario();
            this.Sucursales = new BindingList<ClienteSucursal>();
        }



        public Cliente(int idCliente, int tipoDocumento, string nroDocumento, string nombre_razonSocial, string telefono, string email, Usuario kam,bool seleccionar, int estado)
        {
            this.IdCliente = idCliente;
            this.TipoDocumento = tipoDocumento;
            this.NroDocumento = nroDocumento;
            this.Nombre_razonSocial = nombre_razonSocial;
            this.Telefono = telefono;
            this.Email = email;
            this.Kam = kam;
            this.Seleccionar = seleccionar;
            this.Estado = estado;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string NroDocumento { get => nroDocumento; set => nroDocumento = value; }
        public string Nombre_razonSocial { get => nombre_razonSocial; set => nombre_razonSocial = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public Usuario Kam { get => kam; set => kam = value; }
        public int Estado { get => estado; set => estado = value; }
        public BindingList<ClienteSucursal> Sucursales { get => sucursales; set => sucursales = value; }
        public bool Seleccionar { get => seleccionar; set => seleccionar = value; }
        public string KAM1 { get => KAM; set => KAM = value; }
    }
}

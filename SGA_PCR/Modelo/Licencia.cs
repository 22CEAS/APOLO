using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Licencia
    {
        private int idLicencia;
        private string codigo;
        private int idModelo;
        private int idCategoria;
        private string categoria;
        private Modelo modelo;
        private int idLC;
        private int cantidad;
        private string clave;
        private DateTime fechaActivacion;
        private Double precio;
        private string ubicacion;
        private string observacion;
        private string estado;

        public Licencia()
        {
            this.Modelo = new Modelo();
            this.Observacion = "";
        }

        public Licencia(int idLicencia, string codigo, int idModelo, Modelo modelo, int idLC, string clave, DateTime fechaActivacion, string ubicacion, string observacion, string estado)
        {
            this.IdLicencia = idLicencia;
            this.Codigo = codigo;
            this.IdModelo = idModelo;
            this.Modelo = modelo;
            this.IdLC = idLC;
            this.Clave = clave;
            this.FechaActivacion = fechaActivacion;
            this.Ubicacion = ubicacion;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public int IdLicencia { get => idLicencia; set => idLicencia = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int IdModelo { get => idModelo; set => idModelo = value; }
        public Modelo Modelo { get => modelo; set => modelo = value; }
        public string Marca { get => Modelo.NombreMarca; set => Modelo.NombreMarca = value; }
        public string Version { get => Modelo.NombreModelo; set => Modelo.NombreModelo = value; }
        public int IdLC { get => idLC; set => idLC = value; }
        public string Clave { get => clave; set => clave = value; }
        public DateTime FechaActivacion { get => fechaActivacion; set => fechaActivacion = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string Estado { get => estado; set => estado = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}

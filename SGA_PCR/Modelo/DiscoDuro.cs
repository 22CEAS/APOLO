using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DiscoDuro
    {
        private int idDisco;
        private string codigo;
        private int idTipo;
        private Modelo tipo;
        private int idTamano;
        private string tamano;
        private int idCapacidad;
        private int capacidad;
        private int cantidad;
        private Double precio;
        private string ubicacion;
        private string observacion;
        private int estado;

        public DiscoDuro()
        {
            this.Tipo = new Modelo();
            this.Observacion = "";
            this.Cantidad = 0;
            this.estado = 1;
            this.Ubicacion = "ALMACEN";
        }

        public DiscoDuro(int idDisco, string codigo, int idTipo, Modelo tipo, int idTamano, string tamano, int idCapacidad, int capacidad, int cantidad, string ubicacion, string observacion, int estado)
        {
            this.IdDisco = idDisco;
            this.Codigo = codigo;
            this.IdTipo = idTipo;
            this.Tipo = tipo;
            this.IdTamano = idTamano;
            this.Tamano = tamano;
            this.IdCapacidad = idCapacidad;
            this.Capacidad = capacidad;
            this.Cantidad = cantidad;
            this.Ubicacion = ubicacion;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public int IdDisco { get => idDisco; set => idDisco = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public Modelo Tipo { get => tipo; set => tipo = value; }
        public string TipoDisco { get => Tipo.NombreModelo; set => Tipo.NombreModelo = value; }
        public int IdTamano { get => idTamano; set => idTamano = value; }
        public string Tamano { get => tamano; set => tamano = value; }
        public int IdCapacidad { get => idCapacidad; set => idCapacidad = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}

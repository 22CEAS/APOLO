using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Memoria
    {
        private int idMemoria;
        private string codigo;
        private int idModelo;
        private Modelo modelo;
        private int idBusFrecuencia;
        private double busFrecuencia;
        private int idCapacidad;
        private int capacidad;
        private int idTipo;
        private string tipo;
        private int cantidad;
        private Double precio;
        private string ubicacion;
        private string observacion;
        private int estado;

        public Memoria()
        {
            this.Modelo = new Modelo();
            this.Observacion = "";
            this.Cantidad = 0;
            this.estado = 1;
            this.Ubicacion = "ALMACEN";
        }

        public Memoria(int idMemoria, string codigo, int idModelo, Modelo modelo, int idBusFrecuencia, double busFrecuencia, int idCapacidad, int capacidad, int idTipo, string tipo, int cantidad, string ubicacion, string observacion, int estado)
        {
            this.IdMemoria = idMemoria;
            this.Codigo = codigo;
            this.IdModelo = idModelo;
            this.Modelo = modelo;
            this.IdBusFrecuencia = idBusFrecuencia;
            this.BusFrecuencia = busFrecuencia;
            this.IdCapacidad = idCapacidad;
            this.Capacidad = capacidad;
            this.IdTipo = idTipo;
            this.Tipo = tipo;
            this.Cantidad = cantidad;
            this.Ubicacion = ubicacion;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public int IdMemoria { get => idMemoria; set => idMemoria = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int IdModelo { get => idModelo; set => idModelo = value; }
        public Modelo Modelo { get => modelo; set => modelo = value; }
        public string TipoMemoria { get => Modelo.NombreModelo; set => Modelo.NombreModelo = value; }
        public int IdBusFrecuencia { get => idBusFrecuencia; set => idBusFrecuencia = value; }
        public double BusFrecuencia { get => busFrecuencia; set => busFrecuencia = value; }
        public int IdCapacidad { get => idCapacidad; set => idCapacidad = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Tipo2 { get => tipo; set => tipo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}

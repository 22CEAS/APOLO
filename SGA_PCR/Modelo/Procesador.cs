using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Procesador
    {
        private int idProcesador;
        private string codigo;
        private int idModelo;
        private Modelo modelo;
        private int idGeneracion;
        private int generacion;
        private int idVelocidad;
        private string velocidad;
        private int idVelocidadMax;
        private double velocidadMax;
        private string observacion;
        private int estado;

        public Procesador()
        {
            this.Modelo = new Modelo();
            this.Observacion = "";
            this.estado = 1;
        }

        public Procesador(int idProcesador, string codigo, int idModelo, Modelo modelo, int idGeneracion, int generacion, int idVelocidad, string velocidad, int idVelocidadMax, double velocidadMax, string observacion, int estado)
        {
            this.IdProcesador = idProcesador;
            this.Codigo = codigo;
            this.IdModelo = idModelo;
            this.Modelo = modelo;
            this.IdGeneracion = idGeneracion;
            this.Generacion = generacion;
            this.IdVelocidad = idVelocidad;
            this.Velocidad = velocidad;
            this.IdVelocidadMax = idVelocidadMax;
            this.VelocidadMax = velocidadMax;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public int IdProcesador { get => idProcesador; set => idProcesador = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int IdModelo { get => idModelo; set => idModelo = value; }
        public Modelo Modelo { get => modelo; set => modelo = value; }
        public int IdGeneracion { get => idGeneracion; set => idGeneracion = value; }
        public int Generacion { get => generacion; set => generacion = value; }
        public int IdVelocidad { get => idVelocidad; set => idVelocidad = value; }
        public string Velocidad { get => velocidad; set => velocidad = value; }
        public int IdVelocidadMax { get => idVelocidadMax; set => idVelocidadMax = value; }
        public double VelocidadMax { get => velocidadMax; set => velocidadMax = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}

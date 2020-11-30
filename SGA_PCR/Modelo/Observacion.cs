using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Observacion
    {
        private int idObervacion;
        private int idCliente;
        private String cliente;
        private String rUC;
        private int idLC;
        private String codigoLC;
        private int idDevolucion;
        private int idCambio;
        private String guiaLevantamiento;
        private String observacionDeuda;
        private String observacionLevantamiento;
        private DateTime fechaLevantamiento;
        private int idEstado;
        private String estado;
        private bool seleccion;

        public Observacion()
        {

        }

        public int IdObervacion { get => idObervacion; set => idObervacion = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public int IdLC { get => idLC; set => idLC = value; }
        public string CodigoLC { get => codigoLC; set => codigoLC = value; }
        public int IdDevolucion { get => idDevolucion; set => idDevolucion = value; }
        public int IdCambio { get => idCambio; set => idCambio = value; }
        public string GuiaLevantamiento { get => guiaLevantamiento; set => guiaLevantamiento = value; }
        public string ObservacionDeuda { get => observacionDeuda; set => observacionDeuda = value; }
        public string ObservacionLevantamiento { get => observacionLevantamiento; set => observacionLevantamiento = value; }
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string Estado { get => estado; set => estado = value; }
        public string RUC { get => rUC; set => rUC = value; }
        public DateTime FechaLevantamiento { get => fechaLevantamiento; set => fechaLevantamiento = value; }
        public bool Seleccion { get => seleccion; set => seleccion = value; }
    }
}

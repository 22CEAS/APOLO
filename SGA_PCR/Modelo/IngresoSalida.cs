using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class IngresoSalida
    {
        private int idLC;
        private string codigoLC;
        private int idCliente;
        private string nroIdentidad;
        private string nombreCliente;
        private string documentoReferencia;
        private int idEstadoAnt;
        private int idEstado;
        private string nombreEstado;
        private DateTime fechaIngresoSalida;

        public int IdLC { get => idLC; set => idLC = value; }
        public string CodigoLC { get => codigoLC; set => codigoLC = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string NroIdentidad { get => nroIdentidad; set => nroIdentidad = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string DocumentoReferencia { get => documentoReferencia; set => documentoReferencia = value; }
        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string NombreEstado { get => nombreEstado; set => nombreEstado = value; }
        public DateTime FechaIngresoSalida { get => fechaIngresoSalida; set => fechaIngresoSalida = value; }
        public int IdEstadoAnt { get => idEstadoAnt; set => idEstadoAnt = value; }
    }
}

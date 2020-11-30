using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Reparacion
    {
        private int idReparacion;
        private int idLC;
        private string codigoLC;
        private DateTime fechaReparacion;
        private int estadoLCAnt;
        private int estadoLCAct;
        private string observacionActual;
        private string observacionReparacion;
        private int estado;

        public Reparacion()
        {
            this.IdReparacion = 0;
            this.Estado = 1;
        }

        public Reparacion(Reparacion c)
        {
            this.IdReparacion = c.IdReparacion;
            this.IdLC = c.IdLC;
            this.CodigoLC = c.CodigoLC;
            this.FechaReparacion = c.FechaReparacion;
            this.EstadoLCAct = c.EstadoLCAct;
            this.EstadoLCAnt = c.EstadoLCAnt;
            this.ObservacionActual = c.ObservacionActual;
            this.ObservacionReparacion = c.ObservacionReparacion;
            this.Estado = c.Estado;
        }

        public int IdReparacion { get => idReparacion; set => idReparacion = value; }
        public int IdLC { get => idLC; set => idLC = value; }
        public string CodigoLC { get => codigoLC; set => codigoLC = value; }
        public DateTime FechaReparacion { get => fechaReparacion; set => fechaReparacion = value; }
        public string ObservacionActual { get => observacionActual; set => observacionActual = value; }
        public string ObservacionReparacion { get => observacionReparacion; set => observacionReparacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public int EstadoLCAnt { get => estadoLCAnt; set => estadoLCAnt = value; }
        public int EstadoLCAct { get => estadoLCAct; set => estadoLCAct = value; }
    }
}

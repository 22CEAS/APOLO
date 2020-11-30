using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Devolucion
    {
        private int idDevolucion;
        private int idCliente;
        private string rucDni;
        private string guiaDevolucion;
        private DateTime fechaDevolucion;
        private string observacion;
        private int estado;
        private BindingList<DevolucionDetalle> detalles;

        public Devolucion()
        {
            this.IdCliente = 0;
            this.idDevolucion = 0;
            this.GuiaDevolucion = "";
            this.Observacion = "";
            this.RucDni = "";
            this.Estado = 1;
            this.Detalles = new BindingList<DevolucionDetalle>();
        }

        public Devolucion(int idDevolucion, int idCliente, string guiaDevolucion, DateTime fechaDevolucion, string observacion, int estado, BindingList<DevolucionDetalle> detalles)
        {
            this.IdDevolucion = idDevolucion;
            this.IdCliente = idCliente;
            this.GuiaDevolucion = guiaDevolucion;
            this.FechaDevolucion = fechaDevolucion;
            this.Observacion = observacion;
            this.Estado = estado;
            this.Detalles = detalles;
        }

        public int IdDevolucion { get => idDevolucion; set => idDevolucion = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string GuiaDevolucion { get => guiaDevolucion; set => guiaDevolucion = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public BindingList<DevolucionDetalle> Detalles { get => detalles; set => detalles = value; }
        public string RucDni { get => rucDni; set => rucDni = value; }

        public void LlenarDatos(DataTable data)
        {
            int rec = 0;
            while (rec < data.Rows.Count)
            {
                DevolucionDetalle detalle = new DevolucionDetalle();

                detalle.IdDetalle = 0;
                detalle.IdDevolucion = 0;
                detalle.IdLC = Convert.ToInt32(data.Rows[rec]["IdLC"].ToString()); ;
                detalle.Caracteristicas = "";
                detalle.EstadoLC = 0;
                detalle.Observacion = "";
                detalle.Estado = 0;
                detalle.PagaraCliente = 0;
                detalle.Seleccionado = 0;
                this.Detalles.Add(detalle);
                rec++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class LC
    {
        private int idLC;
        private string codigo;
        private Modelo modelo;
        private string descripcion;
        private double tamanoPantalla;
        private Procesador procesador;
        private Video video;
        private BindingList<DiscoDuro> discos;
        private BindingList<Memoria> memorias;
        private BindingList<Licencia> licencias;
        private string partNumber;
        private string serieFabrica;
        private int garantia;
        private DateTime fecInicioSeguro;
        private DateTime fecFinSeguro;
        private string ubicacion;
        private string observacion;
        private int estado;
        private string estadoNombre;
        private string cliente;
        private string rucCliente;
        private string disco1;
        private string capacidadDisco1;
        private string disco2;
        private string capacidadDisco2;
        private string capacidadMemoria;
        private string licenciaWindows;
        private string licenciaAntivirus;
        private string licenciaOffice;
        private string idSalida;//Esto se usa más en el caso de preAlquiler


        public LC()
        {
            this.Modelo = new Modelo();
            this.Procesador = new Procesador();
            this.Video = new Video();
            this.Discos = new BindingList<DiscoDuro>();
            this.Memorias = new BindingList<Memoria>();
            this.Licencias = new BindingList<Licencia>();
            this.Observacion = "";
            this.IdSalida = "";

        }

        public LC(int idLC, string codigo, Modelo modelo, string descripcion, double tamanoPantalla, Procesador procesador, Video video, BindingList<DiscoDuro> discos, BindingList<Memoria> memorias, BindingList<Licencia> licencias, string partNumber, string serieFabrica, int garantia, DateTime fecInicioSeguro, DateTime fecFinSeguro, string ubicacion, string observacion, int estado)
        {
            this.IdLC = idLC;
            this.Codigo = codigo;
            this.Modelo = modelo;
            this.Descripcion = descripcion;
            this.TamanoPantalla = tamanoPantalla;
            this.Procesador = procesador;
            this.Video = video;
            this.Discos = discos;
            this.Memorias = memorias;
            this.PartNumber = partNumber;
            this.SerieFabrica = serieFabrica;
            this.Garantia = garantia;
            this.FecInicioSeguro = fecInicioSeguro;
            this.FecFinSeguro = fecFinSeguro;
            this.Ubicacion = ubicacion;
            this.Observacion = observacion;
            this.Estado = estado;
        }

        public int IdLC { get => idLC; set => idLC = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public Modelo Modelo { get => modelo; set => modelo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double TamanoPantalla { get => tamanoPantalla; set => tamanoPantalla = value; }
        public Procesador Procesador { get => procesador; set => procesador = value; }
        public Video Video { get => video; set => video = value; }
        public BindingList<DiscoDuro> Discos { get => discos; set => discos = value; }
        public BindingList<Memoria> Memorias { get => memorias; set => memorias = value; }
        public string PartNumber { get => partNumber; set => partNumber = value; }
        public string SerieFabrica { get => serieFabrica; set => serieFabrica = value; }
        public int Garantia { get => garantia; set => garantia = value; }
        public DateTime FecInicioSeguro { get => fecInicioSeguro; set => fecInicioSeguro = value; }
        public DateTime FecFinSeguro { get => fecFinSeguro; set => fecFinSeguro = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Estado { get => estado; set => estado = value; }
        public BindingList<Licencia> Licencias { get => licencias; set => licencias = value; }

        public void SetDisco(DataTable data) 
        {
            int rec = 0;
            while (rec < data.Rows.Count)
            {
                DiscoDuro disco = new DiscoDuro();
                disco.IdDisco = Convert.ToInt32(data.Rows[rec]["IdDisco"].ToString());
                disco.Tipo.NombreModelo = data.Rows[rec]["TipoDisco"].ToString();
                disco.Tamano = data.Rows[rec]["Tamano"].ToString();
                disco.Capacidad = Convert.ToInt32(data.Rows[rec]["Capacidad"].ToString());
                disco.Cantidad = Convert.ToInt32(data.Rows[rec]["Cantidad"].ToString());
                this.Discos.Add(disco);
                rec++;
            }
        }

        public void SetMemoria(DataTable data)
        {
            int rec = 0;
            while (rec < data.Rows.Count)
            {
                Memoria memoria = new Memoria();
                memoria.IdMemoria = Convert.ToInt32(data.Rows[rec]["IdMemoria"].ToString());
                memoria.Modelo.NombreModelo = data.Rows[rec]["TipoMemoria"].ToString();
                memoria.Tipo = data.Rows[rec]["Tipo2"].ToString();
                memoria.Capacidad = Convert.ToInt32(data.Rows[rec]["Capacidad"].ToString());
                memoria.Cantidad = Convert.ToInt32(data.Rows[rec]["Cantidad"].ToString());
                this.Memorias.Add(memoria);
                rec++;
            }
        }

        public void SetLicencia(DataTable data)
        {
            int rec = 0;
            while (rec < data.Rows.Count)
            {
                Licencia licencia = new Licencia();
                licencia.IdLicencia = Convert.ToInt32(data.Rows[rec]["IdLicencia"].ToString());
                licencia.IdCategoria = Convert.ToInt32(data.Rows[rec]["IdCategoria"].ToString());
                licencia.Categoria = data.Rows[rec]["Categoria"].ToString();
                licencia.Modelo.IdMarca = Convert.ToInt32(data.Rows[rec]["IdMarca"].ToString());
                licencia.Modelo.NombreMarca = data.Rows[rec]["Marca"].ToString();
                licencia.Modelo.IdModelo = Convert.ToInt32(data.Rows[rec]["IdModelo"].ToString());
                licencia.Modelo.NombreModelo = data.Rows[rec]["Version"].ToString();
                licencia.Clave = data.Rows[rec]["Clave"].ToString();
                licencia.Ubicacion = data.Rows[rec]["Ubicacion"].ToString();
                this.Licencias.Add(licencia);
                rec++;
            }
        }


        public void SetDisco(DataView data)
        {
            foreach (DataRowView row in data)
            {
                DiscoDuro disco = new DiscoDuro();
                disco.IdDisco = Convert.ToInt32(row["IdDisco"].ToString());
                disco.Tipo.NombreModelo = row["TipoDisco"].ToString();
                disco.Tamano = row["Tamano"].ToString();
                disco.Capacidad = Convert.ToInt32(row["Capacidad"].ToString());
                disco.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                this.Discos.Add(disco);
            }
        }

        public void SetMemoria(DataView data)
        {
            foreach (DataRowView row in data)
            {
                Memoria memoria = new Memoria();
                memoria.IdMemoria = Convert.ToInt32(row["IdMemoria"].ToString());
                memoria.Modelo.NombreModelo = row["TipoMemoria"].ToString();
                memoria.Tipo = row["Tipo2"].ToString();
                memoria.Capacidad = Convert.ToInt32(row["Capacidad"].ToString());
                memoria.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                this.Memorias.Add(memoria);
            }
        }

        public void SetLicencia(DataView data)
        {
            foreach (DataRowView row in data)
            {
                Licencia licencia = new Licencia();
                licencia.IdLicencia = Convert.ToInt32(row["IdLicencia"].ToString());
                licencia.IdCategoria = Convert.ToInt32(row["IdCategoria"].ToString());
                licencia.Categoria = row["Categoria"].ToString();
                licencia.Modelo.IdMarca = Convert.ToInt32(row["IdMarca"].ToString());
                licencia.Modelo.NombreMarca = row["Marca"].ToString();
                licencia.Modelo.IdModelo = Convert.ToInt32(row["IdModelo"].ToString());
                licencia.Modelo.NombreModelo = row["Version"].ToString();
                licencia.Clave = row["Clave"].ToString();
                licencia.Ubicacion = row["Ubicacion"].ToString();
                this.Licencias.Add(licencia);
            }
        }

        public int IdMarca { get => Modelo.IdMarca; set => Modelo.IdMarca = value; }
        public string MarcaLC { get => Modelo.NombreMarca; set => Modelo.NombreMarca = value; }
        public int IdModelo { get => Modelo.IdModelo; set => Modelo.IdModelo = value; }
        public string NombreModeloLC { get => Modelo.NombreModelo; set => Modelo.NombreModelo = value; }
        public int IdProcesador { get => Procesador.IdProcesador; set => Procesador.IdProcesador = value; }
        public int IdTipoProcesador { get => Procesador.Modelo.IdModelo; set => Procesador.Modelo.IdModelo = value; }
        public string TipoProcesador { get => Procesador.Modelo.NombreModelo; set => Procesador.Modelo.NombreModelo = value; }
        public int IdGeneracionProcesador { get => Procesador.IdGeneracion; set => Procesador.IdGeneracion = value; }
        public int GeneracionProcesador { get => Procesador.Generacion; set => Procesador.Generacion = value; }
        public int IdVideo { get => Video.IdVideo; set => Video.IdVideo = value; }
        public string NombreModeloVideo { get => Video.Modelo.NombreModelo; set => Video.Modelo.NombreModelo = value; }
        public int CapacidadVideo { get => Video.Capacidad; set => Video.Capacidad = value; }
        public string EstadoNombre { get => estadoNombre; set => estadoNombre = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Disco1 { get => disco1; set => disco1 = value; }
        public string CapacidadDisco1 { get => capacidadDisco1; set => capacidadDisco1 = value; }
        public string Disco2 { get => disco2; set => disco2 = value; }
        public string CapacidadDisco2 { get => capacidadDisco2; set => capacidadDisco2 = value; }
        public string CapacidadMemoria { get => capacidadMemoria; set => capacidadMemoria = value; }
        public string LicenciaWindows { get => licenciaWindows; set => licenciaWindows = value; }
        public string LicenciaAntivirus { get => licenciaAntivirus; set => licenciaAntivirus = value; }
        public string LicenciaOffice { get => licenciaOffice; set => licenciaOffice = value; }
        public string IdSalida { get => idSalida; set => idSalida = value; }
        public string RucCliente { get => rucCliente; set => rucCliente = value; }
    }
}

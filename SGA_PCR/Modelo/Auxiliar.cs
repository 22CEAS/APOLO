using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Auxiliar
    {
        private int _idAuxiliar;
        private string _cod_tabla;
        private string _descripcion;
        private int _activo;

        public Auxiliar( )
        {
            this._activo = 1;
        }

        public Auxiliar(int idAuxiliar, string cod_tabla, string descripcion, int activo)
        {
            _idAuxiliar = idAuxiliar;
            _cod_tabla = cod_tabla;
            _descripcion = descripcion;
            _activo = activo;
        }

        public int IdAuxiliar { get => _idAuxiliar; set => _idAuxiliar = value; }
        public string Cod_tabla { get => _cod_tabla; set => _cod_tabla = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Activo { get => _activo; set => _activo = value; }
    }
}

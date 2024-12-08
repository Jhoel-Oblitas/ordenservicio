using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuarios
    {
        //Atributos
        private int _Id;
        private int _RolId;
        private string _Nombres;
        private string _Email;
        private string _Clave;
        private bool _Activo;
        private string _TextoBuscar;

        public DUsuarios()
        {
        }

        public DUsuarios(int id, int rolId, string nombres, string email, string clave, bool activo, string textoBuscar)
        {
            Id = id;
            RolId = rolId;
            Nombres = nombres;
            Email = email;
            Clave = clave;
            Activo = activo;
            TextoBuscar = textoBuscar;
        }

        public int Id { get => _Id; set => _Id = value; }
        public int RolId { get => _RolId; set => _RolId = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DRoles
    {
        //atributos de clase 
        private int _Id;
        private string _Nombre;
        private bool _Activo;
        private string _TextoBuscar;

        //metodos constructores
        public DRoles()
        {
        }

        public DRoles(int id, string nombre, bool activo, string textoBuscar)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Activo = activo;
            this.TextoBuscar = textoBuscar;
        }

        //metodos getter y setter
        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //metodo para insertar
        public string Insertar(DRoles Roles)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_roles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters .Add(ParId);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Roles.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParActivo = new SqlParameter();
                ParActivo.ParameterName = "@activo";
                ParActivo.SqlDbType = SqlDbType.Bit;
                ParActivo.Value = Roles.Activo;
                SqlCmd.Parameters.Add(ParActivo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el registro.";
            }
            catch(Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if(SqlCon.State==ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }

        //metodo editar

        public string Editar(DRoles Roles)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_roles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Roles.Id;
                SqlCmd.Parameters.Add(ParId);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Roles.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParActivo = new SqlParameter();
                ParActivo.ParameterName = "@activo";
                ParActivo.SqlDbType = SqlDbType.Bit;
                ParActivo.Value = Roles.Activo;
                SqlCmd.Parameters.Add(ParActivo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el registro.";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }

        //metodo eliminar
        public string Eliminar(DRoles Roles)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_roles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = Roles.Id;
                SqlCmd.Parameters.Add(ParId);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el registro.";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }

        //metodo mostrar
        public DataTable Mostrar()
        {
            DataTable Dtresultado = new DataTable("roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_roles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(Dtresultado);
            }
            catch(Exception ex)
            {
                Dtresultado = null;
            }
            return Dtresultado;
        }

        public DataTable BuscarNombre(DRoles Roles)
        {
            DataTable Dtresultado = new DataTable("roles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_roles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Roles.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(Dtresultado);
            }
            catch (Exception ex)
            {
                Dtresultado = null;
            }
            return Dtresultado;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class NRoles
    {
        public static string Insertar(string nombre)
        {
            DRoles Obj = new DRoles();
            Obj.Nombre = nombre;
            return Obj.Insertar(Obj);           
        }

        public static string Editar(int id, string nombre)
        {
            DRoles Obj = new DRoles();
            Obj.Id = id;
            Obj.Nombre = nombre;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int id)
        {
            DRoles Obj = new DRoles();
            Obj.Id = id;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DRoles().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar )
        {
            DRoles Obj = new DRoles();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}

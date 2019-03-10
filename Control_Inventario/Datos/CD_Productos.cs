using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class CD_Productos
    {
        private Conexion_BD conexion = new Conexion_BD();
        private SqlDataReader Leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();


        // Mostrar Datos 
        public DataTable mostrar()
        {
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();

            tabla.Load(Leer);
            conexion.CerrarConexion();

            return tabla;
        }

        // Para insetar datos en la tabla
        public void inserte(string nombre, string desc, string marca, double precio, int stock)
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "InsetarProductos";          
            comando.CommandType = CommandType.StoredProcedure;

            // Se agregan valores al los parametros del procedimiento 
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);


            comando.ExecuteNonQuery();                          

            comando.Parameters.Clear();  //Limpiar el buffer 
        }

        // Editar los Datos de La tabla
        public void editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@descrip", desc);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }


        //Eliminar los datos de la tabla 
        public void eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Datos;

namespace Negocio
{
    public class CN_Productos
    {
        private CD_Productos tabla  = new CD_Productos();

        public DataTable mostrarProd()
        {
            DataTable table = new DataTable();
            table = tabla.mostrar();
            return table;
        }

        public void insertarProd(string nombre, string desc, string marca, string precio, string stock)
        {
            tabla.inserte(nombre, desc, marca, Convert.ToDouble(precio), Int32.Parse(stock));
        }

        public void editarProd(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            tabla.editar(nombre, desc, marca, Convert.ToDouble(precio), Int32.Parse(stock), Convert.ToInt32(id));
        }

        public void eliminarProd(string id)
        {
            tabla.eliminar(Convert.ToInt32(id));
        }


    }
}

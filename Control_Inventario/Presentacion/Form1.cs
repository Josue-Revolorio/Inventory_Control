using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        private CN_Productos tableCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProdctos();
        }

        private void MostrarProdctos()
        {
            CN_Productos tabla = new CN_Productos();
            dataGridView1.DataSource = tabla.mostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    tableCN.insertarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Datos Guardados");
                    MostrarProdctos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Se pudo Guardar" + ex.ToString());

                }

            }
            if (Editar == true)
            {
                try
                {
                    tableCN.editarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Datos Modificados");
                    MostrarProdctos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Se pudo Editar" + ex.ToString());
                }

            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione La fila a editar");
            }
        }

        private void limpiarForm()
        {
            txtDesc.Clear();
            txtMarca.Text = "";
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                tableCN.eliminarProd(idProducto);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
            {
                MessageBox.Show("seleccione una fila por favor");
            }

        }
    }
}

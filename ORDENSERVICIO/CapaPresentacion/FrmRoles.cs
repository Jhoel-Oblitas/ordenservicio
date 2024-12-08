using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmRoles : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmRoles()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del Rol");
        }

        public void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje,"Sistema OS",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtId.Text = string.Empty;
            this.txtBuscar.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtId .ReadOnly = !valor;

        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;       
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NRoles.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text="Total de registros: "+Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NRoles.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BuscarNombre(); 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if(this.txtNombre.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados!");
                    errorIcono1.SetError(txtNombre, "Ingrese un nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NRoles.Insertar(this.txtNombre.Text.Trim().ToUpper());
                    }
                    else
                    {
                        rpta = NRoles.Editar(Convert.ToInt32(this.txtId),this.txtNombre.Text.Trim().ToUpper()); 
                    }
                }
                if (rpta.Equals("OK"))
                {
                    if(this.IsNuevo)
                    {
                        this.MensajeOK("Se inserto de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeOK("Se actualizo de forma correcta el registro");
                    }
                }
                else
                {
                    this.MensajeError(rpta);
                }

                IsNuevo = false;
                IsEditar = false;
                this.Botones();
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

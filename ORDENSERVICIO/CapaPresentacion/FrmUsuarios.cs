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
    public partial class FrmUsuarios : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmUsuarios()
        {
            InitializeComponent();
            this.LlenarComboRoles();
          
            
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de OS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NUsuarios.Mostrar();
            //this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void LlenarComboRoles()
        {
            cboIdRol.DataSource = NRoles.Mostrar();
            cboIdRol.ValueMember = "id";
            cboIdRol.DisplayMember = "nombre";

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }
    }
}

using POOCircunferencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOCircunferencia.Windows
{
    public partial class frmCircunferenciaAE : Form
    {
        public frmCircunferenciaAE()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private Circunferencia circunferencia;
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                circunferencia = new Circunferencia();
                circunferencia.Radio = int.Parse(RadioTextBox.Text);

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            return true;
        }

        public Circunferencia GetCircunferencia()
        {
            return circunferencia;
        }
    }
}

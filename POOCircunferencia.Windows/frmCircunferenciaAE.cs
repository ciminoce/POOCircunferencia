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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (circunferencia!=null)
            {
                RadioTextBox.Text = circunferencia.Radio.ToString();
            }
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
                //Veo si no existe ya una circunferencia
                if (circunferencia==null)
                {
                    circunferencia = new Circunferencia();
                    
                }
                circunferencia.Radio = int.Parse(RadioTextBox.Text);
                if (!circunferencia.Validar())
                {
                    errorProvider1.SetError(RadioTextBox,"Radio fuera del rango permitido");
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            //Controlar que se ingrese un número
            if (!int.TryParse(RadioTextBox.Text, out int radio))
            {
                valido = false;
                errorProvider1.SetError(RadioTextBox,"Radio mal ingresado");
            }
            //else if (radio<=0)
            //{
            //    valido = false;
            //    errorProvider1.SetError(RadioTextBox,"El radio debe ser positivo");
            //}
            return valido;
        }

        public Circunferencia GetCircunferencia()
        {
            return circunferencia;
        }

        public void SetCircunferencia(Circunferencia circ)
        {
            circunferencia = circ;
        }
    }
}

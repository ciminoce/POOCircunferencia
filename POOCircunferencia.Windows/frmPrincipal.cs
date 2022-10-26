using POOCircunferencia.Datos;
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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private RepositorioDeCircunferencias repositorio;
        private List<Circunferencia> lista;
        private int cantidad;

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            repositorio = new RepositorioDeCircunferencias();
            cantidad = repositorio.GetCantidad();
            MostrarTotal();
            if (cantidad>0)
            {
                lista = repositorio.GetLista();
                MostrarLista();
            }
            else
            {
                MessageBox.Show("No hay elementos en el repositorio",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void MostrarTotal()
        {
            CantidadLabel.Text = cantidad.ToString();
        }

        private void MostrarLista()
        {
            CircDataGridView.Rows.Clear();
            foreach (var circ in lista)
            {
                var r = ConstruirFila();
                SetearFila(r, circ);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            CircDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Circunferencia circ)
        {
            r.Cells[colRadio.Index].Value = circ.Radio;
            r.Cells[colPerimetro.Index].Value = circ.GetPerimetro().ToString("N2");
            r.Cells[colSuperficie.Index].Value = circ.GetSuperficie().ToString("N2");

        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(CircDataGridView);
            return r;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void NuevoToolStripButton_Click(object sender, EventArgs e)
        {
            frmCircunferenciaAE frm = new frmCircunferenciaAE() { Text = "Agregar Nueva Circunferencia" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                /*MessageBox.Show("Canceló el usuario")*/;
                return;
            }
            var circNueva = frm.GetCircunferencia();
            repositorio.Agregar(circNueva);
            var r = ConstruirFila();
            SetearFila(r, circNueva);
            AgregarFila(r);
            MessageBox.Show("Circunferencia agregada");
            cantidad = repositorio.GetCantidad();
            //MostrarTotal();
        }
    }
}

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

            r.Tag = circ;//guardo el objeto completo
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

        private void BorrarToolStripButton_Click(object sender, EventArgs e)
        {
            //Veo si tengo alguna fila seleccionada
            if (CircDataGridView.SelectedRows.Count==0)
            {
                return;
            }
            //Si hube seleccionado alguna fila
            var r = CircDataGridView.SelectedRows[0];
            Circunferencia circ = r.Tag as Circunferencia;
            DialogResult dr = MessageBox.Show(
                $"¿Desea dar de baja la circunferencia seleccionada de radio {circ.Radio}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr==DialogResult.No)
            {
                return;
            }

            if (repositorio.Borrar(circ))
            {
                lista.Remove(circ);//la saco de la lista de memoria
                CircDataGridView.Rows.Remove(r);
                cantidad = repositorio.GetCantidad();
                MostrarTotal();
                MessageBox.Show("Registro eliminado", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                
            }
            else
            {
                MessageBox.Show("No se pudo dar de baja", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void EditarToolStripButton_Click(object sender, EventArgs e)
        {
            if (CircDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            var r = CircDataGridView.SelectedRows[0];
            Circunferencia circ=r.Tag as Circunferencia;
            frmCircunferenciaAE frm = new frmCircunferenciaAE() { Text = "Editar Circunferencia" };
            frm.SetCircunferencia(circ);
            DialogResult dr=frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            circ = frm.GetCircunferencia();
            SetearFila(r,circ);
            MessageBox.Show("Circunferencia Modificada!!", 
                "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FiltroToolStripButton_Click(object sender, EventArgs e)
        {
            int radioFiltro = 10;
            lista = repositorio.FiltrarDatos(radioFiltro);
            MostrarLista();
            cantidad = repositorio.GetCantidadFiltrada(radioFiltro);
            MostrarTotal();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            lista = repositorio.GetLista();
            MostrarLista();
            cantidad = repositorio.GetCantidad();
            MostrarTotal();

        }
    }
}

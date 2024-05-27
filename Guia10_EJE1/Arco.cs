using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia10_EJE1
{
    public partial class Arco : Form
    {

        public bool control;
        public int dato;

        public Arco()
        {
            InitializeComponent();
            control = false;
            dato = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dato = Convert.ToInt16(txtPeso.Text.Trim());
                if (dato <= 0)
                {
                    MessageBox.Show("El peso debe ser mayor a 0", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    control = true;
                    Hide();
                }
            }
            catch (Exception ) 
            {
                MessageBox.Show("Debes ingresar un valor numerico", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control = false;
            Hide();
        }

        private void Arco_Load(object sender, EventArgs e)
        {
            txtPeso.Focus();
        }

        private void Arco_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void Arco_Shown(object sender, EventArgs e)
        {
            txtPeso.Clear();
            txtPeso.Focus();
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}

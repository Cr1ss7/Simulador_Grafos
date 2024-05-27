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
    public partial class Vertice : Form
    {

        // Variable de control para determinar si se acepta o cancela la operación
        public bool control;

        // Valor ingresado como dato del vértice
        public string dato;

        // Constructor de la clase
        public Vertice()
        {
            InitializeComponent();
            control = false; // Se inicializa la variable de control como false
            dato = ""; // Se inicializa el dato del vértice como una cadena vacía
        }

        // Método para manejar el evento del botón de aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string valor = txtVertice.Text.Trim(); // Se obtiene el valor ingresado en el cuadro de texto
            if ((valor == "") || (valor == " ")) // Se verifica si el valor está vacío o contiene solo espacios
            {
                MessageBox.Show("Debes ingresar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Se muestra un mensaje de error si el valor está vacío
            }
            else
            {
                control = true; // Se establece la variable de control como true
                Hide(); // Se oculta el formulario
            }
        }

        // Método para manejar el evento del botón de cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            control = false; // Se establece la variable de control como false
            Hide(); // Se oculta el formulario
        }

        // Método que se ejecuta al cargar el formulario
        private void Vertice_Load(object sender, EventArgs e)
        {
            txtVertice.Focus(); // Se establece el foco en el cuadro de texto
        }

        // Método que se ejecuta al cerrar el formulario
        private void Vertice_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide(); // Se oculta el formulario
            e.Cancel = true; // Se cancela el cierre del formulario
        }

        // Método que se ejecuta al mostrar el formulario
        private void Vertice_Shown(object sender, EventArgs e)
        {
            txtVertice.Clear(); // Se limpia el cuadro de texto
            txtVertice.Focus(); // Se establece el foco en el cuadro de texto
        }

        // Método que se ejecuta al presionar una tecla en el cuadro de texto
        private void txtVertice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Se verifica si la tecla presionada es Enter
            {
                btnAceptar_Click(null, null); // Se simula el clic en el botón de aceptar
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Threading;
using System.Xml;

namespace Guia10_EJE1
{
    public partial class Simulador : Form
    {
        private CGrafo grafo; // Instancia del grafo
        private CVertice nuevoNodo; // Nuevo nodo a crear
        private CVertice NodoOrigen; // Nodo origen para crear arco
        private CVertice NodoDestino; // Nodo destino para crear arco
        private int var_control = 0; // Variable de control para determinar la acción del mouse

        private Vertice ventanaVertice; // Instancia del formulario para ingresar vértices
        private Arco ventanaArco;
        List<CVertice> nodosRuta;
        List<CVertice> nodosOrdenados;
        bool buscarRuta = false, nuevoVertice = false, nuevoArco = false;
        private int numeronodos = 0;
        bool profundidad = false, anchura = false, nodoEncontrado = false;
        Queue cola = new Queue();
        private string destino = "", origen = "";
        private int distancia = 0;

        //Constructor
        public Simulador()
        {
            InitializeComponent();
            grafo = new CGrafo(); //inicialización del grafo
            nuevoNodo = null;
            var_control = 0;
            ventanaVertice = new Vertice();
            ventanaArco = new Arco();
            nodosRuta = new List<CVertice>();
            nodosOrdenados = new List<CVertice>();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

        }

        // Método que se ejecuta al pintar la pizarra 
        private void Pizarra_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                grafo.DibujarGrafo(e.Graphics);
                if (nuevoVertice)
                {
                    CBVertice.Items.Clear();
                    CBVertice.SelectedIndex = -1;
                    CBNodo1.Items.Clear();
                    CBNodo1.SelectedIndex = -1;
                    CBNodo2.Items.Clear();
                    CBNodo2.SelectedIndex = -1;
                    CBNodoPartida.Items.Clear();
                    CBNodoPartida.SelectedIndex = -1;
                    foreach (CVertice vertice in grafo.nodos)
                    {
                        CBVertice.Items.Add(vertice.Valor);
                        CBNodo1.Items.Add(vertice.Valor);
                        CBNodo2.Items.Add(vertice.Valor);
                        CBNodoPartida.Items.Add(vertice.Valor);
                    }
                    nuevoVertice = false;
                }

                if (nuevoArco)
                {
                    CBArco.Items.Clear();
                    CBArco.SelectedIndex = -1;
                    foreach (CVertice nodo in grafo.nodos)
                    {
                        foreach (CArco arco in nodo.ListaAdyacencia)
                            CBArco.Items.Add("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso: " + arco.peso);
                    }
                    nuevoArco = false;
                }

                if (buscarRuta)
                {
                    foreach (CVertice nodo in nodosRuta)
                    {
                        nodo.colorear(e.Graphics);
                        Thread.Sleep(1000);
                        nodo.DibujarVertice(e.Graphics);
                    }
                    buscarRuta = false;
                }
                if (profundidad)
                {
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitado)
                            recorridoProfundidad(nodo, e.Graphics);
                    }
                    profundidad = false;
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;
                }
                if (anchura)
                {
                    distancia = 0;
                    cola = new Queue();
                    ordenarNodos();
                    foreach (CVertice nodo in nodosOrdenados)
                    {
                        if (!nodo.Visitado && !nodoEncontrado)
                            recorridoAnchura(nodo, e.Graphics, destino);
                    }
                    anchura = false;
                    nodoEncontrado = false;
                    foreach (CVertice nodo in grafo.nodos)
                        nodo.Visitado = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ordenarNodos()
        {
            nodosOrdenados = new List<CVertice>();
            bool est = false;
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    nodosOrdenados.Add(nodo);
                    est = true;
                }
                else
                {
                    nodosOrdenados.Add(nodo);
                }
            }
            foreach (CVertice nodo in grafo.nodos)
            {
                if (nodo.Valor == origen)
                {
                    est = false;
                    break;
                }
                else if (est)
                    nodosOrdenados.Add(nodo);
            }
        }

        // Método que se ejecuta cuando el mouse sale de la pizarra
        private void Pizarra_MouseLeave(object sender, EventArgs e)
        {
            Pizarra.Refresh(); // Se refresca la pizarra para limpiarla
        }

        // Método que se ejecuta al abrir el menú contextual para crear un vértice
        private void CMSCrearVertice_Opening(object sender, CancelEventArgs e)
        {
            
        }

        // Método que se ejecuta al hacer clic en la opción de crear vértice en el menú contextual
        private void CMSCrearVertice_Click(object sender, EventArgs e)
        {
            nuevoNodo = new CVertice(); // Se crea un nuevo vértice
            var_control = 2; // Se establece la variable de control para crear vértices
        }

        // Método que se ejecuta al soltar el botón del mouse en la pizarra
        private void Pizarra_MouseUp(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 1:
                    if ((NodoDestino = grafo.DetectarPunto(e.Location)) != null && NodoOrigen != NodoDestino)
                    {
                        ventanaArco.Visible = false;
                        ventanaArco.control = false;
                        ventanaArco.ShowDialog();
                        if (ventanaArco.control)
                        {
                            if (grafo.AgregarArco(NodoOrigen, NodoDestino))
                            {
                                int distancia = ventanaArco.dato;
                                NodoOrigen.ListaAdyacencia.Find(v => v.nDestino == NodoDestino).peso = distancia;
                            }
                            nuevoArco = true;
                        }
                    }
                    var_control = 0;
                    NodoOrigen = null;
                    NodoDestino = null;
                    Pizarra.Refresh();
                    break;
            }

        }

        // Método que se ejecuta al mover el mouse sobre la pizarra
        private void Pizarra_MouseMove(object sender, MouseEventArgs e)
        {
            switch (var_control)
            {
                case 2:
                    if (nuevoNodo != null)
                    {
                        int posX = e.Location.X;
                        int posY = e.Location.Y;

                        // Se ajusta la posición del nodo para que no salga de los límites de la pizarra
                        if (posX < nuevoNodo.Dimensiones.Width / 2)
                            posX = nuevoNodo.Dimensiones.Width / 2;
                        else if (posX > Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2)
                            posX = Pizarra.Size.Width - nuevoNodo.Dimensiones.Width / 2;

                        if (posY < nuevoNodo.Dimensiones.Height / 2)
                            posY = nuevoNodo.Dimensiones.Height / 2;
                        else if (posY > Pizarra.Size.Height - nuevoNodo.Dimensiones.Height / 2)
                            posY = Pizarra.Size.Height - nuevoNodo.Dimensiones.Height / 2;

                        nuevoNodo.Posicion = new Point(posX, posY);
                        Pizarra.Refresh();
                        nuevoNodo.DibujarVertice(Pizarra.CreateGraphics());
                    }
                    break;
                case 1:
                    AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                    bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;

                    Pizarra.Refresh();
                    Pizarra.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2)
                    {
                        CustomEndCap = bigArrow
                    },
                    NodoOrigen.Posicion,e.Location
                    );
                    break;
            }
        }

        // Método que se ejecuta al presionar un botón del mouse en la pizarra
        private void Pizarra_MouseDown(object sender, MouseEventArgs e)
        {


            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                {
                    var_control = 1;//establecer la variable de control para dibujar arco
                }
                if (nuevoNodo != null && NodoOrigen == null)
                {
                    //mostrar ventana para ingresar el nombre del nuevo nodo
                    ventanaVertice.Visible = false;
                    ventanaVertice.control = false;
                    //grafo.AgregarVertice(nuevoNodo);
                    ventanaVertice.ShowDialog();

                    if (ventanaVertice.control)
                    {
                        //si se ingresa un nombre valido se asigna al nuevo nodo
                        if (grafo.BuscarVertice(ventanaVertice.txtVertice.Text) == null)
                        {
                            grafo.AgregarVertice(nuevoNodo);
                            nuevoNodo.Valor = ventanaVertice.txtVertice.Text;
                        }
                        else
                        {
                            MessageBox.Show("el nodo " + ventanaVertice.txtVertice.Text + " ya existe en el grafo", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    nuevoNodo = null;
                    nuevoVertice = true;
                    var_control = 0;
                    Pizarra.Refresh();
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (var_control == 0)
                {
                    //si se presiona el boton derecho y no se esta realizando ninguna acción, se muestra el menu contextual para crear un nuevo vértice

                    if ((NodoOrigen = grafo.DetectarPunto(e.Location)) != null)
                    {
                        CMSCrearVertice.Text = "nodo " + NodoOrigen.Valor;
                    }
                    else
                    {
                        Pizarra.ContextMenuStrip = this.CMSCrearVertice;
                    }
                }
            }
        }

        private void recorridoAnchura(CVertice vertice, Graphics g, string destino)
        {
            vertice.Visitado = true;
            cola.Enqueue(vertice);
            vertice.colorear(g);
            Thread.Sleep(1000);
            vertice.DibujarVertice(g);
            lblRecorrido.Text += vertice.Valor+" - ";
            if (vertice.Valor == destino)
            {
                nodoEncontrado = true;
                return;
            }

            while (cola.Count > 0)
            {
                CVertice aux = (CVertice)cola.Dequeue();
                foreach (CArco adya in aux.ListaAdyacencia)
                {
                    if (!adya.nDestino.Visitado)
                    {
                        if (!nodoEncontrado)
                        {
                            adya.nDestino.Visitado = true;
                            adya.nDestino.colorear(g);
                            Thread.Sleep(1000);
                            adya.nDestino.DibujarVertice(g);
                            if (destino != "")
                                distancia += adya.peso;
                            cola.Enqueue(adya.nDestino);
                            if (adya.nDestino.Valor == destino)
                            {
                                nodoEncontrado = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void btnEliminarVer_Click(object sender, EventArgs e)
        {
            if (CBVertice.SelectedIndex > 1)
            {
                foreach(CVertice nodo in grafo.nodos)
                {
                    if (nodo.Valor == CBVertice.SelectedItem.ToString())
                    {
                        grafo.nodos.Remove(nodo);

                        nodo.ListaAdyacencia = new List<CArco>();
                        break;
                    }
                }

                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco arco in nodo.ListaAdyacencia)
                    {
                        if (arco.nDestino.Valor == CBVertice.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }
                nuevoArco = true;
                nuevoVertice = true;
                CBVertice.SelectedIndex = -1;
                Pizarra.Refresh();
            }
            else
            {
                txtBuscar.Text = "Seleccione un nodo";
                txtBuscar.ForeColor = Color.Red;
            }
        }

        private void btnEliminarArc_Click(object sender, EventArgs e)
        {
            if (CBArco.SelectedIndex > -1)
            {
                foreach (CVertice nodo in grafo.nodos)
                {
                    foreach (CArco arco in nodo.ListaAdyacencia)
                    {
                        if ("(" + nodo.Valor + "," + arco.nDestino.Valor + ") peso: " + arco.peso == CBArco.SelectedItem.ToString())
                        {
                            nodo.ListaAdyacencia.Remove(arco);
                            break;
                        }
                    }
                }
                nuevoVertice = true;
                nuevoArco=true;
                CBVertice.SelectedIndex = -1;
                Pizarra.Refresh();
            }
            else
            {
                txtBuscar.Text = "Seleccione un arco";
                txtBuscar .ForeColor = Color.Red;
            }
        }

        private void btnProf_Click(object sender, EventArgs e)
        {
            if (CBNodoPartida.SelectedIndex > -1)
            {
                profundidad = true;
                origen = CBNodoPartida.SelectedItem.ToString();
                Pizarra.Refresh();
                CBNodoPartida.SelectedIndex = -1;
            }
            else
            {
                txtBuscar.Text = "Seleccione un nodo de partida";
                txtBuscar.ForeColor = Color.Red;

            }
        }

        private void btnAnch_Click(object sender, EventArgs e)
        {
            if (CBNodoPartida.SelectedIndex > -1)
            {
                anchura = true;
                origen = CBNodoPartida.SelectedItem.ToString(); 
                Pizarra.Refresh();
                CBNodoPartida .SelectedIndex = -1;
            }
            else
            {
                txtBuscar.Text = "Seleccione un nodo de partida ";
                txtBuscar.ForeColor= Color.Red;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() != "")
            {
                if (grafo.BuscarVertice(txtBuscar.Text) != null)
                {
                    lblRespuesta.Text = "Si se encuentra el vértice " + txtBuscar.Text;
                    lblRespuesta.ForeColor = Color.Red;
                }
                else
                {
                    lblRespuesta.Text = "No se encuentra el vértice " + txtBuscar.Text;
                    lblRespuesta.ForeColor = Color.Red;
                }
            }
        }

        //Funcion boton distancia
        private void btnDistancia_Click(object sender, EventArgs e)
        {
            if (CBNodo1.SelectedIndex > -1 && CBNodo2.SelectedIndex > -1)
            {
                distancia = 0;
                foreach (CVertice nodo1 in grafo.nodos)
                {
                    if (nodo1.Valor == CBNodo1.SelectedItem.ToString())
                    {
                        foreach (CVertice nodo2 in grafo.nodos)
                        {
                            if (nodo2.Valor == CBNodo2.SelectedItem.ToString())
                            {
                                calcularPeso(nodo1, nodo2);
                                break;
                            }
                        }
                        break;
                    }
                }
                MessageBox.Show("El peso de el recorrido es de: " + distancia.ToString(), "Recorrido de arbol");
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar nodo de inicio y fin", "Recorrido Arbol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void recorridoProfundidad(CVertice vertice, Graphics g)
        {
            vertice.Visitado = true;
            vertice.colorear(g);
            Thread.Sleep (1000);
            vertice.DibujarVertice (g);
            lblRecorrido.Text += vertice.Valor+" - ";
            foreach (CArco adya in vertice.ListaAdyacencia)
            {
                if(!adya.nDestino.Visitado) recorridoProfundidad(adya.nDestino, g);
            }
        }

        private int totalNodos;
        int[] parents;
        bool[] visitados;

        private void calcularMatricesIniciales()
        {
            nodosRuta = new List<CVertice>();
            totalNodos = grafo.nodos.Count;
            parents = new int[totalNodos];
            visitados = new bool[totalNodos];

            for (int i = 0; i < totalNodos;  i++)
            {
               List<int> filaDistancia = new List<int>();
               for (int j = 0; j < totalNodos; j++) 
               {
                    if (i == j)
                    {
                        filaDistancia.Add(0);
                    }
                    else
                    {
                        int distancia = -1;
                        for (int k = 0; k < grafo.nodos[i].ListaAdyacencia.Count; k++)
                        {
                            if (grafo.nodos[i].ListaAdyacencia[k].nDestino == grafo.nodos[j])
                                distancia = grafo.nodos[i].ListaAdyacencia[k].peso;
                        }
                        filaDistancia.Add(distancia);
                    }
               }
            }
        }

        private void calcularPeso(CVertice vertice1, CVertice vertice2)
        {
            foreach (CArco adya in vertice1.ListaAdyacencia)
            {
                if (adya.nDestino != vertice2)
                {
                    distancia += adya.peso;
                    calcularPeso(adya.nDestino,vertice2);
                }
                else if (adya.nDestino == vertice2)
                {
                    distancia += adya.peso;
                    break;
                }
            }
        }
    }
}

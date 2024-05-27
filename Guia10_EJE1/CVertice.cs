using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia10_EJE1
{
    class CVertice
    {
        public int distancianodo;
        public bool Visitado;
        public CVertice Padre;
        public bool pesoasignado;

        // Valor del vértice
        public string Valor;

        // Lista de arcos adyacentes al vértice
        public List<CArco> ListaAdyacencia;

        Dictionary<string, short> _banderas;
        Dictionary<string, short> _banderas_predeterminada;

        static int size = 35;

        Size dimensiones;
        Color color_nodo;
        Color color_fuente;
        Point _posicion;
        int radio;

        public Color Color
        {
            get { return color_nodo; }
            set { color_nodo = value; }
        }

        public Color FontColor
        {
            get { return color_fuente; }
            set { color_fuente = value; }
        }

        public Point Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }

        public Size Dimensiones
        {
            get { return dimensiones; }
            set
            {
                // El radio se calcula como la mitad del ancho del vértice
                radio = value.Width / 2;
                dimensiones = value;
            }
        }

        public CVertice(String valor)
        {
            Valor = valor;
            ListaAdyacencia = new List<CArco>();
            _banderas = new Dictionary<string, short>();
            _banderas_predeterminada = new Dictionary<string, short>();
            dimensiones = new Size(size, size);
            Color = Color.FromArgb(51,204,255);
            Dimensiones = new Size(size, size);
            FontColor = Color.Black;
            Visitado = false;
        }

        public CVertice() : this("") { }

        public void DibujarVertice(Graphics g)
        {
            SolidBrush b = new SolidBrush(color_nodo);
            Rectangle areaNodo = new Rectangle(_posicion.X - radio, _posicion.Y - radio,
                dimensiones.Width, dimensiones.Height);
            g.FillEllipse(b, areaNodo);
            g.DrawString(Valor, new Font("Times New Roman", 14), new SolidBrush(color_fuente),
                _posicion.X, _posicion.Y,
                new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                });

            g.DrawEllipse(new Pen(Color.Black, (float)1.0), areaNodo);
            b.Dispose();
        }

        public void DibujarArcos(Graphics g)
        {
            float distancia;
            int difY, difX;
            foreach (CArco arco in ListaAdyacencia)
            {
                difX = Posicion.X - arco.nDestino.Posicion.X;
                difY = Posicion.Y - arco.nDestino.Posicion.Y;

                distancia = (float)Math.Sqrt((difX * difX) + (difY * difY));

                AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4, true);
                bigArrow.BaseCap = System.Drawing.Drawing2D.LineCap.Triangle;

                // Dibujar el arco con flecha desde el vértice actual al destino
                g.DrawLine(new Pen(new SolidBrush(arco.color), arco.grosor_flecha)
                { CustomEndCap = bigArrow, Alignment = PenAlignment.Center },
                _posicion,
                new Point(arco.nDestino.Posicion.X + (int)(radio * difX / distancia),
                         arco.nDestino.Posicion.Y + (int)(radio * difY / distancia))
                );

                // Dibujar el peso del arco cerca del vértice actual
                g.DrawString(
                    arco.peso.ToString(),
                    new Font("Times New Roman", 12),
                    new SolidBrush(Color.White),
                    this._posicion.X - (int)((difX / 3)),
                    this._posicion.Y - (int)((difY / 3)),
                    new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far,
                    }

                );
            }
        }

        public bool DetectarPunto(Point p)
        {
            GraphicsPath posicion = new GraphicsPath();
            posicion.AddEllipse(new Rectangle(_posicion.X - dimensiones.Width / 2,
                                                _posicion.Y - dimensiones.Height / 2,
                                                dimensiones.Width, dimensiones.Height));

            bool retval = posicion.IsVisible(p);
            posicion.Dispose();
            return retval;
        }

        public string ToString()
        {
            return Valor;
        }

        public void colorear(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.YellowGreen);

            Rectangle areaNodo = new Rectangle(_posicion.X -  radio, _posicion.Y - radio, 
                dimensiones.Width, dimensiones.Height);

            g.FillEllipse(b, areaNodo);
            g.DrawString(Valor, new Font("Times New Roman",14), new SolidBrush(color_fuente),
                _posicion.X,_posicion.Y,
                new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                });
            g.DrawEllipse(new Pen (Color.Black,(float)1.0), areaNodo);
            b.Dispose();
        }
    }
}

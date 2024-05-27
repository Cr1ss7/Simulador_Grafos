using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia10_EJE1
{
    class CArco
    {
        // Vértice destino del arco
        public CVertice nDestino;

        // Peso del arco
        public int peso;

        // Grosor de la flecha que representa el arco
        public float grosor_flecha;

        // Color del arco
        public Color color;

        // Constructor que inicializa un arco con un vértice destino y un peso
        public CArco(CVertice destino, int peso)
        {
            nDestino = destino;
            this.peso = peso;
            grosor_flecha = 2;
            color = Color.Red;
        }

        // Constructor sobrecargado que inicializa un arco con un vértice destino y peso predeterminado
        public CArco(CVertice destino) : this(destino, 1)
        {
            nDestino = destino;
        }
    }
}

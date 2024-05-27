using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia10_EJE1
{
    class CLista
    {
        // Constructor por defecto que inicializa la lista vacía
        public CLista()
        {
            aElemento = null;
            aSubLista = null;
            aPeso = 0;
        }

        // Elemento de la lista
        private CVertice aElemento;

        // Sublista asociada al elemento
        private CLista aSubLista;

        // Peso asociado al elemento
        private int aPeso;

        // Constructor que inicializa la lista con una lista dada
        public CLista(CLista pLista)
        {
            if (pLista != null)
            {
                aElemento = pLista.aElemento;
                aSubLista = pLista.aSubLista;
                aPeso = pLista.aPeso;
            }
        }

        // Constructor que inicializa la lista con un elemento, una sublista y un peso
        public CLista(CVertice pElemento, CLista pSubLista, int pPeso)
        {
            aElemento = pElemento;
            aSubLista = pSubLista;
            aPeso = pPeso;
        }

        // Propiedad para obtener o establecer el elemento de la lista
        public CVertice Elemento
        {
            get { return aElemento; }
            set { aElemento = value; }
        }

        // Propiedad para obtener o establecer la sublista asociada al elemento
        public CLista SubLista
        {
            get { return aSubLista; }
            set { aSubLista = value; }
        }

        // Propiedad para obtener o establecer el peso asociado al elemento
        public int Peso
        {
            get { return aPeso; }
            set { aPeso = value; }
        }

        // Método para verificar si la lista está vacía
        public bool EsVacia()
        {
            return aElemento == null;
        }

        // Método para agregar un elemento a la lista
        public void Agregar(CVertice pElemento, int pPeso)
        {
            if (pElemento != null)
            {
                if (aElemento == null)
                {
                    aElemento = new CVertice(pElemento.Valor);
                    aPeso = pPeso;
                    aSubLista = new CLista();
                }
                else
                {
                    if (!ExisteElemento(pElemento))
                    {
                        aSubLista.Agregar(pElemento, pPeso);
                    }
                }
            }
        }

        // Método para eliminar un elemento de la lista
        public void Eliminar(CVertice pElemento)
        {
            if (aElemento != null)
            {
                if (aElemento.Equals(pElemento))
                {
                    aElemento = aSubLista.aElemento;
                    aSubLista = aSubLista.aSubLista;
                }
            }
        }

        // Método para obtener el número de elementos en la lista
        public int NroElementos()
        {
            return (aElemento != null) ? (1 + aSubLista.NroElementos()) : 0;
        }

        // Método para obtener el elemento en la posición indicada
        public object IesimoElemento(int posicion)
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
            {
                if (posicion == 1)
                    return aElemento;
                else
                    return aSubLista.IesimoElemento(posicion - 1);
            }
            else
                return null;
        }

        // Método para obtener el peso del elemento en la posición indicada
        public object IesimoElementoPeso(int posicion)
        {
            if ((posicion > 0) && (posicion <= NroElementos()))
            {
                if (posicion == 1)
                    return aPeso;
                else
                    return aSubLista.IesimoElementoPeso(posicion - 1);

            }
            else
                return 0;
        }

        // Método para verificar si un elemento existe en la lista
        public bool ExisteElemento(CVertice pElemento)
        {
            if ((aElemento != null) && (pElemento != null))
            {
                return aElemento.Equals(pElemento) || aSubLista.ExisteElemento(pElemento);
            }
            else
                return false;
        }

        // Método para obtener la posición de un elemento en la lista
        public int PosicionElemento(CVertice pElemento)
        {
            if ((aElemento != null) || (ExisteElemento(pElemento)))
            {
                if (aElemento.Equals(pElemento))
                {
                    return 1;
                }
                else
                {
                    return 1 + aSubLista.PosicionElemento(pElemento);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}

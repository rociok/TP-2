/*
 * Created by SharpDevelop.
 * User: nahue
 * Date: 24/8/2023
 * Time: 09:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP2
{
    /// <summary>
    /// Description of Heap.
    /// </summary>
    public class Heap
    {
        private int[] datos;
        private int tamano;
        private int capacidad;
        private bool maxHeap;
        private bool minHeap;

        public Heap(int capacidad, bool maxHeap)
        {
            this.capacidad = capacidad;
            datos = new int[capacidad + 1];
            tamano = 0;
            this.maxHeap = maxHeap;
            this.minHeap = !maxHeap;
        }


        public Heap(int capacidad, int[] datos, bool maxHeap)
        {
            this.capacidad = capacidad;
            this.datos = new int[capacidad + 1];
            tamano = 0;
            this.maxHeap = maxHeap;
            this.minHeap = !maxHeap;
            BuildHeap(datos, maxHeap);
        }


        private int padreIndice(int i)
        {
            return i / 2;
        }

        private int hijoIzquierdoIndice(int i)
        {
            return 2 * i;
        }

        private int hijoDerechoIndice(int i)
        {
            return 2 * i + 1;
        }


        private bool tienePadre(int i)
        {
            return padreIndice(i) > 0;
        }

        private bool tieneHijoIzquierdo(int i)
        {
            return hijoIzquierdoIndice(i) <= tamano;
        }

        private bool tieneHijoDerecho(int i)
        {
            return hijoDerechoIndice(i) <= tamano;
        }


        private int getPadre(int i)
        {
            return datos[padreIndice(i)];
        }

        private int getHijoIzquierdo(int i)
        {
            return datos[hijoIzquierdoIndice(i)];
        }

        private int getHijoDerecho(int i)
        {
            return datos[hijoDerechoIndice(i)];
        }


        public int[] getDatos()
        {
            // Copia los datos de la estructura en un nuevo array y lo devuelve
            int inicioIndice = 1;
            int longitud = this.tamano;
            int[] subDatos = new int[longitud];

            Array.Copy(datos, inicioIndice, subDatos, 0, longitud);

            return subDatos;
        }

        public bool estaLlena()
        {
            // Comprueba si la estructura está llena (se ha alcanzado la capacidad)
            return tamano >= capacidad;
        }

        public bool estaVacia()
        {
            // Comprueba si la estructura está vacía (no tiene elementos)
            return tamano == 0;
        }

        public int tope()
        {
            // Devuelve el ult elemento de la estructura (el valor mínimo o máximo, según el tipo de montículo)
            if (estaVacia())
                throw new InvalidOperationException("La Heap está vacía");

            return datos[1];
        }

        public bool agregar(int elem)
        {
            // Agrega un elemento a la estructura de datos (se coloca en la posición correcta) y realiza un filtrado hacia arriba
            if (estaLlena())
                return false; // No se pudo agregar porque la estructura está llena

            datos[tamano + 1] = elem;
            tamano++;

            if (maxHeap)
                filtradoArribaMax();   // Si es una MaxHeap, ajusta para que el valor máximo esté en la cima
            else
                filtradoArribaMin();   // Si es una MinHeap, ajusta para que el valor mínimo esté en la cima

            return true; // Elemento agregado exitosamente
        }

        public int eliminar()
        {
            // Elimina y devuelve el elemento en la cima de la estructura de montículo (el valor mínimo o máximo, según el tipo de montículo)
            if (estaVacia())
                throw new InvalidOperationException("La Heap está vacía");

            int raíz = datos[1];
            datos[1] = datos[tamano];
            tamano--;

            if (maxHeap)
                filtradoAbajoMax(1);  // Si es una MaxHeap, ajusta para que el valor máximo esté en la cima
            else
                filtradoAbajoMin(1);  // Si es una MinHeap, ajusta para que el valor mínimo esté en la cima

            return raíz;
        }

        private void filtradoArribaMin()
        {
            // Ajusta la estructura de montículo hacia arriba para mantener la propiedad de MinHeap
            int i = tamano;
            while (tienePadre(i) && getPadre(i) > datos[i])
            {
                int padreIndiceAux = padreIndice(i);
                swap(padreIndiceAux, i);
                i = padreIndiceAux;
            }
        }

        private void filtradoArribaMax()
        {
            // Ajusta la estructura de montículo hacia arriba para mantener la propiedad de MaxHeap
            int i = tamano;
            while (tienePadre(i) && getPadre(i) < datos[i])
            {
                int padreIndiceAux = padreIndice(i);
                swap(padreIndiceAux, i);
                i = padreIndiceAux;
            }
        }

        private void filtradoArribaMin(int i)
        {
            // Versión recursiva para ajustar la estructura de montículo hacia arriba en una MinHeap
            if (!tienePadre(i))
                return;

            int padreIndiceAux = padreIndice(i);
            if (getPadre(i) > datos[i])
            {
                swap(padreIndiceAux, i);
                filtradoArribaMin(padreIndiceAux);
            }
        }

        private void filtradoAbajoMin()
        {
            // Ajusta la estructura de montículo hacia abajo para mantener la propiedad de MinHeap
            int i = 1;
            while (tieneHijoIzquierdo(i))
            {
                int hijoMenorIndice = hijoIzquierdoIndice(i);
                if (tieneHijoDerecho(i) && getHijoDerecho(i) < getHijoIzquierdo(i))
                    hijoMenorIndice = hijoDerechoIndice(i);

                if (datos[i] < datos[hijoMenorIndice])
                    break;

                swap(i, hijoMenorIndice);
                i = hijoMenorIndice;
            }
        }

        private void filtradoAbajoMin(int i)
        {
            // Versión recursiva para ajustar la estructura de montículo hacia abajo en una MinHeap
            int datoMenorIndice = i;

            if (tieneHijoIzquierdo(i) && getHijoIzquierdo(i) < datos[datoMenorIndice])
                datoMenorIndice = hijoIzquierdoIndice(i);

            if (tieneHijoDerecho(i) && getHijoDerecho(i) < datos[datoMenorIndice])
                datoMenorIndice = hijoDerechoIndice(i);

            if (datoMenorIndice != i)
            {
                swap(i, datoMenorIndice);
                filtradoAbajoMin(datoMenorIndice);
            }
        }

        private void filtradoAbajoMax(int i)
        {
            // Ajusta la estructura de montículo hacia abajo para mantener la propiedad de MaxHeap
            int datoMayorIndice = i;

            if (tieneHijoIzquierdo(i) && getHijoIzquierdo(i) > datos[datoMayorIndice])
                datoMayorIndice = hijoIzquierdoIndice(i);

            if (tieneHijoDerecho(i) && getHijoDerecho(i) > datos[datoMayorIndice])
                datoMayorIndice = hijoDerechoIndice(i);

            if (datoMayorIndice != i)
            {
                swap(i, datoMayorIndice);
                filtradoAbajoMax(datoMayorIndice);
            }
        }

        private void swap(int a, int b)
        {
            // Intercambia dos elementos en la estructura de montículo
            int temp = datos[a];
            datos[a] = datos[b];
            datos[b] = temp;
        }

        private void BuildHeap(int[] a, bool maxHeap)
        {
            // Construye una estructura de montículo a partir de un array dado
            if (a.Length > capacidad)
                throw new ArgumentException("El tamaño del array excede la capacidad de la heap");

            // Copia los elementos del array en los datos de la estructura de montículo
            Array.Copy(a, 0, datos, 1, a.Length);
            this.tamano = a.Length;

            if (maxHeap)
            {
                for (int i = padreIndice(this.tamano); i >= 1; i--)
                {
                    filtradoAbajoMax(i); // Ajusta la estructura de montículo



                }
            }
        }
    }
}
/*
 * Created by SharpDevelop.
 * User: nahue
 * Date: 24/8/2023
 * Time: 09:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace TP2
{
	/// <summary>
	/// Description of Heap.
	/// </summary>
	public class HeapString
	{
		private List<string> datos;
		private int tamano;
		private int capacidad;
		private bool maxHeap;
		private bool minHeap;
		
		public HeapString(int capacidad, bool maxHeap)
		{
			this.capacidad = capacidad;
			datos = new List<string>(capacidad + 1);
            tamano = 0;
			this.maxHeap = maxHeap;
			this.minHeap = !maxHeap;
		}


        public HeapString(int capacidad, List<string> datos, bool maxHeap)
        {
            this.capacidad = capacidad;
            this.datos = new List<string>(capacidad + 1);
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

        private string getPadre(int i)
        {
            return datos[padreIndice(i)];
        }

        private string getHijoIzquierdo(int i)
        {
            return datos[hijoIzquierdoIndice(i)];
        }

        private string getHijoDerecho(int i)
        {
            return datos[hijoDerechoIndice(i)];
        }

        public List<string> getDatos()
        {
            List<string> subDatos = new List<string>(tamano);

            for (int i = 1; i <= tamano; i++)
            {
                subDatos.Add(datos[i]);
            }

            return subDatos;
        }

        public bool estaLlena()
        {
            return tamano >= capacidad;
        }

        public bool estaVacia()
        {
            return tamano == 0;
        }

        public string tope()
        {
            if (estaVacia())
                throw new InvalidOperationException("La Heap está vacía");

            return datos[1];
        }


        public bool agregar(string elem)
        {
            if (estaLlena())
                return false;

            datos.Add(elem);
            tamano++;

            if (maxHeap)
                filtradoArribaMax();   // Si es una MaxHeap
            else
                filtradoArribaMin();   // Si es una MinHeap

            return true;
        }


        public string eliminar()
        {
            if (estaVacia())
                throw new InvalidOperationException("La Heap está vacía");

            string raiz = datos[1];
            string ultimoElemento = datos[tamano];
            datos.RemoveAt(tamano);
            tamano--;

            if (tamano > 0)
            {
                datos[1] = ultimoElemento;
                if (maxHeap)
                    filtradoAbajoMax(1);
                else
                    filtradoAbajoMin(1);
            }

            return raiz;
        }


        // Forma iterativa
        private void filtradoArribaMin()
        {
            int i = tamano;
            while (tienePadre(i) && String.Compare(getPadre(i), datos[i]) > 1)
            {
                int padreIndiceAux = padreIndice(i);
                swap(padreIndiceAux, i);
                i = padreIndiceAux;
            }
        }
        private void filtradoArribaMax()
        {
            int i = tamano;
            while (tienePadre(i) && String.Compare(getPadre(i), datos[i]) < 0)
            {
                int padreIndiceAux = padreIndice(i);
                swap(padreIndiceAux, i);
                i = padreIndiceAux;
            }
        }

        // Forma Recursiva
        private void filtradoArribaMin(int i)
        {
            if (!tienePadre(i))
                return;

            int padreIndiceAux = padreIndice(i);
            if (String.Compare(getPadre(i), datos[i]) > 0)
            {
                swap(padreIndiceAux, i);
                filtradoArribaMin(padreIndiceAux);
            }
        }

        // Forma iterativa
        private void filtradoAbajoMin(int i)
        {
            while (tieneHijoIzquierdo(i))
            {
                int hijoMenorIndice = hijoIzquierdoIndice(i);
                if (tieneHijoDerecho(i) && String.Compare(getHijoDerecho(i), getHijoIzquierdo(i)) < 0)
                    hijoMenorIndice = hijoDerechoIndice(i);

                if (String.Compare(datos[i], datos[hijoMenorIndice]) < 0)
                    break;

                swap(i, hijoMenorIndice);
                i = hijoMenorIndice;
            }
        }

        private void filtradoAbajoMax(int i)
        {
            while (tieneHijoIzquierdo(i))
            {
                int hijoMayorIndice = hijoIzquierdoIndice(i);
                if (tieneHijoDerecho(i) && String.Compare(getHijoDerecho(i), getHijoIzquierdo(i)) > 0)
                    hijoMayorIndice = hijoDerechoIndice(i);

                if (String.Compare(datos[i], datos[hijoMayorIndice]) > 0)
                    break;

                swap(i, hijoMayorIndice);
                i = hijoMayorIndice;
            }
        }

        private void swap(int a, int b)
		{
			string temp = datos[a];
			datos[a] = datos[b];
			datos[b] = temp;
		}


		private void BuildHeap(List<string> a, bool maxHeap)
		{
			if (a.Count > capacidad)
				throw new ArgumentException("El tamaño del array excede la capacidad de la heap");

            datos.AddRange(a);
            tamano = a.Count;

            if (maxHeap)
			{
				for (int i = padreIndice(this.tamano); i >= 1; i--)
				{
					filtradoAbajoMax(i);
				}
			}
			else
			{
                for (int i = padreIndice(this.tamano); i >= 1; i--)
                {					
					filtradoAbajoMin(i);
                }
            }
			
		}	


    }
}

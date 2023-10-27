using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2
{
    public class Impresora
    {
        private HeapString colaDeImpresion; // Estructura de datos para administrar la cola de impresión

        public Impresora(int capacidad, bool maxHeap)
        {
            // Constructor que inicializa la impresora con una capacidad y un orden (MaxHeap o MinHeap)
            colaDeImpresion = new HeapString(capacidad, maxHeap);
        }

        public void nuevoDocumento(string documento)
        {
            // Agrega un nuevo documento a la cola de impresión
            colaDeImpresion.agregar(documento);
        }

        public string imprime()
        {
            if (colaDeImpresion.estaVacia())
            {
                // Comprueba si no hay trabajos de impresión en la cola
                return "No hay trabajos de impresión en la cola.";
            }

            // Imprime el próximo documento en la cola
            string doc = colaDeImpresion.eliminar();
            return "Imprimiendo: " + doc;
        }

        public bool EstaVacia()
        {
            // Comprueba si la cola de impresión está vacía
            return colaDeImpresion.estaVacia();
        }
    }

}

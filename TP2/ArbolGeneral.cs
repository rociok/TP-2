using System;
using System.Collections.Generic;
using System.Text;

namespace TP2
{
	public class ArbolGeneral<T>
	{
		
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
		
		
		public void setDatoRaiz(T dato){
			this.dato = dato;
		}
		
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
		
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}
		
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}
		
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
		
	
		public int altura() {
			if(this.esHoja())
				return 0;
			
			//obtenemos altura Max de los hijos
			int alturaMax = 0;
			foreach(var hijo in this.getHijos()) {
				int alturaHijo = hijo.altura();
				if (alturaHijo > alturaMax) {
					alturaMax = alturaHijo;
				}
			}
			return alturaMax + 1;		
		}


        public int Nivel(T dato)
        {
            // Comprobamos si el nodo raíz contiene el valor buscado
            if (getDatoRaiz().Equals(dato))
            {
                return 0; // Si el valor está en el nodo raíz, su nivel es 0.
            }

            // Recorremos los hijos del nodo actual.
            foreach (var hijo in getHijos())
            {
                int nivel = hijo.Nivel(dato);

                // Si encontramos el valor en uno de los hijos, retornamos el nivel + 1.
                if (nivel != -1)
                {
                    return nivel + 1; // Añadimos 1 al nivel del hijo actual.
                }
            }

            // Si no encontramos el valor en ningún hijo ni en el nodo actual, retornamos -1.
            return -1;
        }



        public int Ancho()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>(); // Creamos una cola para el recorrido por niveles.
            ArbolGeneral<T> arbolAux;

            int contNodos = 0; // Cuenta los nodos (árboles) por nivel.
            int ancho = 0; // Lleva la cuenta del ancho del árbol.

            c.encolar(this); // Encolamos el árbol raíz.
            c.encolar(null); // Agregamos un separador nulo para marcar el final del nivel actual.

            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                // Si es un separador (nulo), terminamos de procesar el nivel actual.
                if (arbolAux == null)
                {
                    // Actualizamos el ancho si el contador de nodos en el nivel actual es mayor.
                    if (contNodos > ancho)
                        ancho = contNodos;

                    // Reseteamos el contador de nodos.
                    contNodos = 0;

                    // Encolamos un nuevo separador si la cola no está vacía.
                    if (!c.esVacia())
                        c.encolar(null);
                }
                else
                {
                    // Si es un nodo (árbol), incrementamos el contador y encolamos sus hijos.
                    contNodos++;

                    foreach (var hijo in arbolAux.getHijos())
                        c.encolar(hijo);
                }
            }

            return ancho; // Retornamos el ancho del árbol.
        }


        public void preOrden() {
			//proceso raiz primero
			Console.Write(this.getDatoRaiz() + " ");
			
			//luego procesamos los hijos recursivamente
			foreach(var hijo in this.getHijos())
				hijo.preOrden();			
		}
		
		
		public void postOrden() {			
			
			//proceso primero los hijos recursivamente
			foreach(var hijo in this.getHijos())
				hijo.postOrden();	
			
			//luego proceso la raiz 
			Console.Write(this.getDatoRaiz() + " ");									
		}
		
		
		public void inOrden(){
            // Primero, visitamos recursivamente el primer hijo.
            if (!this.esHoja())
                this.getHijos()[0].inOrden();

            // Luego, visitamos el nodo raíz e imprimimos su valor.
            Console.Write(this.getDatoRaiz() + " ");

            // Por último, visitamos los hijos restantes recursivamente.
            for (int i = 1; i < this.getHijos().Count; i++)
            {
                this.getHijos()[i].inOrden();
            }
            // otra forma
            /*foreach(var hijo in this.getHijos()){
				if(hijo == this.getHijos()[0])
					continue;
				else
					hijo.inOrden();*/
        }


        public void PorNiveles()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>(); // Creamos una cola para el recorrido por niveles.
            ArbolGeneral<T> arboAux;

            c.encolar(this); // Encolamos el árbol raíz.

            while (!c.esVacia())
            {
                arboAux = c.desencolar();

                // Imprimimos el valor del nodo raíz del árbol actual.
                Console.Write(arboAux.getDatoRaiz() + " ");

                // Encolamos los hijos del árbol actual para visitarlos en el siguiente nivel.
                foreach (var hijo in arboAux.getHijos())
                    c.encolar(hijo);
            }
        }



        public void porNivelesSep(){
			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolAux;			
						
			c.encolar(this);
			c.encolar(null);
			
			while(!c.esVacia()){
				arbolAux = c.desencolar();
				
				// si es un separador
				if(arbolAux == null){
					if(!c.esVacia())
						c.encolar(null);
				}
				
				// si es un nodo (arbol)
				else{
					// procesamos
					Console.Write(arbolAux.getDatoRaiz() + " ");
					// encolamos hijos
					foreach(var hijo in arbolAux.getHijos())
						c.encolar(hijo);
				}				
			}			
		}	
		 	 
		
		public string preOrdenString()
		{
		    StringBuilder recorrido = new StringBuilder();
		
		    // Proceso raíz primero
		    recorrido.Append(this.getDatoRaiz().ToString() + " ");
		
		    // Luego procesamos los hijos recursivamente
		    foreach (var hijo in this.getHijos())
		    {
		        recorrido.Append(hijo.preOrdenString()); // Recursión
		    }
		    
		    		    
		    return recorrido.ToString();
		}
		
	
	}
}

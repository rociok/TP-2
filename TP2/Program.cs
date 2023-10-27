/*
 * Created by SharpDevelop.
 * User: nahue
 * Date: 20/8/2023
 * Time: 21:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP2
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			ArbolGeneral<int> arbol = new ArbolGeneral<int>(10);
			ArbolGeneral<int> hijo1 = new ArbolGeneral<int>(20);
			ArbolGeneral<int> hijo2 = new ArbolGeneral<int>(30);
			ArbolGeneral<int> hijo3 = new ArbolGeneral<int>(40);
			
			arbol.agregarHijo(hijo1);
			arbol.agregarHijo(hijo2);
			arbol.agregarHijo(hijo3);
			
			
			for (int i = 0; i < 5; i++){
				hijo1.agregarHijo(new ArbolGeneral<int>(i + 100));
				hijo2.agregarHijo(new ArbolGeneral<int>(i + 200));
				hijo3.agregarHijo(new ArbolGeneral<int>(i + 300));
			}
			
			// test de arbol
			Console.WriteLine("Recorrido preOrden:");
			arbol.preOrden();
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Recorrido preOrdenString:");
			string preOrdenRecorrido = arbol.preOrdenString();
			Console.WriteLine(preOrdenRecorrido);
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Recorrido preOrdenString (sin el 1° elem):");
			int primerEspacio = preOrdenRecorrido.IndexOf(" ");
			Console.WriteLine(preOrdenRecorrido.Remove(0, primerEspacio + 1));
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Recorrido postOrden:");
			arbol.postOrden();
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Recorrido inOrden:");
			arbol.inOrden();
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Recorrido por niveles:");
			arbol.porNiveles();
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Recorrido por niveles con separador:");
			arbol.porNivelesSep();
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Altura del arbol: " + arbol.altura());
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Ancho del arbol: " + arbol.ancho());
			Console.WriteLine();
			Console.WriteLine();

			int num = 20;
            Console.WriteLine("Nivel de {0}: " + arbol.nivel(num), num);
            Console.WriteLine();
            Console.WriteLine();


            // instanciar RedAgua
            ArbolGeneral<float> arbolRA = new ArbolGeneral<float>(10);
			ArbolGeneral<float> hijo1RA = new ArbolGeneral<float>(20);
			ArbolGeneral<float> hijo2RA = new ArbolGeneral<float>(30);
			ArbolGeneral<float> hijo3RA = new ArbolGeneral<float>(40);
			
			arbolRA.agregarHijo(hijo1RA);
			arbolRA.agregarHijo(hijo2RA);
			arbolRA.agregarHijo(hijo3RA);
			
			
			for (int i = 0; i < 5; i++){
				hijo1RA.agregarHijo(new ArbolGeneral<float>(i + 100));
				hijo2RA.agregarHijo(new ArbolGeneral<float>(i + 200));
				hijo3RA.agregarHijo(new ArbolGeneral<float>(i + 300));
			}
			
			RedAgua red = new RedAgua(arbolRA);
			int caudal = 1000;
			Console.WriteLine("Creamos red con caudal de " + caudal + " litros en el caño maestro, su minimo caudal es de " + red.minimoCaudal(caudal) + " litros");
			Console.WriteLine();
			Console.WriteLine();
			
			Console.WriteLine("Recorrido de la red por niveles:");
			arbolRA.porNiveles();
			Console.WriteLine();
			Console.WriteLine();


			// Prueba Heap
			Console.WriteLine("Prueba BuildHeap");
			//Console.Clear();
			//int[] a = { 29, 2, 6, 1, 9, 7, 3, 8, 14, 18 };
			//int[] a = { 8, 4, 9, 10, 1, 2 };
			int[] a = { 2, 5, 6, 9, 7 };
			int capacidad = 2 * a.Length;
			bool maxHeap = true;

			Heap myHeap = new Heap(capacidad, a, maxHeap);

			//Prueba Delete
			//myHeap.eliminar();

			// Prueba Agregar elemento
			//myHeap.agregar(10);
           
			int[] datosHeap = myHeap.getDatos();            

            if (maxHeap)
				Console.Write("MaxHeap: ");
			else
				Console.Write("MinHeap: ");

			foreach (int dato in datosHeap)
				Console.Write(dato + " ");

            Console.WriteLine();
            Console.WriteLine();

			// Prueba HeapString (No funciona)
			/*Console.WriteLine("Prueba HeapString");
			
			Impresora imp = new Impresora(10, false);

			imp.nuevoDocumento("hola mundoooo!");
            imp.nuevoDocumento("hola!");
            imp.nuevoDocumento("hola mundo!");

			Console.WriteLine(imp.imprime());
            Console.WriteLine(imp.imprime());

            imp.nuevoDocumento("holaaaa mundoooo!");

			Console.WriteLine(imp.imprime());
            Console.WriteLine(imp.imprime());
            Console.WriteLine(imp.imprime());*/


            Console.WriteLine();
			Console.WriteLine();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
/*
 * Created by SharpDevelop.
 * User: nahue
 * Date: 11/8/2023
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP2
{
    /// <summary>
    /// Description of RedAgua.
    /// </summary>
    public class RedAgua
    {
        ArbolGeneral<float> red; // Estructura de árbol que representa la red de agua

        public RedAgua(ArbolGeneral<float> arbol)
        {
            // Constructor que inicializa la instancia de RedAgua con un árbol dado
            this.red = arbol;
        }

        public float minimoCaudal(float caudal)
        {
            Cola<ArbolGeneral<float>> c = new Cola<ArbolGeneral<float>>();
            ArbolGeneral<float> arbolAux;
            float _minimoCaudal = caudal;

            // Establece el caudal en el nodo raíz del árbol de red
            red.setDatoRaiz(caudal);

            c.encolar(red);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                // Procesamiento
                if (!arbolAux.esHoja())
                {
                    // Calcula el caudal para los hijos del nodo actual
                    float caudalHijos = arbolAux.getDatoRaiz() / arbolAux.getHijos().Count;

                    if (caudalHijos < _minimoCaudal)
                        _minimoCaudal = caudalHijos;

                    foreach (var hijo in arbolAux.getHijos())
                    {
                        // Establece el mismo caudal en todos los hijos del nodo actual
                        hijo.setDatoRaiz(caudalHijos);
                        c.encolar(hijo);
                    }
                }
            }

            return _minimoCaudal;
        }
    }


}

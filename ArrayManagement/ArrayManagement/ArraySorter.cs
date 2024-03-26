using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Scrivi una funzione in C# che, preso un vettore in input, ritorni l’indice dell’elemento con
//il valore più piccolo compreso nel range (estremi inclusi) indicati da fromIndex e
//toIndex
// Escribir una función en C# que encuentre el índice del elemento más pequeño dentro de un rango especificado en un array.

//la función debe recibir como argumentos un array de enteros (int[]),
//índice de inicio (fromIndex)
//índice de fin (toIndex).
//Luego, debe encontrar el índice del elemento más pequeño dentro del rango especificado por los índices fromIndex y toIndex.

//1. fromIndex ≥ 0
//2.toIndex < n (debe ser menor que la loingitud del array)
//3.fromIndex ≤ toIndex

namespace ArrayManagement
{
    public class ArraySorter
    {
        public static int FindIndexOfMin(int[] array, int fromIndex, int toIndex)
        {

            //uint para no hacer la validacion entiendo..
            int result = -1;
            //Validamos que el array no està vacio
            if (array.Length != 0)
            {
                if (fromIndex >= 0)
                {
                    if (toIndex < array.Length)
                    {
                        if (fromIndex <= toIndex)
                        {
                            //se cumple todo
                            int valorMinimo = array[fromIndex];
                            int posicionValorMinimo = fromIndex;
                            for (int i = fromIndex; i <= toIndex; i++)
                            {
                                int valorActual = array[i];
                                if (valorActual < valorMinimo)
                                {
                                    valorMinimo = valorActual;
                                    posicionValorMinimo = i;
                                }
                            }
                            result = posicionValorMinimo;

                            Console.WriteLine("El valor minimo del array: [" + string.Join(", ", array) + "] es " + valorMinimo);
                            Console.WriteLine("La posiciòn del valor minimo en el array es " + posicionValorMinimo);

                        }
                        else
                        {
                            Console.WriteLine("is not fromIndex ≤ toIndex");
                        }
                    }
                    else
                    {
                        Console.WriteLine("is not toIndex < n");
                    }

                }
                else
                {
                    Console.WriteLine("is not fromIndex ≥ 0");
                }
            }
            else
            {
                ///el array esta vacio
                Console.WriteLine("El array está vacio");
            }
            return result;
        }

        public static void SwapElements(int[] array, int i, int j)
        {
            Console.WriteLine("Array antes de invertir los elementos: [" + string.Join(", ", array) + "]");

            int valorPosicionI = array[i];
            int valorPosicionJ = array[j];

            array[i] = valorPosicionJ;
            array[j] = valorPosicionI;

            Console.WriteLine("Array despues de invertir los elementos: [" + string.Join(", ", array) + "]");

        }

        public static void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int toIndex = array.Length - 1;
                int miIndex = FindIndexOfMin(array, i, toIndex);
                SwapElements(array, i, miIndex);
            }

            Console.WriteLine("Array ordenado de forma creciente: [" + string.Join(", ", array) + "]");
        }

        //public static void SortArray(int[] array)
        //{
        //    Console.WriteLine("Array: [" + string.Join(", ", array) + "]");

        //    Array.Sort(array);

        //    Console.WriteLine("Array ordenado de forma creciente: [" + string.Join(", ", array) + "]");
        //}




    }




}

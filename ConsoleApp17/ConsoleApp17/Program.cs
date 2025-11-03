using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    //Crear un programa que tenga un menu con los siguiente:
    //1.Ingresar 
    class Program
    {
        public static void IngresarDatos(int[] vector, int tamaño)
        {
            Console.WriteLine("\nIngrese los valores");
            for (int i = 0; i < tamaño; i++)
            {
                Console.Write("Digite el numero" + (i + 1) + ": ");
                vector[i] = int.Parse(Console.ReadLine());
            }
        }
        public static void MostrarDatos(int[] vector,int tamaño)
        {
            for (int i = 0; i < tamaño; i++)
            {
                Console.Write("[" + vector[i] + "]" + " ");
            }
            Console.WriteLine();
        }
        public static bool Eliminar(int[] vector,ref int tam,int pos)
        {
            if (pos<0 || pos>tam)
            {
                return false;//posicion invalida
            }
            for (int  i = pos-1;  i < tam-1; i++)
            {
                vector[i] = vector[i + 1];
            }
            tam--;
            return true;//se elimino correctamente
        }
        public static void Intercambiar(int[] vector,int pos1,int pos2)
        {
            int aux;
            aux = vector[pos1];
            vector[pos1] = vector[pos2];
            vector[pos2] = aux;
        }
        public static int Buscar(int[] vector,int tamaño,int valor)
        {
            for (int i = 0; i < tamaño; i++)
            {
                if (vector[i] == valor)
                {
                    return i;//retorna la posicion
                }
            }
            return -1;//no se encontro el valor
        }
        public static void MayorMenor(int[] vector,int tamaño,ref int mayor,ref int menor)
        {
            mayor = vector[0];
            menor = vector[0];
            for (int i = 1; i < tamaño; i++) {
                if (vector[i] > mayor)
                {
                    mayor = vector[i];
                }
                if (vector[i] < menor)
                {
                    menor = vector[i];
                }
            }
        }

        static void Main(string[] args)
        {
            int tamaño,posicion;
            int[] vector;
            bool eliminado = false;
            int opc;
            bool hayDatos = false;
            Console.WriteLine("Ingrese el tamaño: ");
            tamaño = int.Parse(Console.ReadLine());
            vector = new int[tamaño];
            //Menu opciones
            do
            {
                Console.WriteLine("\n****MENU DE OPCIONES***+");
                Console.WriteLine("\n1.Ingresar elementos" +
                                  "\n2.Mostrar elementos" +
                                  "\n3.Eliminar elemento por posicion" +
                                  "\n4.Intercambiar dos posiciones en el vector" +
                                  "\n5.Buscar elemento en el vector" +
                                  "\n6.Mostrar cuantos en mayor y menor" +
                                  "\n7.Salir del programa");
                Console.WriteLine("Seleccione una opcion: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        IngresarDatos(vector, tamaño);
                        hayDatos = true;
                        break;
                    case 2:
                        if (hayDatos)
                        {
                            Console.WriteLine("Mostrando el vector. ");
                            MostrarDatos(vector, tamaño);
                        }
                        else
                            Console.WriteLine("Debe ingresar elementos...!!!");
                        break;
                    case 3:
                        if (hayDatos)
                        {
                            Console.WriteLine("\nIngrese la posicion eliminar: ");
                            posicion = int.Parse(Console.ReadLine());
                            eliminado = Eliminar(vector,ref tamaño, posicion);
                            if (eliminado)
                            {
                                Console.WriteLine("Elemento eliminado...");
                                MostrarDatos(vector, tamaño);
                            }
                            else
                                Console.WriteLine("Posicion fuera de rango...!!!");
                        }
                        else
                            Console.WriteLine("Debe ingresar elementos...!!!");
                        break;
                    case 4:
                        if (hayDatos)
                        {
                            int pos1, pos2;
                            Console.WriteLine("Ingrese la primera posicion a intercambiar: ");
                            pos1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ingrese la segunda posicion a intercambiar: ");
                            pos2 = int.Parse(Console.ReadLine());
                            Intercambiar(vector, pos1 - 1, pos2 - 1);
                            Console.WriteLine("Elementos intercambiados...");
                            MostrarDatos(vector, tamaño);
                        }
                        else
                            Console.WriteLine("Debe ingresar elementos...!!!");
                        break;
                    case 5:
                        if (hayDatos)
                        {
                            int valor, resultado;
                            Console.WriteLine("Ingresar el valor a buscar: ");
                            valor = int.Parse(Console.ReadLine());
                            resultado = Buscar(vector, tamaño, valor);
                            if (resultado != -1)
                            {
                                Console.WriteLine("El valor se encuentra en la posicion: " + (resultado + 1));
                            }
                            else
                                Console.WriteLine("El valor no se encuentra en el vector");
                        }
                        else
                            Console.WriteLine("Debe ingresar elementos...!!!");
                        break;
                    case 6:
                        if (hayDatos)
                        {
                            int mayor = 0, menor = 0;
                            MayorMenor(vector, tamaño, ref mayor, ref menor);
                            Console.WriteLine("El mayor es: " + mayor);
                            Console.WriteLine("El menor es: " + menor);
                        }
                        else
                            Console.WriteLine("Debe ingresar elementos...!!!");
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("ERROR:Ingrese una opcion valida");
                        break;
                }
            }
            while (opc != 7);
        }
    }
}

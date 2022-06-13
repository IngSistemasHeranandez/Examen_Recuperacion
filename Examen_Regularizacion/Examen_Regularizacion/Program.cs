using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen_Regularizacion
{
    //Samuel Hernandez Perez 21210671
    class Program
    {
        //Clase
        class Inventario
        {
            //Campos de la clase
           public  string Producto;
            public int Cantidad;
            public float Precio;

            //Constructor
            public Inventario(string Producto,int Cantidad,float Precio)
            {
                this.Producto = Producto;
                this.Cantidad = Cantidad;
                this.Precio = Precio;
            }
           
            //Destructor
            ~Inventario()
            {
                Console.WriteLine("Memoria Liberada Objeto Inventario");
            }

        }
        static void Main(string[] args)
        {
            //Titulo Consola
            Console.Title = "Inventario";

            //Declaracion de variables
            string Producto;
            int Cantidad;
            float Precio;
            byte Opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("1.-Crear Archivo\n" +
                                  "2.-Consultar Archivo\n" +
                                  "3.-Salir\n");
                
                    Console.Write("Ingrese Opcion: ");
                Opcion = Convert.ToByte(Console.ReadLine());
                
                switch (Opcion)
                {
                    case 1:
                        try
                        {
                            Console.Clear();
                            StreamWriter sw =new StreamWriter("Producto.txt",true) ;
                            Console.WriteLine("Escrbiendo. . .");

                            //Asignaicon de valor a las variables
                            Console.Write("Nombre del Producto: ");
                            Producto = Console.ReadLine();
                            Console.Write("Cantidad: ");
                            Cantidad = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Precio del producto: ");
                            Precio = Convert.ToSingle(Console.ReadLine());

                            //Creacion del objeto
                            Inventario P = new Inventario(Producto,Cantidad,Precio);

                            //Escribir archivo
                            sw.WriteLine("Producto: "+P.Producto);
                            sw.WriteLine("Cantidad: " + P.Cantidad);
                            sw.WriteLine("Precio: {0:C}" , P.Precio);
                            sw.WriteLine("\n");

                            //Confirmacion
                            Console.Clear();
                            Console.WriteLine("Escritura Realizada con Exito...");
                            Console.WriteLine("Presion <Enter> para salir...");
                          
                            //Cerrar 
                            sw.Close();
                            Console.ReadKey();

                        }
                        catch(FormatException e)
                        {
                            Console.Clear();
                            Console.WriteLine(e);
                            Console.ReadKey();
                        }
                        catch(OverflowException e)
                        {
                            Console.WriteLine(e);
                            Console.ReadKey();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e);
                            Console.ReadKey();
                        }
                        break;

                    case 2:
                        Console.Clear();
                        //Consulta
                        StreamReader sb  = new StreamReader("Producto.txt");
                        Console.WriteLine("Consultando. . .");
                        Console.WriteLine(sb.ReadToEnd());
                        Console.ReadKey();
                        //Cerrar
                        sb.Close();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Presione <Enter> Para Finalizar. . .");
                        Console.ReadKey();
                        break;
                       
                    default:
                        Console.Clear();
                        Console.WriteLine("Ingresaste un caracter no valido!.\n\n"
                            + "Presione <Enter> Para regresar al Menu. . .");
                        Console.ReadKey();
                        break;
                }

            } while (Opcion != 3);
            
            Console.ReadKey();
        }
    }
}

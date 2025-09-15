using System;
using System.Collections.Generic;
namespace Ejercicios
{

    internal class Program
    {
        /* Descomponer el problema de gestionar un inventario 
        de libros (registro, búsqueda, actualización y eliminación). */

        static (List<string>, List<string>, List<string>, List<string>, List<string>) Ingreso()
        {
            var titulos = new List<string>();
            var numeroIdentificador = new List<string>();
            var editoriales = new List<string>();
            var cantidades = new List<string>();
            var diasprestados = new List<string>();


            Console.WriteLine("Inventario de libros, deje espacio en blanco y presione enter.");

            Console.WriteLine("Ingrese el número de libros que agregara al inventario");
            int numlibros = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numlibros; i++)
            {
                Console.Write("Titulo del libro: ");
                string? titulolibro = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(titulolibro))
                {
                    Console.WriteLine("El tiulo es obligatorio");
                    Console.Write("Ingrese el titulo del libro: ");
                    titulolibro = Console.ReadLine();
                
                }

                Console.Write("Ingrese el ISBN del libro: ");
                string? isbn = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(isbn))
                {
                    Console.WriteLine("El ISBN es obligatorio");
                    Console.Write("Ingrese el ISBN del libro: ");
                    isbn = Console.ReadLine();
                }

                Console.Write("Ingrese el nombre de la editorial: ");
                string? editorial = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(editorial))
                {
                    Console.WriteLine("La editorial del libro es obligatoria");
                    Console.Write("Ingrese la editorial del libro: ");
                    editorial = Console.ReadLine();
                }

                Console.Write("Ingrese la cantidad de libros: ");
                string? cantidad = (Console.ReadLine());

                while (string.IsNullOrWhiteSpace(cantidad))
                {
                    Console.WriteLine("La cantidad de libros es obligatorio");
                    Console.Write("Ingrese la cantidad de libros: ");
                    cantidad = Console.ReadLine();

                }

                string diasPrestado = "0";
                Console.Write("El libro fue prestado? (si/no): ");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta == "si")
                {
                    Console.WriteLine("Ingrese la cantidad de días que fue prestado el libro");
                    diasPrestado = Console.ReadLine();
                }


                titulos.Add(titulolibro);
                numeroIdentificador.Add(isbn);
                editoriales.Add(editorial);
                cantidades.Add(cantidad);
                diasprestados.Add(diasPrestado);

            }

            return (titulos, numeroIdentificador, editoriales, cantidades, diasprestados);

        }
        static void Busqueda(List<string> titulos, List<string> editoriales, List<string> numeroIdentificador)
        {
            Console.WriteLine("Busqueda de libros");

            while (true)
            {
                Console.Clear(); // Limpia la consola
                Console.WriteLine("--- Menú de Opciones ---");
                Console.WriteLine("1. Buscar el libro por titulo ");
                Console.WriteLine("2. Buscar el libro por ISBN ");
                Console.WriteLine("3. Salir");

                Console.Write("Selecciona una de las 3 opción: ");
                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ha seleccionado la opción 1.");
                            Console.WriteLine("Ingrese el título del libro:");
                            string? titulobuscado = Console.ReadLine();

                            while (string.IsNullOrWhiteSpace(titulobuscado))
                            {
                                Console.WriteLine("Es obligatorio que ingrese el titulo a buscar");
                                Console.Write("Ingrese el titulo a buscar: ");
                                titulobuscado = Console.ReadLine();
                            }

                            for (int i = 0; i < titulos.Count; i++)
                            {
                                bool encontrado = false;
                                if (titulos[i].Equals(titulobuscado, StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine($"El libro {titulos[i]} fue encontrado en la editorial {editoriales[i]}.");
                                    encontrado = true;
                                }
                                if (!encontrado)
                                {
                                    Console.WriteLine("El libro no fue encontrado.");
                                }
                            }
                            break;

                        case 2:
                            Console.WriteLine("Ha seleccionado la opción 2.");
                            Console.WriteLine("Ingrese el ISBN del libro:");
                            string? isbnbuscado = Console.ReadLine();

                            while (string.IsNullOrWhiteSpace(isbnbuscado))
                            {
                                Console.WriteLine("El ISBN es obligatorio para la busqueda");
                                Console.Write("Ingrese el ISBN: ");
                                isbnbuscado = Console.ReadLine();
                            }

                            for (int i = 0; i < numeroIdentificador.Count; i++)
                            {
                                if (numeroIdentificador[i].Equals(isbnbuscado, StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine($"El libro {titulos[i]} fue encontrado en la editorial {editoriales[i]}.");
                                }
                                else
                                {
                                    Console.WriteLine("El libro no fue encontrado.");
                                }

                            }
                            break;

                        case 3:
                            Console.WriteLine("Saliendo del programa.");
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione 1, 2 o 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
                }
            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();
            }
            
        }
        static void Actualizacion(List<string> titulos, List<string> editoriales, List<string> cantidades)
        {
            Console.WriteLine("Actualización de libros");
            Console.WriteLine("Ingrese el título del libro a actualizar:");
            string? titulobuscado = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(titulobuscado))
            {
                Console.WriteLine("Es obligatorio que ingrese el titulo a buscar");
                Console.Write("Ingrese el titulo del libro a actualizar: ");
                titulobuscado = Console.ReadLine();
            }

            for (int i = 0; i < titulos.Count; i++)
            {
                if (titulos[i].Equals(titulobuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"El libro {titulos[i]} fue encontrado en la editorial {editoriales[i]}.");
                    Console.Write("Ingrese el nuevo título del libro: ");
                    string? nuevoTitulo = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(nuevoTitulo))
                    {
                        Console.WriteLine("El nuevo titulo es obligatorio");
                        Console.Write("Ingrese el nuevo titulo");
                        nuevoTitulo = Console.ReadLine();
                    }

                    titulos[i] = nuevoTitulo;
                    Console.WriteLine("Título actualizado correctamente.");
                    Console.WriteLine("Presione una tecla para volver al menú...");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("El libro no fue encontrado.");
                }
                break;
            }
        }
        static void Eliminacion(List<string> titulos, List<string> numeroIdentificador, List<string> editoriales, List<string> cantidades, List<string> diasprestados)
        {
            Console.WriteLine("Eliminación de libros");
            Console.WriteLine("Ingrese el título del libro a eliminar:");
            string? titulobuscado = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(titulobuscado))
            {
                Console.WriteLine("Es obligatorio que ingrese el titulo a buscar");
                Console.Write("Ingrese el titulo del libro a actualizar: ");
                titulobuscado = Console.ReadLine();
            }


            for (int i = 0; i < titulos.Count; i++)
            {
                if (titulos[i].Equals(titulobuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"El libro {titulos[i]} fue encontrado en la editorial {editoriales[i]}.");
                    titulos.RemoveAt(i);
                    numeroIdentificador.RemoveAt(i);
                    editoriales.RemoveAt(i);
                    cantidades.RemoveAt(i);
                    diasprestados.RemoveAt(i);
                    Console.WriteLine("Libro eliminado correctamente.");
                    Console.WriteLine("Presione una tecla para volver al menú...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("El libro no fue encontrado.");
                }
                break;
            }
        }

        static void Listalibros(List<string> titulos, List<string> editoriales, List<string> numeroIdentificador, List<string> cantidades, List<string> diasprestados)
        {
            Console.Clear();
            Console.WriteLine("--- Listado de Libros Registrados ---");
            if (titulos.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
            }
            else
            {
                for (int i = 0; i < titulos.Count; i++)
                {
                    Console.WriteLine($"Libro #{i + 1}:");
                    Console.WriteLine($"  Título: {titulos[i]}");
                    Console.WriteLine($"  ISBN: {numeroIdentificador[i]}");
                    Console.WriteLine($"  Editorial: {editoriales[i]}");
                    Console.WriteLine($"  Cantidad: {cantidades[i]}");
                    Console.WriteLine($"  Días prestado: {diasprestados[i]}");
                    Console.WriteLine("-----------------------------------");
                }
            }
            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();
        }
        

        static void Main()
        {
            var (titulos, numeroIdentificador, editoriales, cantidades, diasprestados) = (new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>());
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- Menú Principal ---");
                Console.WriteLine("1. Registro de libros");
                Console.WriteLine("2. Búsqueda de libros");
                Console.WriteLine("3. Actualización de libros");
                Console.WriteLine("4. Eliminación de libros");
                Console.WriteLine("5. Lista de libros");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var resultado = Ingreso();
                        titulos.AddRange(resultado.Item1);
                        numeroIdentificador.AddRange(resultado.Item2);
                        editoriales.AddRange(resultado.Item3);
                        cantidades.AddRange(resultado.Item4);
                        diasprestados.AddRange(resultado.Item5);
                        break;
                    case "2":
                        Busqueda(titulos, editoriales, numeroIdentificador);
                        break;
                    case "3":
                        Actualizacion(titulos, editoriales, cantidades);
                        break;
                    case "4":
                        Eliminacion(titulos, editoriales, numeroIdentificador, cantidades, diasprestados);
                        break;
                    case "5":
                        Listalibros(titulos, editoriales, numeroIdentificador, cantidades, diasprestados);
                        break;
                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
            
        }

    }
}
    


     
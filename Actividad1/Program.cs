using System;

internal class Program
{
    private static readonly string defaultUser = "admin";
    private static readonly string defaultPassword = "1234";

    private static readonly string[] nombresUsuarios = new string[6];
    private static readonly string[] cedulasUsuarios = new string[6];
    private static int totalUsuarios = 5;

    private static readonly string[] nombresArticulos = new string[6];
    private static readonly int[] valoresArticulos = new int[6];
    private static int totalArticulos = 5;

    private static string articuloVenta = "";
    private static int cantidadDisponible = 0;

    private static void Main(string[] args)
    {
        AutenticarUsuario();
    }

    private static void AutenticarUsuario()
    {
        bool autenticado = false;

        while (!autenticado)
        {
            Console.Write("Ingrese el nombre de usuario: ");
            string inputUser = Console.ReadLine()!;

            Console.Write("Ingrese la contraseña: ");
            string inputPassword = Console.ReadLine()!;

            Console.Clear();
            if (inputUser == defaultUser && inputPassword == defaultPassword)
            {
                autenticado = true;
                Console.WriteLine("¡Bienvenido al sistema!\n");
                MostrarMenuPrincipal();
            }
            else
            {
                Console.WriteLine("Error de autenticación. Usuario o contraseña incorrectos.\n");
            }
        }
    }

    private static void MostrarMenuPrincipal()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Gestión de usuarios");
            Console.WriteLine("2. Gestión de artículos");
            Console.WriteLine("3. Gestión de ventas");
            Console.WriteLine("4. Salir del programa");
            Console.Write("Seleccione una opción (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        GestionUsuarios();
                        break;
                    case 2:
                        GestionArticulos();
                        break;
                    case 3:
                        GestionVentas();
                        break;
                    case 4:
                        Console.WriteLine("Se ha cerrado sesión en el programa. ¡Hasta luego!");
                        continuar = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número del 1 al 4.\n");
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione una tecla para volver al menú...");
                Console.ReadKey();
            }
        }
    }


    private static void GestionUsuarios()
    {
        for (int i = 0; i < totalUsuarios; i++)
        {
            Console.Clear();
            Console.Write($"Ingrese el nombre completo del usuario {i + 1}: ");
            nombresUsuarios[i] = Console.ReadLine()!;
            Console.Write($"Ingrese la cédula del usuario {i + 1}: ");
            cedulasUsuarios[i] = Console.ReadLine()!;
        }

        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("===== GESTIÓN DE USUARIOS =====");
            Console.WriteLine("1. Ver lista de usuarios");
            Console.WriteLine("2. Nuevo usuario");
            Console.WriteLine("3. Editar información de usuario (buscar por c.c)");
            Console.WriteLine("4. Salir de Gestión de usuarios");
            Console.Write("Seleccione una opción (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Lista de usuarios:");
                        for (int i = 0; i < totalUsuarios; i++)
                        {
                            Console.WriteLine($"{cedulasUsuarios[i]} {nombresUsuarios[i]}");
                        }
                        break;
                    case 2:
                        if (totalUsuarios < 6)
                        {
                            Console.Write("Ingrese el nombre del nuevo usuario: ");
                            nombresUsuarios[totalUsuarios] = Console.ReadLine()!;
                            Console.Write("Ingrese la cédula del nuevo usuario: ");
                            cedulasUsuarios[totalUsuarios] = Console.ReadLine()!;
                            totalUsuarios++;
                            Console.WriteLine("Usuario agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se pueden agregar más usuarios.");
                        }
                        break;
                    case 3:
                        Console.Write("Ingrese la cédula del usuario a buscar: ");
                        string cedulaBuscar = Console.ReadLine()!;
                        bool encontrado = false;
                        for (int i = 0; i < totalUsuarios; i++)
                        {
                            if (cedulasUsuarios[i] == cedulaBuscar)
                            {
                                Console.WriteLine("Usuario encontrado:");
                                Console.WriteLine($"{cedulasUsuarios[i]} {nombresUsuarios[i]}");
                                encontrado = true;
                                break;
                            }
                        }
                        if (!encontrado)
                        {
                            Console.WriteLine("Usuario no encontrado.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Saliendo de Gestión de Usuarios...");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número del 1 al 4.");
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }


    private static void GestionArticulos()
    {
        for (int i = 0; i < totalArticulos; i++)
        {
            Console.Clear();
            Console.Write($"Ingrese el nombre del artículo {i + 1}: ");
            nombresArticulos[i] = Console.ReadLine()!;

            bool valorValido = false;
            while (!valorValido)
            {
                Console.Write($"Ingrese el valor unitario del artículo {i + 1}: ");
                string entrada = Console.ReadLine()!;
                if (int.TryParse(entrada, out int valor))
                {
                    valoresArticulos[i] = valor;
                    valorValido = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
                }
            }
        }

        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("===== GESTIÓN DE ARTÍCULOS =====");
            Console.WriteLine("1. Ver lista de artículos");
            Console.WriteLine("2. Nuevo artículo");
            Console.WriteLine("3. Editar información del artículo (buscar por nombre)");
            Console.WriteLine("4. Salir de Gestión de artículos");
            Console.Write("Seleccione una opción (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Lista de artículos:");
                        for (int i = 0; i < totalArticulos; i++)
                        {
                            Console.WriteLine($"{nombresArticulos[i]} - $ {valoresArticulos[i]}");
                        }
                        break;
                    case 2:
                        if (totalArticulos < 6)
                        {
                            Console.Write("Ingrese el nombre del nuevo artículo: ");
                            nombresArticulos[totalArticulos] = Console.ReadLine()!;

                            bool valorValido = false;
                            while (!valorValido)
                            {
                                Console.Write("Ingrese el valor unitario: ");
                                string entrada = Console.ReadLine()!;
                                if (int.TryParse(entrada, out int valor))
                                {
                                    valoresArticulos[totalArticulos] = valor;
                                    valorValido = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero.");
                                }
                            }

                            totalArticulos++;
                            Console.WriteLine("Artículo agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se pueden agregar más artículos.");
                        }
                        break;
                    case 3:
                        Console.Write("Ingrese el nombre del artículo a buscar: ");
                        string nombreBuscar = Console.ReadLine()!;
                        bool encontrado = false;
                        for (int i = 0; i < totalArticulos; i++)
                        {
                            if (nombresArticulos[i].Equals(nombreBuscar, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Artículo encontrado:");
                                Console.WriteLine($"{nombresArticulos[i]} - $ {valoresArticulos[i]}");
                                encontrado = true;
                                break;
                            }
                        }
                        if (!encontrado)
                        {
                            Console.WriteLine("Artículo no encontrado.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Saliendo de Gestión de Artículos...");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número del 1 al 4.");
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }


    private static void GestionVentas()
    {
        Console.Clear();
        Console.Write("Ingrese el nombre del artículo para la venta: ");
        articuloVenta = Console.ReadLine()!;

        cantidadDisponible = 0;
        bool cantidadValida = false;

        while (!cantidadValida)
        {
            Console.Write("Ingrese la cantidad disponible: ");
            string entrada = Console.ReadLine()!;
            if (int.TryParse(entrada, out cantidadDisponible) && cantidadDisponible >= 0)
            {
                cantidadValida = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero no negativo.");
            }
        }

        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("===== GESTIÓN DE VENTAS =====");
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Salir de Gestión de ventas");
            Console.Write("Seleccione una opción (1-2): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"Artículo: {articuloVenta}");
                        Console.WriteLine($"Cantidad disponible: {cantidadDisponible}");
                        int cantidadCompra = 0;
                        bool entradaValida = false;

                        while (!entradaValida)
                        {
                            Console.Write("Ingrese la cantidad a comprar: ");
                            string entrada = Console.ReadLine()!;
                            if (int.TryParse(entrada, out cantidadCompra) && cantidadCompra > 0)
                            {
                                entradaValida = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero positivo.");
                                Console.WriteLine($"Artículo: {articuloVenta}");
                                Console.WriteLine($"Cantidad disponible: {cantidadDisponible}");
                            }
                        }

                        if (cantidadCompra <= cantidadDisponible)
                        {
                            cantidadDisponible -= cantidadCompra;
                            Console.WriteLine("Venta registrada con éxito.");
                            Console.WriteLine($"Cantidad restante: {cantidadDisponible}");
                        }
                        else
                        {
                            Console.WriteLine("No hay cantidad suficiente del artículo.");
                        }
                        break;
                    case 2:
                        continuar = false;
                        Console.WriteLine("Saliendo de Gestión de Ventas...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}

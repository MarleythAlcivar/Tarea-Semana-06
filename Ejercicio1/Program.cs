using System;

// Definimos cada nodo como un vehículo individual
class Vehiculo
{
    public string Placa;
    public string Marca;
    public string Modelo;
    public int Año;
    public decimal Precio;
    public Vehiculo Siguiente;
}

// Manejador de la lista enlazada de vehículos
class ListaVehiculos
{
    private Vehiculo inicio = null;

    // Agrega un vehículo nuevo al principio de la lista
    public void AgregarVehiculo(string placa, string marca, string modelo, int año, decimal precio)
    {
        Vehiculo nuevo = new Vehiculo
        {
            Placa = placa,
            Marca = marca,
            Modelo = modelo,
            Año = año,
            Precio = precio,
            Siguiente = inicio
        };
        inicio = nuevo;
        Console.WriteLine("✔ Vehículo registrado con éxito.");
    }

    // Permite buscar un vehículo en la lista según la placa
    public void BuscarVehiculoPorPlaca(string placa)
    {
        Vehiculo actual = inicio;
        while (actual != null)
        {
            if (actual.Placa == placa)
            {
                Console.WriteLine($"🚗 Vehículo encontrado: {actual.Placa} - {actual.Marca} {actual.Modelo}, Año {actual.Año}, Precio: ${actual.Precio}");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("❌ Vehículo no encontrado con esa placa.");
    }

    // Filtra y muestra todos los vehículos registrados en un año específico
    public void VerVehiculosPorAño(int año)
    {
        Vehiculo actual = inicio;
        bool encontrado = false;
        while (actual != null)
        {
            if (actual.Año == año)
            {
                Console.WriteLine($"🔎 {actual.Placa} - {actual.Marca} {actual.Modelo}, Precio: ${actual.Precio}");
                encontrado = true;
            }
            actual = actual.Siguiente;
        }
        if (!encontrado)
        {
            Console.WriteLine("⚠ No se encontraron vehículos para ese año.");
        }
    }

    // Muestra todos los vehículos registrados, sin filtros
    public void VerTodosLosVehiculos()
    {
        Vehiculo actual = inicio;
        if (actual == null)
        {
            Console.WriteLine("ℹ No hay vehículos registrados.");
            return;
        }

        Console.WriteLine("📋 Listado de todos los vehículos:");
        while (actual != null)
        {
            Console.WriteLine($"- {actual.Placa} | {actual.Marca} {actual.Modelo} | Año: {actual.Año} | Precio: ${actual.Precio}");
            actual = actual.Siguiente;
        }
    }

    // Elimina un vehículo usando la placa como referencia
    public void EliminarVehiculo(string placa)
    {
        Vehiculo actual = inicio;
        Vehiculo anterior = null;

        while (actual != null)
        {
            if (actual.Placa == placa)
            {
                if (anterior == null)
                {
                    inicio = actual.Siguiente;
                }
                else
                {
                    anterior.Siguiente = actual.Siguiente;
                }
                Console.WriteLine("🗑 Vehículo eliminado correctamente.");
                return;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        Console.WriteLine("❌ No se encontró un vehículo con esa placa para eliminar.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaVehiculos lista = new ListaVehiculos();
        string opcion;

        // Menú principal que guía al usuario paso a paso
        do
        {
            Console.WriteLine("\n🚘 MENÚ PRINCIPAL - Registro de Vehículos (Área de Ingeniería de Sistemas)");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos");
            Console.WriteLine("5. Eliminar vehículo");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese placa: ");
                    string placa = Console.ReadLine();
                    Console.Write("Ingrese marca: ");
                    string marca = Console.ReadLine();
                    Console.Write("Ingrese modelo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Ingrese año: ");
                    int año = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    lista.AgregarVehiculo(placa, marca, modelo, año, precio);
                    break;

                case "2":
                    Console.Write("Ingrese la placa a buscar: ");
                    lista.BuscarVehiculoPorPlaca(Console.ReadLine());
                    break;

                case "3":
                    Console.Write("Ingrese el año: ");
                    lista.VerVehiculosPorAño(int.Parse(Console.ReadLine()));
                    break;

                case "4":
                    lista.VerTodosLosVehiculos();
                    break;

                case "5":
                    Console.Write("Ingrese la placa del vehículo a eliminar: ");
                    lista.EliminarVehiculo(Console.ReadLine());
                    break;

                case "6":
                    Console.WriteLine("👋 Saliendo del programa. ¡Gracias!");
                    break;

                default:
                    Console.WriteLine("⚠ Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != "6");
    }
}


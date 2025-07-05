using System;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;

    public Nodo(int valor)
    {
        Dato = valor;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    private Nodo inicio;

    public ListaEnlazada()
    {
        inicio = null;
    }

    public void InsertarAlInicio(int valor)
    {
        Nodo nuevo = new Nodo(valor);
        nuevo.Siguiente = inicio;
        inicio = nuevo;
    }

    public int Contar()
    {
        int contador = 0;
        Nodo actual = inicio;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    public bool Comparar(ListaEnlazada otra)
    {
        Nodo actual1 = this.inicio;
        Nodo actual2 = otra.inicio;

        while (actual1 != null && actual2 != null)
        {
            if (actual1.Dato != actual2.Dato)
                return false;

            actual1 = actual1.Siguiente;
            actual2 = actual2.Siguiente;
        }

        // Si ambos son null, las listas tienen el mismo tamaño
        return actual1 == null && actual2 == null;
    }

    public void Mostrar()
    {
        Nodo actual = inicio;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}

class Programa
{
    static void Main()
    {
        ListaEnlazada lista1 = new ListaEnlazada();
        ListaEnlazada lista2 = new ListaEnlazada();

        Console.Write("Ingrese la cantidad de elementos para la PRIMERA lista: ");
        int cantidad1 = int.Parse(Console.ReadLine());
        for (int i = 0; i < cantidad1; i++)
        {
            Console.Write($"Ingrese el dato #{i + 1} para la PRIMERA lista: ");
            int valor = int.Parse(Console.ReadLine());
            lista1.InsertarAlInicio(valor);
        }

        Console.Write("Ingrese la cantidad de elementos para la SEGUNDA lista: ");
        int cantidad2 = int.Parse(Console.ReadLine());
        for (int i = 0; i < cantidad2; i++)
        {
            Console.Write($"Ingrese el dato #{i + 1} para la SEGUNDA lista: ");
            int valor = int.Parse(Console.ReadLine());
            lista2.InsertarAlInicio(valor);
        }

        Console.WriteLine("\nContenido de la PRIMERA lista:");
        lista1.Mostrar();
        Console.WriteLine("Contenido de la SEGUNDA lista:");
        lista2.Mostrar();

        Console.WriteLine("\nResultado de la comparación:");

        if (cantidad1 != cantidad2)
        {
            Console.WriteLine("c. No tienen el mismo tamaño ni contenido.");
        }
        else
        {
            bool sonIguales = lista1.Comparar(lista2);
            if (sonIguales)
                Console.WriteLine("a. Las listas son iguales en tamaño y contenido.");
            else
                Console.WriteLine("b. Las listas son iguales en tamaño pero no en contenido.");
        }
    }
}

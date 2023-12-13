using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        bool continuarPrograma = true;
        List<int> data = new List<int>();

        while (continuarPrograma)
        {
            Console.WriteLine("Seleccione una estructura de datos:");
            Console.WriteLine("1. Pila");
            Console.WriteLine("2. Cola");
            Console.WriteLine("3. Lista");
            Console.WriteLine("4. Árbol");
            Console.WriteLine("5. Grafo");
            Console.WriteLine("6. Salir");
            Console.WriteLine("7. Menú de Ordenamientos");

            Console.Write("Ingrese el número de la opción: ");
            string opcionEstructura = Console.ReadLine();

            switch (opcionEstructura)
            {
                case "1":
                    EjecutarOperacionesPila();
                    break;
                case "2":
                    EjecutarOperacionesCola();
                    break;
                case "3":
                    EjecutarOperacionesLista();
                    break;
                case "4":
                    EjecutarOperacionesArbol();
                    break;
                case "5":
                    EjecutarOperacionesGrafo();
                    break;
                case "6":
                    continuarPrograma = false;
                    break;
                case "7":
                    data = ObtenerDatosUsuario();
                    EjecutarMenuOrdenamientos(data);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    static List<int> ObtenerDatosUsuario()
    {
        Console.WriteLine("Ingrese datos (separados por espacios): ");
        string[] input = Console.ReadLine().Split(' ');

        List<int> data = new List<int>();
        foreach (var item in input)
        {
            if (int.TryParse(item, out int num))
            {
                data.Add(num);
            }
            else
            {
                Console.WriteLine($"'{item}' no es un número válido y será ignorado.");
            }
        }

        return data;
    }

    static void EjecutarMenuOrdenamientos(List<int> data)
    {
        bool continuarMenu = true;

        while (continuarMenu)
        {
            Console.WriteLine("\nSorting Menu:");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Insertion Sort");
            Console.WriteLine("4. QuickSort");
            Console.WriteLine("5. Merge Sort");
            Console.WriteLine("6. Heap Sort");
            Console.WriteLine("7. Shell Sort");
            Console.WriteLine("8. Counting Sort");
            Console.WriteLine("9. Radix Sort");
            Console.WriteLine("10. Exit");

            Console.Write("Seleccione una opción (1-5): ");
            string sortingOption = Console.ReadLine();

            switch (sortingOption)
            {
                case "1":
                    BubbleSort(data);
                    MostrarDatos(data);
                    break;
                case "2":
                    SelectionSort(data);
                    MostrarDatos(data);
                    break;
                case "3":
                    InsertionSort(data);
                    MostrarDatos(data);
                    break;
                case "4":
                    QuickSort(data, 0, data.Count - 1);
                    MostrarDatos(data);
                    break;
                case "5":
                    MergeSort(data, 0, data.Count - 1);
                    Console.WriteLine("Datos ordenados con MergeSort: " + string.Join(", ", data));
                    break;

                case "6":
                    HeapSort(data);
                    MostrarDatos(data);
                    break;
                case "7":
                    ShellSort(data);
                    MostrarDatos(data);
                    break;
                case "8":
                    CountingSort(data);
                    MostrarDatos(data);
                    break;
                case "9":
                    RadixSort(data);
                    MostrarDatos(data);
                    break;
                case "10":
                    continuarMenu = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    static void MostrarDatos(List<int> data)
    {
        Console.WriteLine("Datos ordenados: " + string.Join(", ", data));
    }

    static void BubbleSort(List<int> data)
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            for (int j = 0; j < data.Count - i - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    // Intercambiar elementos si están en el orden incorrecto
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Datos ordenados con Bubble Sort.");
    }

    static void SelectionSort(List<int> data)
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            int minIndex = i;

            // Encontrar el índice del elemento mínimo en el resto del array
            for (int j = i + 1; j < data.Count; j++)
            {
                if (data[j] < data[minIndex])
                {
                    minIndex = j;
                }
            }

            // Intercambiar el elemento mínimo con el primer elemento sin ordenar
            int temp = data[minIndex];
            data[minIndex] = data[i];
            data[i] = temp;
        }

        Console.WriteLine("Datos ordenados con Selection Sort.");
    }

    static void InsertionSort(List<int> data)
    {
        for (int i = 1; i < data.Count; i++)
        {
            int key = data[i];
            int j = i - 1;

            // Mover los elementos del array que son mayores que key a una posición adelante de su posición actual
            while (j >= 0 && data[j] > key)
            {
                data[j + 1] = data[j];
                j--;
            }

            // Insertar el elemento key en su posición correcta
            data[j + 1] = key;
        }

        Console.WriteLine("Datos ordenados con Insertion Sort.");
    }
    static void QuickSort(List<int> data, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(data, low, high);

            QuickSort(data, low, partitionIndex - 1);
            QuickSort(data, partitionIndex + 1, high);
        }
    
    }
    static int Partition(List<int> data, int low, int high)
    {
        int pivot = data[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (data[j] < pivot)
            {
                i++;
                Swap(data, i, j);
            }
        }

        Swap(data, i + 1, high);
        return i + 1;
    }

    static void Swap(List<int> data, int i, int j)
    {
        int temp = data[i];
        data[i] = data[j];
        data[j] = temp;
    }

    static void MergeSort(List<int> data, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            MergeSort(data, left, middle);
            MergeSort(data, middle + 1, right);

            Merge(data, left, middle, right);
        }
    }

    static void Merge(List<int> data, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        Array.Copy(data.ToArray(), left, leftArray, 0, n1);
        Array.Copy(data.ToArray(), middle + 1, rightArray, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                data[k] = leftArray[i];
                i++;
            }
            else
            {
                data[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            data[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            data[k] = rightArray[j];
            j++;
            k++;
        }
    }

    static void HeapSort(List<int> data)
    {
        int n = data.Count;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(data, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = data[0];
            data[0] = data[i];
            data[i] = temp;

            Heapify(data, i, 0);
        }
    }

    static void Heapify(List<int> data, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && data[left] > data[largest])
            largest = left;

        if (right < n && data[right] > data[largest])
            largest = right;

        if (largest != i)
        {
            int swap = data[i];
            data[i] = data[largest];
            data[largest] = swap;

            Heapify(data, n, largest);
        }
    }

    static void ShellSort(List<int> data)
    {
        int n = data.Count;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i += 1)
            {
                int temp = data[i];
                int j;
                for (j = i; j >= gap && data[j - gap] > temp; j -= gap)
                    data[j] = data[j - gap];

                data[j] = temp;
            }
        }
    }

    static void CountingSort(List<int> data)
    {
        int n = data.Count;
        int[] output = new int[n];

        int max = data.Max();
        int min = data.Min();
        int range = max - min + 1;

        int[] count = new int[range];
        int[] outputData = new int[n];

        for (int i = 0; i < n; i++)
            count[data[i] - min]++;

        for (int i = 1; i < range; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[data[i] - min] - 1] = data[i];
            count[data[i] - min]--;
        }

        for (int i = 0; i < n; i++)
            data[i] = output[i];
    }
    static void RadixSort(List<int> data)
    {
        int max = data.Max();
        for (int exp = 1; max / exp > 0; exp *= 10)
            CountingSortRadix(data, exp);
    }

    static void CountingSortRadix(List<int> data, int exp)
    {
        int n = data.Count;
        int[] output = new int[n];
        int[] count = new int[10];

        for (int i = 0; i < n; i++)
            count[(data[i] / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[(data[i] / exp) % 10] - 1] = data[i];
            count[(data[i] / exp) % 10]--;
        }

        for (int i = 0; i < n; i++)
            data[i] = output[i];
    }



    static void EjecutarOperacionesPila()
    {
        Console.WriteLine("Operaciones con Pila:");
        Stack<int> pila = new Stack<int>();
        OperacionesPila(pila, "pila");
    }

    static void EjecutarOperacionesCola()
    {
        Console.WriteLine("Operaciones con Cola:");
        Queue<string> cola = new Queue<string>();
        OperacionesCola(cola, "cola");
    }

    static void EjecutarOperacionesLista()
    {
        Console.WriteLine("Operaciones con Lista:");
        List<double> lista = new List<double>();
        OperacionesLista(lista, "lista");
    }

    static void EjecutarOperacionesArbol()
    {
        Console.WriteLine("Operaciones con Árbol:");
        Arbol arbol = new Arbol();
        LlenarArbolConPrioridades(arbol);
        Console.WriteLine("Recorrido Inorden del árbol con prioridades:");
        arbol.RecorridoInorden();
    }

    static void EjecutarOperacionesGrafo()
    {
        Console.WriteLine("Operaciones con Grafo:");
        Grafo grafo = new Grafo();
        LlenarGrafo(grafo);
        Console.WriteLine("Representación del Grafo:");
        MostrarGrafo(grafo);
    }







    static void MostrarColeccion<T>(IEnumerable<T> coleccion)
    {
        foreach (var elemento in coleccion.Reverse())
        {
            Console.Write($"{elemento} ");
        }
        Console.WriteLine();
    }

    static void LlenarArbol(Arbol arbol)
    {
        Console.Write("Ingrese elementos para el árbol (separados por espacio): ");
        string[] elementos = Console.ReadLine().Split(' ');

        foreach (var elemento in elementos)
        {
            if (int.TryParse(elemento, out int num))
            {
                // Se proporciona una prioridad por defecto (puedes ajustar esto según tus necesidades)
                arbol.Insertar(num, "media");
            }
        }
    }

    static void LlenarArbolConPrioridades(Arbol arbol)
    {
        Console.Write("Ingrese elementos para el árbol (separados por espacio): ");
        string[] elementos = Console.ReadLine().Split(' ');

        foreach (var elemento in elementos)
        {
            if (int.TryParse(elemento, out int num))
            {
                Console.Write($"Ingrese la prioridad para el elemento {num} (alta, media, baja): ");
                string prioridad = Console.ReadLine().ToLower();
                if (prioridad == "alta" || prioridad == "media" || prioridad == "baja")
                {
                    arbol.Insertar(num, prioridad);
                }
                else
                {
                    Console.WriteLine("Prioridad no válida. Se asignará 'media' por defecto.");
                    arbol.Insertar(num, "media");
                }
            }
        }
    }
    static void LlenarGrafo(Grafo grafo)
    {
        Console.Write("Ingrese vértices para el grafo (separados por espacio): ");
        string[] vertices = Console.ReadLine().Split(' ');

        foreach (var vertice in vertices)
        {
            grafo.AgregarVertice(vertice);
        }

        Console.WriteLine("Ingrese aristas para el grafo (pares de vértices, separados por espacio):");
        string[] aristas = Console.ReadLine().Split(' ');

        for (int i = 0; i < aristas.Length; i += 2)
        {
            grafo.AgregarArista(aristas[i], aristas[i + 1]);
        }
    }

    static void MostrarGrafo(Grafo grafo)
    {
        foreach (var vertice in grafo.ObtenerVertices())
        {
            Console.Write($"{vertice}: ");
            foreach (var vecino in grafo.ObtenerVecinos(vertice))
            {
                Console.Write($"{vecino} ");
            }
            Console.WriteLine();
        }
    }
    static void OperacionesPila(Stack<int> pila, string nombre)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine($"\nOperaciones en la {nombre}:");
            Console.WriteLine("1. Agregar elemento");
            Console.WriteLine("2. Quitar elemento");
            Console.WriteLine("3. Mostrar contenido");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción (1-4): ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarElemento(pila);
                    break;
                case "2":
                    QuitarElemento(pila);
                    break;
                case "3":
                    MostrarColeccion(pila);
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    // Método para operaciones específicas de pila
    static void AgregarElemento(Stack<int> pila)
    {
        Console.Write("Ingrese el elemento a agregar: ");
        if (int.TryParse(Console.ReadLine(), out int num))
        {
            pila.Push(num);
            Console.WriteLine($"Elemento {num} agregado a la pila.");
        }
        else
        {
            Console.WriteLine("Entrada no válida. Inténtelo de nuevo.");
        }
    }

    // Método para operaciones específicas de pila
    static void QuitarElemento(Stack<int> pila)
    {
        if (pila.Count > 0)
        {
            int elementoQuitado = pila.Pop();
            Console.WriteLine($"Elemento {elementoQuitado} quitado de la pila.");
        }
        else
        {
            Console.WriteLine("La pila está vacía.");
        }
    }

    static void OperacionesCola(Queue<string> cola, string nombre)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine($"\nOperaciones en la {nombre}:");
            Console.WriteLine("1. Agregar elemento");
            Console.WriteLine("2. Quitar elemento");
            Console.WriteLine("3. Mostrar contenido");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción (1-4): ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarElemento(cola);
                    break;
                case "2":
                    QuitarElemento(cola);
                    break;
                case "3":
                    MostrarColeccion(cola);
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    // Método para operaciones específicas de cola
    static void AgregarElemento(Queue<string> cola)
    {
        Console.Write("Ingrese el elemento a agregar: ");
        string elemento = Console.ReadLine();
        cola.Enqueue(elemento);
        Console.WriteLine($"Elemento '{elemento}' agregado a la cola.");
    }

    // Método para operaciones específicas de cola
    static void QuitarElemento(Queue<string> cola)
    {
        if (cola.Count > 0)
        {
            string elementoQuitado = cola.Dequeue();
            Console.WriteLine($"Elemento '{elementoQuitado}' quitado de la cola.");
        }
        else
        {
            Console.WriteLine("La cola está vacía.");
        }
    }
    static void OperacionesLista(List<double> lista, string nombre)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine($"\nOperaciones en la {nombre}:");
            Console.WriteLine("1. Agregar elemento");
            Console.WriteLine("2. Quitar elemento");
            Console.WriteLine("3. Mostrar contenido");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción (1-4): ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarElemento(lista);
                    break;
                case "2":
                    QuitarElemento(lista);
                    break;
                case "3":
                    MostrarColeccion(lista);
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    // Método para operaciones específicas de lista
    static void AgregarElemento(List<double> lista)
    {
        Console.Write("Ingrese el elemento a agregar: ");
        if (double.TryParse(Console.ReadLine(), out double num))
        {
            lista.Add(num);
            Console.WriteLine($"Elemento {num} agregado a la lista.");
        }
        else
        {
            Console.WriteLine("Entrada no válida. Inténtelo de nuevo.");
        }
    }

    // Método para operaciones específicas de lista
    static void QuitarElemento(List<double> lista)
    {
        if (lista.Count > 0)
        {
            Console.Write("Ingrese la posición del elemento a quitar: ");
            if (int.TryParse(Console.ReadLine(), out int posicion) && posicion >= 0 && posicion < lista.Count)
            {
                double elementoQuitado = lista[posicion];
                lista.RemoveAt(posicion);
                Console.WriteLine($"Elemento {elementoQuitado} quitado de la lista.");
            }
            else
            {
                Console.WriteLine("Posición no válida. Inténtelo de nuevo.");
            }
        }
        else
        {
            Console.WriteLine("La lista está vacía.");
        }
    }

}

class NodoArbol
{
    public int Valor;
    public string Prioridad; // Nueva propiedad para la prioridad
    public NodoArbol Izquierdo;
    public NodoArbol Derecho;
}

class Arbol
{
    private NodoArbol raiz;

    public void Insertar(int valor, string prioridad)
    {
        raiz = InsertarRec(raiz, valor, prioridad);
    }

    private NodoArbol InsertarRec(NodoArbol nodo, int valor, string prioridad)
    {
        if (nodo == null)
        {
            nodo = new NodoArbol();
            nodo.Valor = valor;
            nodo.Prioridad = prioridad;
            nodo.Izquierdo = nodo.Derecho = null;
        }
        else if (valor < nodo.Valor)
        {
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor, prioridad);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecho = InsertarRec(nodo.Derecho, valor, prioridad);
        }
        return nodo;
    }

    public void RecorridoInorden()
    {
        RecorridoInordenRec(raiz);
        Console.WriteLine();
    }

    private void RecorridoInordenRec(NodoArbol nodo)
    {
        if (nodo != null)
        {
            RecorridoInordenRec(nodo.Izquierdo);
            Console.Write($"{nodo.Valor} ({nodo.Prioridad}) ");
            RecorridoInordenRec(nodo.Derecho);
        }
    }
}

// Definición de un grafo simple
class Grafo
{
    private Dictionary<string, List<string>> grafo;

    public Grafo()
    {
        grafo = new Dictionary<string, List<string>>();
    }

    public void AgregarVertice(string vertice)
    {
        grafo.Add(vertice, new List<string>());
    }

    public void AgregarArista(string origen, string destino)
    {
        grafo[origen].Add(destino);
        grafo[destino].Add(origen);
    }

    public List<string> ObtenerVertices()
    {
        return new List<string>(grafo.Keys);
    }

    public List<string> ObtenerVecinos(string vertice)
    {
        return grafo[vertice];
    }
}

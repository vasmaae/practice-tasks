//номер 1
//Реализовать абстрактный тип данных дек на основе структуры данных двусвязный список.

//краткое описание
/*
    Дек - абстрактный тип данных,
    в котором элементы можно 
    добавлять и удалять как в начало,
    так и в конец.
    Основные операции:
    PushBack — добавление в конец.
    PushFront — добавление в начало.
    PopBack — выборка из конца.
    PopFront — выборка из начала.
    IsEmpty — проверка наличия 
    элементов.
*/
class Node
{
    public int data;
    public Node? next;
    public Node? prev;
    public static Node GetNode(int data)
    {
        Node node = new();
        node.data = data;
        node.next = node.prev = null;
        return node;
    }
}
public class Deque
{
    Node? front;
    Node? end;
    int size;

    public Deque()
    {
        front = end = null;
        size = 0;
    }
    public bool IsEmpty()
    {
        return front == null;
    }
    public int Size()
    {
        return size;
    }
    public void PushFront(int data)
    {
        Node? node = Node.GetNode(data);
        if (node == null)
        {
            return;
        }
        else
        {
            if (front == null)
                front = end = node;
            else
            {
                node.next = front;
                front.prev = node;
                front = node;
            }
        }
    }
    public void PushBack(int data)
    {
        Node node = Node.GetNode(data);
        if (node == null)
        {
            return;
        }
        else
        {
            if (end == null)
                front = end = node;
            else
            {
                node.prev = end;
                end.next = node;
                end = node;
            }
            size++;
        }

    }
    public int? PopFront()
    {
        if (IsEmpty())
        {
            return null;
        }
        int data = front.data;
        if (!IsEmpty())
        {
            Node temp = front;
            front = front.next;
            if (front == null)
                end = null;
            else
                front.prev = null;
            size--;
        }
        return data;
    }
    public int? PopEnd()
    {
        if (IsEmpty())
        {
            return null;
        }
        int data = end.data;
        if (!IsEmpty())
        {
            Node temp = end;
            end = end.prev;
            if (end == null)
                front = null;
            else
                end.next = null;
            size--;
        }
        return data;
    }


    public IEnumerable<int> GetAll()
    {
        Node ptr = front;
        while (ptr != null)
        {
            int data = ptr.data;
            ptr = ptr.next;
            yield return data;
        }
        yield break;
    }
} 


//номер 2
//Придурковатая сортировка (Stooge sort) 
/*
    Алгоритм Stooge sort заключается в следующем:

    Если значение элемента в конце списка меньше, чем значение элемента в начале, то поменять их местами.
    Если есть 3 или более элементов в текущем подмножестве списка, то:
    Рекурсивно вызвать сортировку для первых 2/3 списка
    Рекурсивно вызвать сортировку для последних 2/3 списка
    Рекурсивно вызвать сортировку для первых 2/3 списка снова
    Иначе: конец подпрограммы.
Википедия*/
public void StoogeSort(int[] array, int left, int right)
{
    int tmp, k;
    if (array[left] > array[right])
    {
        CollectValue(array); //сохраняем куда-то изменения 1
        tmp = array[left];
        array[left] = array[right];
        array[right] = tmp;
        CollectValue(array); //сохраняем куда-то изменения 2
    }
    if ((left + 1) >= right)
    {
        return;
    }

    k = (right - left + 1) / 3;
    StoogeSort(array, left, right - k);
    StoogeSort(array, left + k, right);
    StoogeSort(array, left, right - k);
}
//примерно так сохранить получилось
public void CollectValue(int[] array)
{
    int size = array.GetLength(0);
    int[] arr = new int[size];
    for (int i = 0; i < size; i++)
    {
        arr[i] = array[i];
    }
    states.Add(arr);
}
//номер 3
/*
Произведение матриц — ассоциативная операция, которая принимает на вход две матрицы размером k×m и m×n и возвращает матрицу размером k×n, потратив на это kmn операций умножения.

Когда матрицы велики по одному измерению и малы по другому, количество скалярных операций может серьёзно зависеть от порядка перемножений матриц. Допустим, нам даны 3 матрицы 
𝐴1, 𝐴2, 𝐴3 размерами соответственно 10×100, 100×5 и 5×50. Существует 2 способа их перемножения (расстановки скобок): 
((𝐴1 𝐴2)𝐴3) и (𝐴1(𝐴2 𝐴3))
В первом случае нам потребуется 10·100·5 + 10·5·50 = 7500 скалярных умножений,
а во втором случае 100·5·50 + 10·100·50 = 75000 умножений — разница налицо. 
Поэтому может быть выгоднее потратить некоторое время на предобработку, решив, 
в каком порядке лучше всего умножать, чем умножать сразу в лоб.

Таким образом, даны n матриц, требуется определить, в каком порядке перемножать их, чтобы количество операций умножения было минимальным.
O(n^3) или O(n^2) гуглите я не андестенд,  n - число матриц
*/
public int MinMatrixMultiplications(int[] p)
{
    int n = p.Length - 1;
    int[,] m = new int[n + 1, n + 1];
    for (int i = 1; i <= n; i++)
    {
        m[i, i] = 0;
    }
    for (int len = 2; len <= n; len++)
    {
        for (int i = 1; i <= n - len + 1; i++)
        {
            int j = i + len - 1;
            m[i, j] = Int32.MaxValue;
            for (int k = i; k < j; k++)
            {
                int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                if (q < m[i, j])
                {
                    m[i, j] = q;
                }
            }
        }
    }
    return m[1, n];
}

private void button1_Click(object sender, EventArgs e)
{
    //откуда-то получаем размеры матриц
    //записываются примерно так: arr[] = {40, 20, 30, 10, 30}
    //Имеются 4 матрицы размерами 40×20, 20×30, 30×10, 10×30.
    //Пусть входными 4 матрицами будут A, B, C и D.
    //Минимальное количество умножений получается посредством 
    //расстановки скобок следующим образом (A(BC))D.
    //Минимум 20*30*10 + 40*20*10 + 40*10*30.
    //https://www.geeksforgeeks.org/matrix-chain-multiplication-dp-8/
}

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

//номер 3

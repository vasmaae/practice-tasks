namespace Practice_2
{
    public partial class Form1 : Form
    {
        Stack stack;
        int[] array;
        PyramidSort sorter;
        int currentState = 0;
        public Form1()
        {
            InitializeComponent();
            textBoxADTDescription.Text = "—тек - абстрактный тип данных, воплощающий пор€док вхождени€ элементов \"ѕервым вошел - последним вышел\"";
            textBoxSortDescription.Text = "ѕирамидальна€ сортировка - это метод сортировки сравнением, основанный на двоичной куче";
            textBoxAlgoDescription.Text = "«адача о наибольшей общей последовательности";
            stack = new Stack();

            sorter = new PyramidSort();
            
        }

        private void buttonAddToADT_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            stack.push(r.Next(-20, 21));
            textBoxADT.Text = stack.ToString();
        }

        private void buttonRemoveFromADT_Click(object sender, EventArgs e)
        {
            stack.pop();
            textBoxADT.Text = stack.ToString();
        }

        private void buttonCreateArray_Click(object sender, EventArgs e)
        {
            array = new int[10];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-10, 11);
            }
            
            textBoxStartArray.Text = sorter.printArray(array);
            sorter.sort(array);
            //textBoxSortProgress.Text = sorter.printArray(array);
        }

        private void buttonDoStep_Click(object sender, EventArgs e)
        {
            if (array == null) return;
            if (currentState >= sorter.states.Count) return;
            textBoxSortProgress.Text = sorter.printArray(sorter.states[currentState]);
            currentState++;
        }
    }
}

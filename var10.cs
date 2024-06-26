using System.Text;

namespace IntroductoryEducationalPractice;

public static class ArrayHandler
{
    public static string Task1(int[] array)
    {
        int positiveRangeStartIndex = -1, negativeRangeStartIndex = -1, currentRangeStartIndex = 0;
        int positiveLength = 0, negativeLength = 0, currentLength = 0;
        int currentRangeSign = (array[0] >= 0) ? 1 : -1;

        for (int i = 0; i < array.Length; i++)
        {
            int currentSign = (array[i] >= 0) ? 1 : -1;

            if (currentSign == currentRangeSign)
            {
                currentLength++;
            }

            if (currentSign != currentRangeSign || i == array.Length - 1)
            {
                switch (currentRangeSign)
                {
                    case 1:
                        if (currentLength > positiveLength)
                        {
                            positiveLength = currentLength;
                            positiveRangeStartIndex = currentRangeStartIndex;
                        }
                        break;
                    case -1:
                        if (currentLength > negativeLength)
                        {
                            negativeLength = currentLength;
                            negativeRangeStartIndex = currentRangeStartIndex;
                        }
                        break;
                }

                currentRangeSign = currentSign;
                currentRangeStartIndex = i;
                currentLength = 1;
            }
        }

        StringBuilder sb = new();
        if (positiveLength < 2) sb.Append($"Положительная серия: отсутствует ");
        else sb.Append($"Положительная серия: длина - {positiveLength}, начало - {positiveRangeStartIndex}");
        sb.Append(Environment.NewLine);
        if (negativeLength < 2) sb.Append($"Отрицательная серия: отсутствует ");
        else sb.Append($"Отрицательная серия: длина - {negativeLength}, начало - {negativeRangeStartIndex}");

        return sb.ToString();
    }

    public static string Task2(int[] array)
    {
        return "";
    }

    public static string Task3(int[] array)
    {
        return "";
    }

    public static string Task4(int[] array)
    {
        return "";
    }

    public static string Task5(int[,] array)
    {
        int firstEvenRowIndex = -1, lastOddRowIndex = -1;
        string differenceBetweenRows;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (firstEvenRowIndex == -1 && array[i, j] % 2 == 0) firstEvenRowIndex = i;
                if (array[i, j] % 2 == 1) lastOddRowIndex = i;
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < array.GetLength(1); i++)
        {
            sb.Append(array[firstEvenRowIndex, i] - array[lastOddRowIndex, i]);
            sb.Append(' ');
        }
        sb.Append(Environment.NewLine);
        differenceBetweenRows = sb.ToString();
        sb.Clear();

        bool withEvenNegative;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            withEvenNegative = false;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] % 2 == 0 && array[i, j] < 0) withEvenNegative = true;
                sb.Append(array[i, j]);
                sb.Append(' ');
            }
            sb.Append(Environment.NewLine);
            if (withEvenNegative) sb.Append(differenceBetweenRows);
        }

        return sb.ToString();
    }

    public static string Task6(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int n = 2 * (rows + cols - 2); 

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                (int currentRow, int currentCol) = GetPerimeterIndex(j, rows, cols);
                (int nextRow, int nextCol) = GetPerimeterIndex(j + 1, rows, cols);

                if (array[currentRow, currentCol] < array[nextRow, nextCol])
                {
                    int temp = array[currentRow, currentCol];
                    array[currentRow, currentCol] = array[nextRow, nextCol];
                    array[nextRow, nextCol] = temp;
                }
            }
        }

        StringBuilder sb = new();

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sb.Append(array[i, j]);
                sb.Append(' ');
            }
            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }

    private static (int, int) GetPerimeterIndex(int index, int rows, int cols)
    {
        if (index < cols) return (0, index);
        else if (index < cols + rows - 1) return (index - cols + 1, cols - 1);
        else if (index < 2 * cols + rows - 2) return (rows - 1, 2 * cols + rows - 3 - index);
        else return (2 * (rows + cols - 2) - index, 0);
    }
}
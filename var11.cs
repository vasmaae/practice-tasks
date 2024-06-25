//Будет топ, если всё работает так как надо Эгову

//Номер 3
int counter = 0;
for (int i = 0; i < _sizeColumns - 1; i++)
{
    if (array1d[i] % 2 == 0)
    {
        if (array1d[i + 1] % 2 == 0)
        {
            counter++;
            continue;
        }
        if (counter >= 1)
        {
            int startPoint = i - counter;
            for (int j = _sizeColumns - 1; j > startPoint + counter; j--) //тут можно до startPoint + counter + 1, там типо
                                                                          //цепляет последний элемент серии, но он всё равно потом затирается
            {
                array1d[j] = array1d[j - 1];
            }
            int temp = array1d[startPoint];
            array1d[startPoint + counter + 1] = temp;
            i++;
            counter = 0;
        }
    }
    else
    {
        if (array1d[i + 1] % 2 != 0)
        {
            counter++;
            continue;
        }
        if (counter >= 1)
        {
            int startPoint = i - counter;
            for (int j = _sizeColumns - 1; j > startPoint + counter; j--)
            {
                array1d[j] = array1d[j - 1];
            }
            int temp = array1d[startPoint];
            array1d[startPoint + counter + 1] = temp;
            i++;
            counter = 0;
        }
    }
}

//Номер 4
int counter = 0;
for (int i = _sizeColumns - 1; i > 0; i--)
{
    if (array1d[i] >= 0)
    {
        if (array1d[i - 1] >= 0)
        {
            counter++;
        }
        else
        {
            if (counter >= 1)
            {
                int temp = counter;
                while (counter >= 0)
                {
                    for (int j = i; j < _sizeColumns - 1; j++)
                    {
                        array1d[j] = array1d[j + 1];
                    }
                    counter--;
                }
                _sizeColumns -= temp + 1;

                break;
            }
        }
    }
    else
    {
        if (array1d[i - 1] < 0)
        {
            counter++;
        }
        else
        {
            if (counter >= 1)
            {
                int temp = counter;
                while (counter >= 0)
                {
                    for (int j = i; j < _sizeColumns - 1; j++)
                    {
                        array1d[j] = array1d[j + 1];
                    }
                    counter--;
                }
                _sizeColumns -= temp + 1;

                break;
            }
        }
    }
}
if (counter >= 1)
{
    MessageBox.Show("Только одна серия");
    return;
}


//Номер 5

//оно вроде работает, см пометку ниже
int first = -1;
int second = -1;
for (int j = 0; j < _sizeColumns; j++)
{
    for (int i = 0; i < _sizeRows; i++)
    {
        if (array2d[i, j] >= 0 && first == -1)
        {
            first = j;
        }
        if (array2d[_sizeRows - 1 - i, _sizeColumns - 1 - j] < 0 && second == -1)
        {
            second = _sizeColumns - 1 - j;
        }
    }
    if (second != -1 && first != -1)
    {
        break;
    }
}
for (int j = 0; j < _sizeColumns; j++)
{
    int counter = 0;
    for (int i = 0; i < _sizeRows; i++)
    {
        if (array2d[i, j] % 2 == 0)
        {
            counter++;
        }
    }
    if (counter > 3)
    {
        _sizeColumns++;
        if (j < first)
            first++;
        if (j < second)
            second++;

        for (int d = _sizeColumns - 1; d > j; d--)
        {
            for (int k = 0; k < _sizeRows; k++)
            {
                array2d[k, d] = array2d[k, d - 1];


            }
        }
        for (int k = 0; k < _sizeRows; k++)
        {
            if (j != _sizeColumns) //вроде и без этого работает
                array2d[k, j + 1] = Math.Abs(array2d[k, second]) + Math.Abs(array2d[k, first]);

        }
        j++;
    }
}
//номер 1
/// <summary>
/// Класс "Диван"
/// </summary>
public class Sofa
{
    private int? _length;
    public int? Length
    {
        get => _length;
        set
        {
            if (value > 0)
                _length = value;
        }
    }
    /// <summary>
    /// Закрытое поле ширина
    /// </summary>
    private int? _width;
    /// <summary>
    /// Свойство для получения и установки значение ширины
    /// </summary>
    public int? Width
    {
        get => _width;
        set
        {
            if (value > 0)
                _width = value;
        }
    }
    /// <summary>
    /// Закрытое поле высота
    /// </summary>
    private int? _height;
    public int? Height
    {
        get => _height;
        set
        {
            if (value > 0)
                _height = value;
        }
    }
    /// <summary>
    /// Закрытое поле материал отделки (гугл переводчик так сказал)
    /// </summary>
    private string? _finishing;
    public string? Finishing
    {
        get => _finishing;
        set
        {
            if (!(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)))
                _finishing = value;
        }
    }
    /// <summary>
    /// Название модели
    /// </summary>
    private string? _name;
    public string? Name
    {
        get => _name;
        set
        {
            if (!(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)))
                _name = value;
        }
    }
    /// <summary>
    /// Подлокотники
    /// </summary>
    private bool _armrests;
    public bool Armrests
    {
        get => _armrests;
        set
        {
            _armrests = value;
        }
    }
    /// <summary>
    /// Раскладывается или нет
    /// </summary>
    private bool _mechanism;
    public bool Mechanism
    {
        get => _mechanism;
        set
        {
            _mechanism = value;
        }
    }
}

//Номер 2

public abstract class AbstractFigure
{
    protected int _x;
    protected int _y;
    protected int _width;
    protected int _height;

    public AbstractFigure(int x, int y, int width, int height)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height; 
    }
}

public interface IPaintMethod
{
    public void Draw(Graphics g);
}

public class FilledSquare : AbstractFigure, IPaintMethod
{
    public FilledSquare(int x, int y, int width, int height) : base (x, y, width, height)
    {

    }
    public void Draw(Graphics g)
    {
        Random random = new();
        Brush brush = new SolidBrush(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
        g.FillRectangle(brush, new Rectangle(_x, _y, _width, _height));
    }
}

public class Oval : AbstractFigure, IPaintMethod
{
    public Oval(int x, int y, int width, int height) : base(x, y, width, height)
    {
        
    }
    public void Draw(Graphics g)
    {
        Random random = new ();
        Pen pen = new (Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), 4f);
        g.DrawEllipse(pen, new Rectangle(_x, _y, _width, _height));
    }
}

private void button1_Click(object sender, EventArgs e)
{
    Random random = new Random();
    IPaintMethod paint;
    //в лабах ещё Bitmap использовали, но так тоже работает )
    Graphics graphics = pictureBox3.CreateGraphics();
    if (checkBox1.Checked) //можно как угодно выбирать что
    {
        paint = new Oval(random.Next(0, 100), random.Next(0, 100), random.Next(0, 100), random.Next(0, 100));
        paint.Draw(graphics);
        return;
    }
    paint = new FilledSquare(random.Next(0, 100), random.Next(0, 100), random.Next(0, 100), random.Next(0, 100));
    paint.Draw(graphics);
}

//Номер 3
//версия 1
public class Parameter<T>
    where T : struct
{
    public static T Multiplication (T first, T second)
    {
        dynamic f = first;
        dynamic s = second;
        return (T) (f * s);
    }
}
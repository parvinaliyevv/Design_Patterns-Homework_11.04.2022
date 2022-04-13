namespace MediatorMemento;

public interface ISnapshoot
{
    void Restore();
}

public class TextEditor
{
    public class Snapshoot: ISnapshoot
    {
        private readonly TextEditor _originator;


        private readonly StringBuilder _text;

        private readonly ConsoleColor _color;

        private readonly int _cursorPosition;


        public Snapshoot(TextEditor originator, StringBuilder text, ConsoleColor color, int cursorPosition)
        {
            _originator = originator;

            _text = new(text.ToString());
            _color = color;
            _cursorPosition = cursorPosition;
        }


        public void Restore()
        {
            _originator._Text = new(_text.ToString());
            _originator._Color = _color;
            _originator._CursorPosition = _cursorPosition;
        }
    }


    private StringBuilder _Text { get; set; }

    private ConsoleColor _Color { get; set; }

    private int _CursorPosition { get; set; }


    public TextEditor(ConsoleColor color)
    {
        _Text = new(string.Empty);
        _Color = color;
        _CursorPosition = default;
    }


    public Snapshoot MakeSnapshoot() => new Snapshoot(this, _Text, _Color, _CursorPosition);
}

public class CareTaker
{
    private Stack<ISnapshoot> _mementos;

    public TextEditor Originator { get; set; }


    public CareTaker()
    {
        Originator = new(ConsoleColor.DarkCyan);
        _mementos = new();
    }


    public void Undo() => _mementos.Pop()?.Restore();
    public void MakeSnapshoot() => _mementos.Push(Originator.MakeSnapshoot());
}

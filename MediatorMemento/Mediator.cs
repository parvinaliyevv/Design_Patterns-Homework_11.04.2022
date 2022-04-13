namespace MediatorMemento;

public interface IMediator
{
    void Notify(object sender, EventArgs e);
}

public class AuthenticationMediator : IMediator
{
    private string Title { get; set; }
    private bool LoginOrRegister { get; set; }

    private TextBox LoginUsername { get; set; }
    private TextBox LoginPassword { get; set; }

    private TextBox RegUsername { get; set; }
    private TextBox RegPassword { get; set; }
    private TextBox RegEmail { get; set; }

    private Button Next { get; set; }
    private Button Cancel { get; set; }

    private CheckBox RememberMe { get; set; }


    public AuthenticationMediator()
    {
        Title = "Authentication";
        LoginOrRegister = false;

        LoginUsername = new(this);
        LoginPassword = new(this);

        RegUsername = new(this);
        RegPassword = new(this);
        RegEmail = new(this);

        Next = new(this);
        Cancel = new(this);

        RememberMe = new(this);
    }


    public void Notify(object sender, EventArgs e)
    {
        if (sender == Next) { }
        else if (sender == Cancel) { }
    }
}


public abstract class UIElement { }
public abstract class Component : UIElement
{
    private IMediator _mediator { get; set; }

    protected Component(IMediator dialog) => _mediator = dialog;

    public void Click() => _mediator.Notify(this, new EventArgs());
}
public abstract class ButtonBase : Component
{
    protected ButtonBase(IMediator dialog) : base(dialog) { }
}
public abstract class TextBoxBase : Component
{
    protected TextBoxBase(IMediator dialog) : base(dialog) { }
}

public class Button : ButtonBase
{
    public Button(IMediator dialog) : base(dialog) { }
}
public class CheckBox : ButtonBase
{
    public CheckBox(IMediator dialog) : base(dialog) { }
}
public class TextBox : TextBoxBase
{
    public TextBox(IMediator dialog) : base(dialog) { }
}

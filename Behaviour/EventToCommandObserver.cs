using System.Reflection;
using System.Windows.Input;


namespace Todo.me.Behaviour;
// https://stackoverflow.com/questions/64516514/how-to-call-command-from-datatemplate-entry-textchanged-event-in-xamarin-forms
public class EventToCommandObserver : ContentView
{
    public static readonly BindableProperty EventNameProperty = BindableProperty.CreateAttached("EventName",
        typeof(string), typeof(Microsoft.Maui.Controls.View), null, propertyChanged: OnEventNameChanged);

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandObserver));

    public static readonly BindableProperty CommandParameterProperty =
        BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(EventToCommandObserver));

    public static readonly BindableProperty EventArgsConverterProperty =
        BindableProperty.Create(nameof(EventArgsConverter), typeof(IValueConverter),
            typeof(EventToCommandObserver));

    public ICommand Command
    {
        get
        {
            return (ICommand)this.GetValue(CommandProperty);
        }
        set
        {
            this.SetValue(CommandProperty, value);
        }
    }

    public object CommandParameter
    {
        get
        {
            return this.GetValue(CommandParameterProperty);
        }
        set
        {
            this.SetValue(CommandParameterProperty, value);
        }
    }

    public IValueConverter EventArgsConverter
    {
        get
        {
            return (IValueConverter)this.GetValue(EventArgsConverterProperty);
        }
        set
        {
            this.SetValue(EventArgsConverterProperty, value);
        }
    }

    public static string GetEventName(BindableObject bindable)
    {
        return (string)bindable.GetValue(EventNameProperty);
    }

    public static void SetEventName(BindableObject bindable, string value)
    {
        bindable.SetValue(EventNameProperty, value);
    }

    private static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
    {
        DeregisterEvent(oldValue as string, bindable);

        RegisterEvent(newValue as string, bindable);
    }

    private static void RegisterEvent(string name, object associatedObject)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        EventInfo eventInfo = associatedObject.GetType().GetRuntimeEvent(name);

        if (eventInfo == null)
        {
            throw new ArgumentException($"EventToCommandBehavior: Can't register the '{name}' event.");
        }

        MethodInfo methodInfo = typeof(EventToCommandObserver).GetTypeInfo().GetDeclaredMethod("OnEvent");

        Delegate eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType);

        eventInfo.AddEventHandler(associatedObject, eventHandler);
    }

    private static void DeregisterEvent(string name, object associatedObject)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return;
        }

        EventInfo eventInfo = associatedObject.GetType().GetRuntimeEvent(name);

        if (eventInfo == null)
        {
            throw new ArgumentException($"EventToCommandBehavior: Can't de-register the '{name}' event.");
        }

        MethodInfo methodInfo =
            typeof(EventToCommandObserver).GetTypeInfo().GetDeclaredMethod(nameof(OnEvent));

        Delegate eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType);

        eventInfo.RemoveEventHandler(associatedObject, eventHandler);
    }

    private static void OnEvent(object sender, object eventArgs)
    {
        if (((Microsoft.Maui.Controls.View)sender).Parent is EventToCommandObserver commandView)
        {
            ICommand command = commandView.Command;

            if (command == null)
            {
                return;
            }

            object resolvedParameter;

            if (commandView.CommandParameter != null)
            {
                resolvedParameter = commandView.CommandParameter;
            }
            else if (commandView.EventArgsConverter != null)
            {
                resolvedParameter =
                    commandView.EventArgsConverter.Convert(eventArgs, typeof(object), null, null);
            }
            else
            {
                resolvedParameter = eventArgs;
            }

            if (command.CanExecute(resolvedParameter))
            {
                command.Execute(resolvedParameter);
            }
        }
    }
}

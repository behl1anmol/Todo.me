namespace Todo.me.View.Converters;
public class ValueToColorConverter :IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        switch (value)
        {
            case 1:
                return Color.FromArgb("#c8e6fe");
            case 2:
                return Color.FromArgb("#fed8b1");
            case 3:
                return Color.FromArgb("#ffae42");
            case 4:
                return Color.FromArgb("#90EE90");
            default:
                return Color.FromArgb("#ffffff");
        }

        
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }


}

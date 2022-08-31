namespace Todo.me.View.Converters;
public class ValueToColorConverter :IValueConverter
{

    public static object GetColor(int value)
    {
        switch (value)
        {
            case 1:
                return Color.FromArgb("#c8e6fe");
            case 2:
                return Color.FromArgb("#fed8b1");
            case 3:
                return Color.FromArgb("#FFEEAF");
            case 4:
                return Color.FromArgb("#E6D2AA");
            case 5:
                return Color.FromArgb("#90B77D");
            case 6:
                return Color.FromArgb("#FFE898");
            case 7:
                return Color.FromArgb("#AFB4FF");
            case 8:
                return Color.FromArgb("#FAD9A1");
            case 9:
                return Color.FromArgb("#A8A4CE");
            case 10:
                return Color.FromArgb("#B7D3DF");
            default:
                return Color.FromArgb("#ffffff");
        }
    }


    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        switch (value)
        {
            case 1:
                return Color.FromArgb("#c8e6fe");
            case 2:
                return Color.FromArgb("#fed8b1");
            case 3:
                return Color.FromArgb("#FFEEAF");
            case 4:
                return Color.FromArgb("#E6D2AA");
            case 5:
                return Color.FromArgb("#90B77D");
            case 6:
                return Color.FromArgb("#FFE898");
            case 7:
                return Color.FromArgb("#AFB4FF");
            case 8:
                return Color.FromArgb("#FAD9A1");
            case 9:
                return Color.FromArgb("#A8A4CE");
            case 10:
                return Color.FromArgb("#B7D3DF");
            default:
                return Color.FromArgb("#ffffff");
        }

        
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }


}

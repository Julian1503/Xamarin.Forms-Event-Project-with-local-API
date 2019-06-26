namespace SmartEvent.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;
    public class CatitalizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (string)value;
            var cadena = valor.Substring(0,1).ToUpper();
            return $"{cadena + valor.Substring(1).ToLower()}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = (string)value;
            return $"{valor.ToLower()}";
        }
    }
}

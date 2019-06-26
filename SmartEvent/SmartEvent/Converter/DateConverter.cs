using SmartEvent.Model;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SmartEvent.Converter
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valor = ((ProgramationModel)value);
           
            return $"Desde: {valor.FechaDesde.DayOfWeek}, {valor.FechaDesde.ToString("MMMM")} {valor.FechaDesde.Day}" +
                   $"\nHasta: {valor.FechaHasta.DayOfWeek}, {valor.FechaHasta.ToString("MMMM")} {valor.FechaHasta.Day}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

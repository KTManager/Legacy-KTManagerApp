using System;
using System.Globalization;
using Xamarin.Forms;

namespace KillTeam.Services
{
    public class IndexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listview = parameter as ListView;
            var index = 0;
            var itemsEnumerator = listview.ItemsSource.GetEnumerator();
            while (itemsEnumerator.MoveNext())
            {
                if (itemsEnumerator.Current.Equals(value)) break;
                index++;
            }

            if (index % 2 == 0)
                return Color.LightGray;
            return listview.BackgroundColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
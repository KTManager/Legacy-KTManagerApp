using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace KillTeam.Controls
{
    public class NumericPicker : Picker
    {
        private int _minimum = 0;
        private int _default = 0;
        private int _maximum = 100;

        public int Minimum
        {
            get => _minimum;
            set
            {
                if (value > Maximum) value = Maximum;

                _minimum = value;

                InitializeItems();
            }
        }

        public int Default
        {
            get => _default;
            set
            {
                if (value < Minimum) value = Minimum;
                if (value > Maximum) value = Maximum;

                _default = value;
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                if (value < Minimum) value = Minimum;

                _maximum = value;

                InitializeItems();
            }
        }

        public int SelectedValue
        {
            get => (int)SelectedItem;
            set => SelectedItem = Items.First(x => int.TryParse(x, out var item) && item == value);
        }

        public NumericPicker()
        {
            ItemsSource = new ObservableCollection<int>();

            InitializeItems();
        }

        private void InitializeItems()
        {
            ItemsSource.Clear();
            for (var i = Minimum; i <= Maximum; i++)
            {
                ItemsSource.Add(i);
            }
        }
    }
}

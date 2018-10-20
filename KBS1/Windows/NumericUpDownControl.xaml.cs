using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace KBS1.Windows
{
    public partial class NumericUpDownControl
    {
        public delegate void ValueChangedEventHandler(object source, PropertyChangedEventArgs e);

        private int _maxValue = int.MaxValue;
        private int _minValue = int.MinValue;

        private int _value;


        public NumericUpDownControl()
        {
            InitializeComponent();
        }

        public int Value
        {
            get => _value;
            set
            {
                if (value < MinValue) _value = MinValue;
                else if (value > MaxValue) _value = MaxValue;
                else _value = value;

                TextBoxValue.Text = _value.ToString();
                ValueChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public int MinValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                if (Value < value) Value = value;
            }
        }

        public int MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                if (Value > value) Value = value;
            }
        }

        public int StepSize { get; set; } = 1;

        public event ValueChangedEventHandler ValueChanged;

        private int VerifyValue(string value)
        {
            return int.TryParse(value, out var output) ? output : Value;
        }


        private void TextBoxValue_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Value = VerifyValue(((TextBox) sender).Text);
        }

        private void ButtonUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (Value + StepSize > MaxValue) return;
            Value += StepSize;
        }

        private void ButtonDown_OnClick(object sender, RoutedEventArgs e)
        {
            if (Value - StepSize < MinValue) return;
            Value -= StepSize;
        }
    }
}
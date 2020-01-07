using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NumericUpDownControl : ContentView
    {
        #region Depedency Properties

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(NumericUpDownControl), Convert.ToDouble(25));

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(NumericUpDownControl), defaultValue: Color.Black);

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(NumericUpDownControl), defaultValue: null);

        public static readonly BindableProperty MinimumProperty = BindableProperty.Create(nameof(Minimum), typeof(double), typeof(NumericUpDownControl), Convert.ToDouble(-5));

        public static readonly BindableProperty MaximumProperty = BindableProperty.Create(nameof(Maximum), typeof(double), typeof(NumericUpDownControl), Convert.ToDouble(999));

        public static readonly BindableProperty IncrementIconProperty = BindableProperty.Create(nameof(IncrementIcon), typeof(string), typeof(NumericUpDownControl), defaultValue: "&#xe726;");

        public static readonly BindableProperty DecrementIconProperty = BindableProperty.Create(nameof(DecrementIcon), typeof(string), typeof(NumericUpDownControl), defaultValue: "&#xe715;");

        public static readonly BindableProperty WatermarkProperty = BindableProperty.Create(nameof(Watermark), typeof(string), typeof(NumericUpDownControl), "Enter Number");

        public static readonly BindableProperty WatermarkColorProperty = BindableProperty.Create(nameof(WatermarkColor), typeof(Color), typeof(NumericUpDownControl), defaultValue: Color.Gray);

        public static readonly BindableProperty FontAttributeProperty = BindableProperty.Create(nameof(FontAttribute), typeof(FontAttributes), typeof(NumericUpDownControl));

        public static readonly BindableProperty MaximumDigitsProperty = BindableProperty.Create(nameof(MaximumDigits), typeof(int), typeof(NumericUpDownControl), 5);

        public static readonly BindableProperty IsEditableProperty = BindableProperty.Create(nameof(IsEditable), typeof(bool), typeof(NumericUpDownControl), defaultValue: true);

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(NumericUpDownControl), defaultValue: "{OnPlatform iOS=Sync FontIcons, Android=Sync FontIcons.ttf#, UWP=Sync FontIcons.ttf#Sync FontIcons}");

        public static readonly BindableProperty StepValueProperty = BindableProperty.Create(nameof(StepValue), typeof(double), typeof(NumericUpDownControl),Convert.ToDouble(2));

        public static readonly BindableProperty FormatStringProperty = BindableProperty.Create(nameof(FormatString), typeof(string), typeof(NumericUpDownControl));

        public static readonly BindableProperty ControlbackgroundcolorProperty = BindableProperty.Create(nameof(Controlbackgroundcolor), typeof(Color), typeof(NumericUpDownControl));

        public static readonly BindableProperty ControlMarginProperty = BindableProperty.Create(nameof(ControlMargin), typeof(double), typeof(NumericUpDownControl));

        #endregion

        #region Constructor
        public NumericUpDownControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        public string Value
        {
            get
            {
                return (string)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        public double Minimum
        {
            get
            {
                return (double)GetValue(MinimumProperty);
            }
            set
            {
                SetValue(MinimumProperty, value);
            }
        }

        public double Maximum
        {
            get
            {
                return (double)GetValue(MaximumProperty);
            }
            set
            {
                SetValue(MaximumProperty, value);
            }
        }

        public string IncrementIcon
        {
            get
            {
                return (string)GetValue(IncrementIconProperty);
            }
            set
            {
                SetValue(IncrementIconProperty, value);
            }
        }

        public string DecrementIcon
        {
            get
            {
                return (string)GetValue(DecrementIconProperty);
            }
            set
            {
                SetValue(DecrementIconProperty, value);
            }
        }

        public string Watermark
        {
            get
            {
                return (string)GetValue(WatermarkProperty);
            }
            set
            {
                SetValue(WatermarkProperty, value);
            }
        }

        public Color WatermarkColor
        {
            get
            {
                return (Color)GetValue(WatermarkColorProperty);
            }
            set
            {
                SetValue(WatermarkColorProperty, value);
            }
        }

        public FontAttributes FontAttribute
        {
            get
            {
                return (FontAttributes)GetValue(FontAttributeProperty);
            }
            set
            {
                SetValue(FontAttributeProperty, value);
            }
        }

        public int MaximumDigits
        {
            get
            {
                return (int)GetValue(MaximumDigitsProperty);
            }
            set
            {
                SetValue(MaximumDigitsProperty, value);
            }
        }

        public bool IsEditable
        {
            get
            {
                return (bool)GetValue(IsEditableProperty);
            }
            set
            {
                SetValue(IsEditableProperty, value);
            }
        }

        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        public double StepValue
        {
            get
            {
                return (double)GetValue(StepValueProperty);
            }
            set
            {
                SetValue(StepValueProperty, value);
            }
        }

        public string FormatString
        {
            get
            {
                return (string)GetValue(FormatStringProperty);
            }
            set
            {
                SetValue(FormatStringProperty, value);
            }
        }

        public Color Controlbackgroundcolor
        {
            get
            {
                return (Color)GetValue(ControlbackgroundcolorProperty);
            }
            set
            {
                SetValue(ControlbackgroundcolorProperty, value);
            }
        }

        public double ControlMargin
        {
            get
            {
                return (double)GetValue(ControlMarginProperty);
            }
            set
            {
                SetValue(ControlMarginProperty, value);
            }
        }
        #endregion

        #region Methods
        private void TapGestureRecognizer_PlusButton(object sender, EventArgs e)
        {
            double.TryParse(string.IsNullOrEmpty(Value) ? Minimum.ToString() : Value, out double editvalue);
            if (editvalue < Minimum)
            {
                editvalue = Minimum;
            }
            editvalue += StepValue;

            if (editvalue > Maximum)
            {
                editvalue = Maximum;
            }
            Value = editvalue.ToString(FormatString);
        }

        private void TapGestureRecognizer_MinusButton(object sender, EventArgs e)
        {
            double.TryParse(string.IsNullOrEmpty(Value) ? Minimum.ToString() : Value, out double editvalue);
            editvalue -= StepValue;
            if (editvalue < Minimum)
            {
                editvalue = Minimum;
            }
            Value = editvalue.ToString(FormatString);
        }

        private void EditorValue_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Editor;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                decimal editvalue = Convert.ToDecimal(entry.Text);
                if (editvalue < Convert.ToDecimal(Minimum))
                {
                    editvalue = Convert.ToDecimal(Minimum);
                }
                entry.Text = editvalue.ToString();
            }
        }

        private void EditorValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                if (e.NewTextValue == ".")
                {
                    return;
                }

                if (!string.IsNullOrEmpty(e.OldTextValue) && e.OldTextValue.IndexOf(".") < 0 && e.NewTextValue.IndexOf(".") == e.NewTextValue.Length - 1)
                {
                    return;
                }

                else if (e.NewTextValue.Contains(".") && e.NewTextValue.Split('.')[1].Length > 2)
                {
                    ((Editor)sender).Text = e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }

                else if (!decimal.TryParse(e.NewTextValue, out _))
                {
                    ((Editor)sender).Text = e.NewTextValue;
                }

                else if (Convert.ToDecimal(e.NewTextValue) > Convert.ToDecimal(Maximum))
                {
                    ((Editor)sender).Text = Convert.ToString(Maximum);
                }
                else
                {
                    string str = ((Editor)sender).Text;
                    double dbl = Convert.ToDouble(str);
                    ((Editor)sender).Text = dbl.ToString(FormatString);
                }
            }
        }
        #endregion
    }
}
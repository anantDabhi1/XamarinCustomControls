using System;
using Xamarin.Forms;

namespace CustomControl
{
    public class ProgressBar : TemplatedView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ProgressBar), null, BindingMode.TwoWay);
      

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }


    }
}

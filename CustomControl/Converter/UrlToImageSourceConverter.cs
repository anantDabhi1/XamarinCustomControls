using System;
using System.Globalization;
using Xamarin.Forms;

namespace CustomControl.Converter
{
    /// <summary>
    /// convert string into image source
    /// </summary>
    /// <seealso cref="Xamarin.Forms.IValueConverter" />
    class UrlToImageSourceConverter : IValueConverter
    {
        /// <summary>
        /// Implement this method to convert <paramref name="value" /> to <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        /// <returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertToImageSource(System.Convert.ToString(value));
        }
        /// <summary>
        /// Implement this method to convert <paramref name="value" /> back from <paramref name="targetType" /> by using <paramref name="parameter" /> and <paramref name="culture" />.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type to which to convert the value.</param>
        /// <param name="parameter">A parameter to use during the conversion.</param>
        /// <param name="culture">The culture to use during the conversion.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
        /// <summary>
        /// Converts to image source.
        /// </summary>
        /// <param name="fileName">Name of the image file.</param>
        /// <returns>Image Source object</returns>
        private ImageSource ConvertToImageSource(string fileName)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return ImageSource.FromFile($"Images/{fileName}");

                case Device.Android:
                    return ImageSource.FromFile(fileName);
                case Device.UWP:
                    return ImageSource.FromFile($"Images/{fileName}");
            }
            return null;
        }
    }
}

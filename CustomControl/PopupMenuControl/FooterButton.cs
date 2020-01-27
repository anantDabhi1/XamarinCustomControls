using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CustomControl.PopupMenuControl
{
    public class FooterButton
    {
        #region Private Variables
        private bool _isEnable = true;
        #endregion

        #region Properties

        public string Name { get; set; }

        public string ImageURL { get; set; }

        /// <summary>
        /// Gets the opacity of image of toolbar.
        /// </summary>
        /// <value>
        /// The opacity.
        /// </value>
        public double Opacity
        {
            get
            {
                return _isEnable ? 1 : 0.4;
            }
        }

        /// <summary>
        /// Gets or sets a value of image is enable or not in toolbar.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enable; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnable
        {
            get { return _isEnable; }
            set
            {
                if (SetProperty(ref _isEnable, value))
                {
                    OnPropertyChanged(nameof(Opacity));
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore">The backing store.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="onChanged">The on changed.</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
                });
            }
            catch (Exception)
            {
            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CustomControlView.ViewModel
{
   public abstract class BaseViewModel: INotifyPropertyChanged
    {

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

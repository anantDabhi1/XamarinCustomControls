﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CustomControlView.ViewModel
{
   public abstract class BaseViewModel: INotifyPropertyChanged
    {
        #region Methods
        // <summary>
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

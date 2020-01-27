using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControl.PopupMenuControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FooterToolbar : ContentView
    {
        #region Private
        private PopupMenu Popup;
        #endregion

        #region Event Delegates
        public delegate void ItemSelectedDelegate(string item);
        public event ItemSelectedDelegate OnItemSelected;
        #endregion


        #region Properties
        public List<string> Menuitems
        {
            get { return (List<string>)GetValue(MenuitemsProperty); }
            set { SetValue(MenuitemsProperty, value); }
        }
        public List<FooterButton> ButtonList
        {
            get { return (List<FooterButton>)GetValue(ButtonListProperty); }
            set { SetValue(ButtonListProperty, value); }
        }
        #endregion

        #region Depedency Properties
        public static readonly BindableProperty MenuitemsProperty = BindableProperty.Create(nameof(Menuitems), typeof(List<string>), typeof(FooterToolbar));
        public static readonly BindableProperty ButtonListProperty = BindableProperty.Create(nameof(ButtonList), typeof(List<FooterButton>), typeof(FooterToolbar), null);
        #endregion

        #region Constructor
        public FooterToolbar()
        {
            InitializeComponent();

            Popup = new PopupMenu() { BindingContext = this };
            Popup.SetBinding(PopupMenu.ItemsSourceProperty, "Menuitems");
            Popup.OnItemSelected += Popup_OnItemSelected;
        }
        #endregion

        #region Events

        private void Popup_OnItemSelected(string item)
        {
            OnItemSelected?.Invoke(item);
        }

        void ShowPopup_Clicked(object sender, EventArgs e) => Popup?.ShowPopup(sender as View);
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var collectionView = sender as CollectionView;
            collectionView.SelectionChanged -= CollectionView_SelectionChanged;
            var footerButton = collectionView.SelectedItem as FooterButton;
            if (footerButton != null && footerButton.IsEnable)
            {
                OnItemSelected?.Invoke(footerButton.Name);
            }
            //App.Current.Dispatcher.BeginInvokeOnMainThread(() =>
            //{
            //    collectionView.SelectedItem = null;
            //    collectionView.SelectionChanged += CollectionView_SelectionChanged;
            //});

        }
        #endregion
    }
}
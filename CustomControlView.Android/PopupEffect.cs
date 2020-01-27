using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CustomControlView.Droid")]
[assembly: ExportEffect(typeof(CustomControlView.Droid.PopupEffect), "PopupEffect")]
namespace CustomControlView.Droid
{
    public class PopupEffect : PlatformEffect
    {
        Android.Widget.PopupMenu ToggleMenu;
        CustomControl.PopupMenuControl.PopupMenu.InternalPopupEffect Effect;

        protected override void OnAttached()
        {
            Effect = (CustomControl.PopupMenuControl.PopupMenu.InternalPopupEffect)Element.Effects.FirstOrDefault(e => e is CustomControl.PopupMenuControl.PopupMenu.InternalPopupEffect);

            if (Effect != null)
                Effect.Parent.OnPopupRequest += OnPopupRequest;

            MessagingCenter.Unsubscribe<string, string>("CustomControl", "ClosePopup");

            if (Control != null || Container != null)
            {
                ToggleMenu = new Android.Widget.PopupMenu(Forms.Context, Control == null ? Container : Control);
                ToggleMenu.MenuItemClick += MenuItemClick;
                MessagingCenter.Subscribe<string, string>("CustomControl", "ClosePopup", (sender, args) =>
                {
                    Xamarin.Forms.Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
                    {
                        ToggleMenu.Dismiss();
                    });
                });
            }

        }
        void OnPopupRequest(Xamarin.Forms.View view)
        {
            // Null Check
            if (Effect.Parent.ItemsSource == null)
                return;

            // Clear Old
            ToggleMenu.Menu.Clear();

            // Add New
            foreach (var item in Effect.Parent.ItemsSource)
                ToggleMenu.Menu.Add(item.ToString());

            // Popup
            ToggleMenu.Show();
        }

        protected override void OnDetached()
        {
            if (ToggleMenu != null)
                ToggleMenu.MenuItemClick -= MenuItemClick;

            if (Effect != null)
                Effect.Parent.OnPopupRequest -= OnPopupRequest;

            MessagingCenter.Unsubscribe<string, string>("CustomControl", "ClosePopup");
        }

        void MenuItemClick(object sender, Android.Widget.PopupMenu.MenuItemClickEventArgs e) => Effect?.Parent.InvokeItemSelected(e.Item.ToString());
    }
}
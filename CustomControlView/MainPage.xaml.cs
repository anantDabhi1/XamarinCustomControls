using CustomControl.ChipsControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomControlView
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<ChipsItem> ItemList
        {
            get;
            set;
        }


        public MainPage()
        {
            InitializeComponent();
            var binding = new ViewModel.MainPageViewModel();
            BindingContext = binding;
        }

        private void OnRatingChanged(object sender, float e)
        {
            customRatingBar.Rating = e;
        }

        /// <summary>
        /// Footers the toolbar on item selected.
        /// </summary>
        /// <param name="item">The item.</param>
        private void FooterToolbar_OnItemSelected(string item)
        {

        }
    }
}

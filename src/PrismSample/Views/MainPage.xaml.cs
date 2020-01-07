using CustomControl.ChipsControl;
using System.Collections.Generic;
using System.ComponentModel;

namespace PrismSample.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {

        public List<ChipsItem> ItemList
        {
            get;
            set;
        }


        public MainPage()
        {
            ItemList = new List<ChipsItem>()
            {
                new ChipsItem{ItemName="One", IsSelected=true },
                new ChipsItem{ItemName="Two", IsSelected=true },
                new ChipsItem{ItemName="Three", IsSelected=false },
                new ChipsItem{ItemName="Four", IsSelected=true },
                new ChipsItem{ItemName="Five", IsSelected=false },
                new ChipsItem{ItemName="Six", IsSelected=true },
                new ChipsItem{ItemName="Seven", IsSelected=false },
                new ChipsItem{ItemName="Eight", IsSelected=true },
                new ChipsItem{ItemName="Nine", IsSelected=true },
                new ChipsItem{ItemName="Ten", IsSelected=true },
                new ChipsItem{ItemName="Eleven", IsSelected=false },
                new ChipsItem{ItemName="Tewlve", IsSelected=true },
                new ChipsItem{ItemName="Thirteen", IsSelected=true },
                new ChipsItem{ItemName="Fourteen", IsSelected=true },
                new ChipsItem{ItemName="Fifteen", IsSelected=false },
            };

            InitializeComponent();

            chipsControl.ItemsSource = ItemList;
        //Xamarin.Forms.ListView.ItemsSourceProperty
        }
    }
}

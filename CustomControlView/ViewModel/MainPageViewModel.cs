using CustomControl.ChipsControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CustomControlView.ViewModel
{
    public class MainPageViewModel :BaseViewModel
    {
        private ObservableCollection<ChipsItem> _itemList;
        public ObservableCollection<ChipsItem> ItemList
        {
            get;
            set;
        }


        public MainPageViewModel()
        {
            ItemList = new ObservableCollection<ChipsItem>()
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

        }

        
    }
}

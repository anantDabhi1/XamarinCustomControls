using CustomControl.ChipsControl;
using CustomControl.PopupMenuControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CustomControlView.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<ChipsItem> _itemList;
        private List<FooterButton> buttonList;
        private List<string> _menuitems;
        private List<string> _toolBarItems;

        public ObservableCollection<ChipsItem> ItemList
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the button list in Footer of page.
        /// </summary>
        /// <value>
        /// The button list.
        /// </value>
        public List<FooterButton> ButtonList
        {
            get
            {
                if (buttonList == null)
                {
                    buttonList = new List<FooterButton>();
                }
                return buttonList;
            }
            set
            {
                SetProperty(ref buttonList, value);
            }
        }

        public List<string> Menuitems
        {
            get
            {
                if (_menuitems == null)
                {
                    _menuitems = new List<string>();
                }
                return _menuitems;
            }
            set
            {
                SetProperty(ref _menuitems, value);
            }
        }

        public List<string> ToolBarItems
        {
            get
            {
                if (_toolBarItems == null)
                {
                    _toolBarItems = new List<string>();
                }
                return _toolBarItems;
            }
            set
            {
                SetProperty(ref _toolBarItems, value);
            }
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
            Menuitems = new List<string> { "Close", "Delete" };
        }


    }
}

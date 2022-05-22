using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;


namespace VisualDataBase.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<TableTabItemViewModel> _tableTabItems;
        public ObservableCollection<TableTabItemViewModel> TableTabItems 
        { 
            get
            {
                return _tableTabItems;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _tableTabItems, value);
            }
        }

        private TableTabItemViewModel _currentTableTabItem;
        public TableTabItemViewModel CurrentTableTabItem
        {
            get
            {
                return _currentTableTabItem;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _currentTableTabItem, value);
            }
        }


        public MainWindowViewModel()
        {
            TableTabItems = new ObservableCollection<TableTabItemViewModel>(AddMainTabs());

            CurrentTableTabItem = TableTabItems[0]; // TEMPORARILY
        }


        private ObservableCollection<TableTabItemViewModel> AddMainTabs()
        {
            return new ObservableCollection<TableTabItemViewModel>()
            {
                new TableTabItemViewModel(TableTypes.Players),
                new TableTabItemViewModel(TableTypes.Seasons),
                new TableTabItemViewModel(TableTypes.PlayersSeasons),
                new TableTabItemViewModel(TableTypes.Nations)
            };
        }

        private int indexPage = 1; // TEMPORARILY
        private void AddTabItemViewModel(string newTabtitle)
        {
            newTabtitle = "Page" + indexPage.ToString(); // TEMPORARILY
            var newTab = new TableTabItemViewModel(newTabtitle);
            TableTabItems.Add(newTab);

            CurrentTableTabItem = newTab;
            
            
            indexPage++; // TEMPORARILY
        }
        private void CloseTabITem(TableTabItemViewModel tab)
        {
            TableTabItems.Remove(tab);

            CurrentTableTabItem = TableTabItems[0]; // TEMPORARILY

        }

    }
}

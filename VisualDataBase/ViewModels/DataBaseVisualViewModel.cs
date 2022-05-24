using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;

namespace VisualDataBase.ViewModels
{
    internal class DataBaseVisualViewModel : ViewModelBase
    {
        public ObservableCollection<TableTabItemViewModel> _tableTabItems;

        private TableTabItemViewModel _currentTableTabItem;

        public ObservableCollection<TableTabItemViewModel> TableTabItems
        {
            get => _tableTabItems;
            set => this.RaiseAndSetIfChanged(ref _tableTabItems, value);
        }

        public TableTabItemViewModel CurrentTableTabItem
        {
            get => _currentTableTabItem;
            set => this.RaiseAndSetIfChanged(ref _currentTableTabItem, value);
        }

        public DataBaseVisualViewModel()
        {
            TableTabItems = new ObservableCollection<TableTabItemViewModel>(AddMainTabs());

            CurrentTableTabItem = TableTabItems[0];
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
    }
}

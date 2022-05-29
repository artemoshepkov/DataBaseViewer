using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

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

            CurrentTableTabItem = TableTabItems.First();
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

        public void AddTabItemViewModel(string newTabtitle, List<object> list)
        {
            var newTab = new TableTabItemViewModel(newTabtitle, list);

            TableTabItems.Add(newTab);

            CurrentTableTabItem = newTab;
        }
    }
}

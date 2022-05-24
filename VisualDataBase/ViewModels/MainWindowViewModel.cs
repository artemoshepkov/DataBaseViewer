using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;


namespace VisualDataBase.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentView;

        private DataBaseVisualViewModel dataBaseVisualView;

        private ManagerSQLRequestsViewModel managerRequestsView;

        ViewModelBase ContentView
        {
            get { return _contentView; }
            set { this.RaiseAndSetIfChanged(ref _contentView, value); }
        }


        public MainWindowViewModel()
        {
            dataBaseVisualView = new DataBaseVisualViewModel();
            managerRequestsView = new ManagerSQLRequestsViewModel();
            ContentView = dataBaseVisualView;
        }


        public void ChangeToDataBaseVisual()
        {
            ContentView = dataBaseVisualView;
        }

        public void ChangeToManagerRequests()
        {
            ContentView = managerRequestsView;
        }
    }
}

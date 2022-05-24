using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;
using VisualDataBase.Models;

namespace VisualDataBase.ViewModels
{
    public enum TableTypes
    {
        Seasons = 0,
        Nations,
        Players,
        PlayersSeasons,
        Request
    }

    public class TableTabItemViewModel : ViewModelBase
    {
        private ObservableCollection<object> _content;

        private object _currenItemDataGrid;


        public TableTypes TableType { get; }

        public bool IsRequestTable { get; }

        public bool IsStaticTable { get; }

        public string Title { get; }

        public dynamic DBContent { get; set; }

        public ObservableCollection<object> Content
        {
            get
            {
                return _content;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _content, value);
            }
        }

        public object CurrenItemDataGrid
        {
            get
            {
                return _currenItemDataGrid;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _currenItemDataGrid, value);
            }
        }

        ReactiveCommand<Unit, Unit> AddRecordCommand { get; }

        ReactiveCommand<Unit, Unit> RemoveRecordCommand { get; }

        ReactiveCommand<Unit, Unit> SaveRecordsToDBCommand { get; }


        public TableTabItemViewModel(TableTypes table)
        {
            Title = table.ToString();

            TableType = table;

            IsRequestTable = false; 
            IsStaticTable = true;

            InitContent();

            AddRecordCommand = ReactiveCommand.Create(AddRecord);
            RemoveRecordCommand = ReactiveCommand.Create(RemoveRecord);
            SaveRecordsToDBCommand = ReactiveCommand.Create(SaveRecordsToDB);
        }

        public TableTabItemViewModel(string title)
        {
            Title = title;

            IsRequestTable = true;
            IsStaticTable = false;

            TableType = TableTypes.Request;
        }

        private void InitContent()
        {
            try
            {
                switch (TableType)
                {
                    case TableTypes.Seasons:
                        DBContent = MyDataBaseContext.db.Seasons;
                        break;
                    case TableTypes.Nations:
                        DBContent = MyDataBaseContext.db.Nations;
                        break;
                    case TableTypes.Players:
                        DBContent = MyDataBaseContext.db.Players;
                        break;
                    case TableTypes.PlayersSeasons:
                        DBContent = MyDataBaseContext.db.PlayersSeasons;
                        break;
                }

                Content = new ObservableCollection<object>(DBContent);
                Content.CollectionChanged += ContentOnCollectionChanged;
            }
            catch
            {

            }
        }

        private void AddRecord()
        {
            switch (TableType)
            {
                case TableTypes.Seasons:
                    Content.Add(new Season { Title = "NewField" });
                    break;
                case TableTypes.Nations:
                    Content.Add(new Nation { Title = "NewField" });
                    break;
                case TableTypes.Players:
                    Content.Add(new Player { Fullname = "NewField" });
                    break;
                case TableTypes.PlayersSeasons:
                    Content.Add(new PlayersSeason { });
                    break;
            }
        }

        public void RemoveRecord()
        {
            Content.Remove(CurrenItemDataGrid);
        }

        private void SaveRecordsToDB()
        {
            MyDataBaseContext.SaveChanges();
        }
    
        private void ContentOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    switch (TableType)
                    {
                        case TableTypes.Seasons:
                            DBContent.Add(e.NewItems[0] as Season);
                            break;
                        case TableTypes.Nations:
                            DBContent.Add(e.NewItems[0] as Nation);
                            break;
                        case TableTypes.Players:
                            DBContent.Add(e.NewItems[0] as Player);
                            break;
                        case TableTypes.PlayersSeasons:
                            DBContent.Add(e.NewItems[0] as PlayersSeason);
                            break;
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    switch (TableType)
                    {
                        case TableTypes.Seasons:
                            DBContent.Remove(e.OldItems[0] as Season);
                            break;
                        case TableTypes.Nations:
                            DBContent.Remove(e.OldItems[0] as Nation);
                            break;
                        case TableTypes.Players:
                            DBContent.Remove(e.OldItems[0] as Player);
                            break;
                        case TableTypes.PlayersSeasons:
                            DBContent.Remove(e.OldItems[0] as PlayersSeason);
                            break;
                    }
                    break;
            }
        }
    }
}

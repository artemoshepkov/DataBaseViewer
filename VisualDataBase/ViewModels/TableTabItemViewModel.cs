using ReactiveUI;
using System.Collections.ObjectModel;
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
        private TableTypes _tableType;

        public string Title { get; }

        public dynamic DBContent { get; set; }

        public dynamic Content { get; set; }

        //private ObservableCollection<dynamic> _content;
        //public ObservableCollection<dynamic> Content
        //{
        //    get
        //    {
        //        return _content;
        //    }
        //    set
        //    {
        //        this.RaiseAndSetIfChanged(ref _content, value);
        //    }
        //}



        ReactiveCommand<Unit, Unit> AddRecordCommand { get; }


        public TableTabItemViewModel(TableTypes table)
        {
            Title = table.ToString();

            _tableType = table;

            Content = new ObservableCollection<dynamic>();

            InitContent();

            AddRecordCommand = ReactiveCommand.Create(AddRecord);
        }

        public TableTabItemViewModel(string title)
        {
            Title = title;

            _tableType = TableTypes.Request;
        }

        private void InitContent()
        {
            try
            {
                switch (_tableType)
                {
                    case TableTypes.Seasons:
                        {
                            DBContent = MyDataBaseContext.db.Seasons;
                            Content = new ObservableCollection<Season>(DBContent);
                            break;
                        }
                    case TableTypes.Nations:
                        {
                            DBContent = MyDataBaseContext.db.Nations;
                            Content = new ObservableCollection<Nation>(DBContent);
                            break;
                        }
                    case TableTypes.Players:
                        {
                            DBContent = MyDataBaseContext.db.Players;
                            Content = new ObservableCollection<Player>(DBContent);
                            break;
                        }
                    case TableTypes.PlayersSeasons:
                        {
                            DBContent = MyDataBaseContext.db.PlayersSeasons;
                            Content = new ObservableCollection<PlayersSeason>(DBContent);
                            break;
                        }
                }
            }
            catch
            {

            }
        }

        private void AddRecord()
        {
            try
            {
                switch (_tableType)
                {
                    case TableTypes.Seasons:
                        {
                            DBContent.Add(new Season { Title = "NewField" });
                            Content.Add(new Season { Title = "NewField" });
                            break;
                        }
                    case TableTypes.Nations:
                        {
                            break;
                        }
                    case TableTypes.Players:
                        {
                            break;
                        }
                    case TableTypes.PlayersSeasons:
                        {
                            break;
                        }
                }
            }
            catch
            {

            }
        }

    }
}

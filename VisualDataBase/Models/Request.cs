using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VisualDataBase.Models;

namespace VisualDataBase.ViewModels
{
    public class Request : ICloneable, INotifyPropertyChanged
    {
        private TableTypes _selectTableType;
        private ObservableCollection<TableField> _selectFields;

        public string Title { get; set; }
        
        public TableTypes SelectTableType
        {
            get
            {
                return _selectTableType;
            }
            set
            {
                _selectTableType = value;

                ChangedSelectFields();
            }
        }
        public ObservableCollection<TableField> SelectFields
        { 
            get
            {
                return _selectFields;
            }
            set
            {
                _selectFields = value;

                NotifyPropertyChanged();
            }
        }

        public static List<TableTypes> AvailableTableTypes { get; } = new List<TableTypes> {
            TableTypes.Players,
            TableTypes.PlayersSeasons,
            TableTypes.Seasons,
            TableTypes.Nations
        };

        public Request() { }

        public Request(string title)
        {
            Title = title;

            SelectFields = new ObservableCollection<TableField>();
        }

        private void ChangedSelectFields()
        {
            Type? classType = null;

            switch (SelectTableType)
            {
                case TableTypes.Seasons:
                    classType = typeof(Season);
                    break;
                case TableTypes.Nations:
                    classType = typeof(Nation);
                    break;
                case TableTypes.Players:
                    classType = typeof(Player);
                    break;
                case TableTypes.PlayersSeasons:
                    classType = typeof(PlayersSeason);
                    break;
            }
            SelectFields = new ObservableCollection<TableField>();

            SelectFields.Add(new TableField("All"));
            foreach (var item in classType.GetProperties())
            {
                if (item.Name != "IdNationNavigation" && item.Name != "PlayersSeasons")
                    SelectFields.Add(new TableField(item.Name));
            }
        }


        public object Clone()
        {
            return new Request
            {
                Title = this.Title,
                SelectTableType = this.SelectTableType,
                SelectFields = this.SelectFields
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

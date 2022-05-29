using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualDataBase.Models;

namespace VisualDataBase.ViewModels
{
    public class Request
    {
        public string Title { get; set; }

        public TableTypes? TypeSelectTable { get; set; }
        public ObservableCollection<TableField>? SelectFields { get; set; }
        public ObservableCollection<Condition>? SelectConditions { get; set; }

        public Request()
        {

        }
    }
}

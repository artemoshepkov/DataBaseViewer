using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualDataBase.Models;

namespace VisualDataBase.ViewModels
{
    public class Request : ICloneable
    {
        public string Title { get; set; }

        public TableTypes? TypeSelectTable { get; set; }
        public List<string>? SelectFields { get; set; }
        public List<Condition>? SelectConditions { get; set; }

        public Request()
        {

        }

        public object Clone()
        {
            return new Request { Title = this.Title, TypeSelectTable = this.TypeSelectTable, 
                SelectFields = this.SelectFields, SelectConditions = this.SelectConditions };
        }
    }
}

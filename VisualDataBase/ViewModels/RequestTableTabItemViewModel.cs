using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualDataBase.ViewModels
{
    internal class RequestTableTabItemViewModel : TableTabItemBase
    {


        public RequestTableTabItemViewModel(string title, List<object> list) : base(title, true)
        {


            //Content = new ObservableCollection<object>(list);
        }
    }
}

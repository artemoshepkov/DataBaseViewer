using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualDataBase.Models
{
    public class TableField
    {
        public string Title { get; }
        public bool IsSelected { get; set; }

        public TableField(string title)
        {
            Title = title;
            IsSelected = false;
        }
    }
}

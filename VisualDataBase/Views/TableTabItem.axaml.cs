using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VisualDataBase.Views
{
    public partial class TableTabItem : UserControl
    {
        public TableTabItem()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

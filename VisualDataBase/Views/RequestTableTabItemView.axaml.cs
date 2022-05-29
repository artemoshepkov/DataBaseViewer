using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VisualDataBase.Views
{
    public partial class RequestTableTabItem : UserControl
    {
        public RequestTableTabItem()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

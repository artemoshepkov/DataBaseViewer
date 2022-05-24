using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VisualDataBase.Views
{
    public partial class ManagerSQLRequestsView : UserControl
    {
        public ManagerSQLRequestsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

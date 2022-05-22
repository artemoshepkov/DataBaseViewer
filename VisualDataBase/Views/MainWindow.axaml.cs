using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VisualDataBase.ViewModels;

namespace VisualDataBase.Views
{
    public partial class MainWindow : Window
    {
        private Button _closeTab;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            _closeTab = this.FindControl<Button>("closeTabBtn");
        }
    }
}

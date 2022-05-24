using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VisualDataBase.ViewModels;

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

        private void DeleteExcessColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "IdNationNavigation" || e.PropertyName == "PlayersSeasons")
            {
                e.Cancel = true;
            }
        }
    }
}

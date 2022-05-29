using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using VisualDataBase.ViewModels;

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

        private void FieldsCheckBoxOnClick(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as ManagerSQLRequestsViewModel;

            if (context.FieldsSelectRequest == null)
                return;

            CheckBox clickedBox = (CheckBox)sender;

            if (clickedBox.Content.ToString() == "All")
            {
                if (clickedBox.IsChecked.Value)
                {
                    foreach (var item in context.FieldsSelectRequest)
                    {
                        if (item.Title != "All")
                        {
                            item.IsSelected = true;
                        }
                    }
                }
            }
        }
    }
}

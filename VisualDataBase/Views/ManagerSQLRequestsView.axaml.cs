using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VisualDataBase.Models;
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
            CheckBox clickedBox = (CheckBox)sender;

            var context = this.DataContext as ManagerSQLRequestsViewModel;

            if (clickedBox.Content.ToString() == "All")
            {
                if (clickedBox.IsChecked.Value)
                {
                    foreach (var item in context.CurrentRequest.SelectFields)
                    {
                        if (item.Title != "All")
                        {
                            item.IsSelected = true;
                        }
                    }
                }
            }
        }

        private void ComboBoxSelectRequest(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var context = this.DataContext as ManagerSQLRequestsViewModel;

                var addedItem = (Request)e.AddedItems[0];

                context.CurrentRequest = (Request)addedItem.Clone();
            }
            catch { }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Exercise2_Notes.ViewModels;
using Windows.UI.Core;
using Windows.UI.Popups;
using GalaSoft.MvvmLight.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Exercise2_Notes.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateNote : Page
    {
        public CreateNote()
        {
            this.InitializeComponent();
            txtDateTime.Text = DateTime.Now.ToString();             
        }

        public MainViewModel ViewModel => DataContext as MainViewModel;

        private async void cmdCancelNote_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Cancel Note creation?");
            dialog.Title = "Cancel Note";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                ViewModel.NavigateBack();
            }
        }

        private async void cmdCreateNote_Click(object sender, RoutedEventArgs e)
        {
            if (txtNote.Text == String.Empty)
            {
                var dialog = new MessageDialog("Cannot add empty notes!");
                dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                var res = await dialog.ShowAsync();
            }

            else
            {
                ViewModel.AddNote();
            }
        }
    }
}

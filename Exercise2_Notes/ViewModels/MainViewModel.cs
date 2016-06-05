using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Exercise2_Notes.Models;
using Exercise2_Notes.Pages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Exercise2_Notes.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly NavigationService navigationService;

        public MainViewModel()
        {
            Notes = new ObservableCollection<Note>(NoteSaver.Notes);
            AddNoteCommand = new RelayCommand(AddNote);

            navigationService = new NavigationService();
            navigationService.Configure("CreateNotePage", typeof(CreateNote));
            navigationService.Configure("ReadNotePage", typeof(ReadNote));
        }

        public Note Note { get; }
        public ObservableCollection<Note> Notes { get; }
        public string NewNoteContent { get; set; }
        public DateTime NewNoteDateTime { get; set; }

        public void AddNote()
        {
            NoteSaver.Notes.Add(new Note(NewNoteContent, DateTime.Now));
            NewNoteContent = string.Empty;
            NewNoteDateTime = DateTime.MinValue;
        }

        public RelayCommand AddNoteCommand { get; }

        public void NavigateToCreateNotePage()
        {
            navigationService.NavigateTo("CreateNotePage");
        }

        public void NavigateToReadNotePage()
        {
            navigationService.NavigateTo("ReadNotePage");
        }

        public void NavigateBack()
        {
            navigationService.GoBack();
        }

    }


}

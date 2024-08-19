using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XMLViewer2.Classes
{
    public class State : INotifyPropertyChanged
    {
        
        public void SetBusyState(string state) { 
            CurrentOperation = state;
            IsBusy = true;
        }
        public void FreeState()
        {
            IsBusy = false;
            CurrentOperation = "Готов";
        }

        private string _currentOperation = "-";
        public string CurrentOperation { get { return _currentOperation; } set { _currentOperation = value; OnPropertyChanged(); Application.DoEvents(); } }

        public string FilePath { get; set; }
        public string FileName { get; set; }

        
        private bool _fileIsOpened = false;
        public bool FileIsOpened { get { return _fileIsOpened; } set {
                _fileIsOpened = value; OnPropertyChanged(); } }

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged(); NotIsBusy = !value; Application.DoEvents(); } }

        private bool _notIsBusy = false;
        public bool NotIsBusy { get { return _notIsBusy; } set { _notIsBusy = value; OnPropertyChanged(); } }

        private bool _searchNextEnabled = false;
        public bool SearchNextEnabled { get { return _searchNextEnabled; } set { _searchNextEnabled = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}

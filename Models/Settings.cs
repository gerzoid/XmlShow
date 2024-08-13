using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XMLViewer2.Classes;

namespace XMLViewer2.Models
{
    [Serializable]
    public class Settings : INotifyPropertyChanged
    {
        private bool _columnNameWithParentName = true;       
        public bool ColumnNameWithParentName
        {
            get { return _columnNameWithParentName; }
            set {
                _columnNameWithParentName = value;
                OnPropertyChanged();
            }
        }
        
        private string _currentOperation = "-";
        
        [JsonIgnore]
        public string CurrentOperation { get { return _currentOperation; } set { _currentOperation = value;  OnPropertyChanged(); Application.DoEvents(); } }

        [JsonIgnore]
        public string FilePath {  get; set; }
        [JsonIgnore]
        public string FileName { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string property="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

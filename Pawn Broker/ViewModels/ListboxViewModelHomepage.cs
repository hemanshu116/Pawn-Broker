using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Pawn_Broker.Annotations;

namespace Pawn_Broker.ViewModels
{
    public class ListboxViewModelHomepage :  INotifyPropertyChanged
    {
        private string _name;
        private object _content;

        public ListboxViewModelHomepage(string name, object content)
        {
            _name = name;
            _content = content;
        }

        public string Name {
            get { return _name; }
            set { this.MutateVerbose(ref _name, value, RaisePropertyChanged()); }
        }

        public object Content {
            get { return _content; }
            set { this.MutateVerbose(ref _content, value, RaisePropertyChanged()); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}

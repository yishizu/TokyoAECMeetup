using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfIntro_Grid
{
    public class Log : INotifyPropertyChanged

    {
        private ObservableCollection<String> _parentItemSource = new ObservableCollection<string>();
        public ObservableCollection<String> LogList
        {
            get
            {
                return _parentItemSource;
            }
            set
            {
                if (_parentItemSource != value)
                {
                    _parentItemSource = value;
                    RaisePropertyChanged("LogList");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

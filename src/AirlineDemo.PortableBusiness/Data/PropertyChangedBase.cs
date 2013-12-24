using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDemo.PortableBusiness.Data
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var method = PropertyChanged;
            if (method != null)
                method(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

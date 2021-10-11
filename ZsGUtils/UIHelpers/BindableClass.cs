using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ZsGUtils.UIHelpers
{
    public abstract class BindableClass : INotifyPropertyChanged
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetAndNotifyPropertyChanged<T>(ref T varToUpdate, T newValue, 
            [CallerMemberName] String propertyName = "")
        {
            if (!varToUpdate.Equals(newValue))
            {
                varToUpdate = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

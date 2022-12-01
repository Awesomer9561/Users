using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Users.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        public virtual void ViewAppeared()
        {
            InitialiseAsync();
        }
        public virtual void ViewAppearing()
        {

        }
        public virtual void ViewDisappearing()
        {

        }
        public virtual void ViewDisappeared()
        {

        }
        protected virtual Task InitialiseAsync()
        {
            return Task.CompletedTask;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

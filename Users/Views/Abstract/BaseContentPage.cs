using System;
using System.Collections.Generic;
using System.Text;
using Users.ViewModels;
using Xamarin.Forms;

namespace Users.Views
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as BaseViewModel)?.ViewAppearing();
            (this.BindingContext as BaseViewModel)?.ViewAppeared();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            (this.BindingContext as BaseViewModel)?.ViewDisappearing();
            (this.BindingContext as BaseViewModel)?.ViewDisappeared();
        }
    }
}

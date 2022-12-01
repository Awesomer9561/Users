using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Models;
using Users.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Users.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsView : BaseContentPage
    {
        public UserDetailsView(User selectedUser)
        {
            InitializeComponent();

            //Can be done via Navigation Service but doing it like this as of now
            (BindingContext as UserDetailsViewModel).User = selectedUser;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Users.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersView : BaseContentPage
    {
        public UsersView()
        {
            InitializeComponent();
        }

        private void ItemClicked(object sender, EventArgs e)
        {

        }
    }
}

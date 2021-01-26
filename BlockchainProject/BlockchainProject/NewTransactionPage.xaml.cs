using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlockchainProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTransactionPage : ContentPage
    {
        public NewTransactionPage()
        {
            InitializeComponent();
        }

        private void confirmButton_Clicked(object sender, EventArgs e)
        {

        }

        private void detailsBind_SelectedIndexChanged(object sender, EventArgs e)
        {
            string phoneNo = ((Binding)detailsBind.SelectedItem).Phonenumber;
            phoneNum.Text = phoneNo;
        }
    }
}
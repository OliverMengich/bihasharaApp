using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AfricasTalkingCS;
using Plugin.Toast;
using System.Data.SqlClient;
namespace BlockchainProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string SurName { get; set; }
        public string OtherNames { get; set; }
        public string PhoneNumber { get; set; }
        public int IDNumber { get; set; }
        public int randomNum { get; set; }
        private void signUpButton_Clicked(object sender, EventArgs e)
        {
            IDNumber = Convert.ToInt32((idNumber.Text));
            SurName = surName.Text;
            OtherNames = otherNames.Text;
            PhoneNumber = phoneNumber.Text;
            AddToDatabase(IDNumber, SurName, OtherNames, PhoneNumber);
            Random random = new Random();
            randomNum = random.Next(100000, 1000000);
            string message = "your confirmation Number is " + randomNum;
            const string username = "your name"; 
            const string apikey = "your apiKey";
            var gateway = new AfricasTalkingGateway(username, apikey);
            
            if (PhoneNumber.StartsWith("+254") && PhoneNumber.Length == 13)
            {
                
                try
                {
                    var sms = gateway.SendMessage(PhoneNumber, message);
                    CrossToastPopUp.Current.ShowToastMessage("You will receive confirmation number");
                }
                catch (AfricasTalkingGatewayException exception)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Cannot send confirmation number" +exception.Message);
                }
            }
            else
            {
                CrossToastPopUp.Current.ShowToastError("enter a valid phone number");
       
            }
        }
        private void AddToDatabase(int idNumber,string SurName,string othernames,string phonenumber)
        {
            string connectionString = "your connection string";
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO MYTABLE(SURNAME,OTHERNAMES,ID NUMBER,PHONENUMBER) VALUES(@SURNAME,@OTHERNAMES,@IDNUMBER,@PHONENUMBER)";
                    cmd.Parameters.AddWithValue("@SURNAME", SurName);
                    cmd.Parameters.AddWithValue("@OTHERNAMES", othernames);
                    cmd.Parameters.AddWithValue("@IDNUMBER", idNumber);
       
                    cmd.Parameters.AddWithValue("@PHONENUMBER", phonenumber);
                    conn.Open();

                    cmd.ExecuteScalar();
                    CrossToastPopUp.Current.ShowToastMessage("inserted data");
                    conn.Close();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Toast;
using System.Data.SqlClient;
namespace BlockchainProject
{
    public class ViewClass
    {
        public List<Binding> bindings { get; set; }

        public ViewClass()
        {
            string connectionString = "";
            try
            {
                using (SqlConnection sql = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = @"SELECT SURNAME,PHONENUMBER AS [ surname phoneno] FROM CUSTOMERTABLE";
                        sql.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bindings = new List<Binding>();
                                bindings.Add(new Binding { SurName= reader.GetString(0), Phonenumber=reader.GetString(1)});
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                CrossToastPopUp.Current.ShowToastMessage("There is an error try again");
            }
        }
    }
}

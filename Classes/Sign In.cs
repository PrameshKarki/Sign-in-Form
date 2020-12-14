using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sign_In_Using_Database.Classes
{
    class Sign_In
    {
        public string userName { get; set; }
        public string password { get; set; }
        public static string connectionString = "server=localhost;user id=root;database=userdatabase;pwd=password";
        //Method to check user already exist in database or not 
        public bool CheckUser(Sign_In obj)
        {
            bool isExist = false;
            //SQL Connection
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {   //SQL Query to check User
                string SQLQuery = "SELECT COUNT(User_ID) FROM Users WHERE User_Name=BINARY @userName AND Password=BINARY @password";
                //SQL Command
                MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
                //Creating parameters to Add value
                cmd.Parameters.AddWithValue("@userName", obj.userName);
                cmd.Parameters.AddWithValue("@password", obj.password);
                //Open connection
                conn.Open();
                object returnValue = cmd.ExecuteScalar();
                if (returnValue != null)
                {
                    int count = Convert.ToInt32(returnValue);
                    isExist = count == 1 ? true : false;

                }
                else
                {
                    MessageBox.Show("OOPS!Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return isExist;
        }
    }
}

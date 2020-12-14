using Sign_In_Using_Database.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sign_In_Using_Database
{
    public partial class signInForm : Form
    {
        //Instantiating Sign_In Class
        Sign_In s = new Sign_In();
       //Constructor
        public signInForm()
        {
            InitializeComponent();
        }
        //Handling Click event on Log In Button
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            //Temprorarily holding text fields value for validating
            string tempUserName = userName.Text.Trim();
            string tempPassword = password.Text.Trim();
            //Validation of UserInput
            if (tempUserName == "" || tempPassword == "")
            {
                MessageBox.Show("Fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                s.userName = tempUserName;
                s.password = tempPassword;
                //Checking username or password
                bool sucess = s.CheckUser(s);
               //Matched
                if (sucess)
                {
                    MessageBox.Show("Sucessfully Signed Up.","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Incorrect UserName or Password","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        private void ClearFields()
        {
            userName.Text = "";
            password.Text = "";
        }
    }
}
//Pramesh Karki
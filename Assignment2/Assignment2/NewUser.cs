using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment2
{



    public partial class NewUser : Form
    {

        List<Account> accountList = new List<Account>();
        public NewUser()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string passwordCheck = textBox3.Text;
            string firstName = textBox4.Text;
            string lastName = textBox5.Text;
            string dateOfBirth = dateTimePicker1.Text;
            string userType = comboBox1.Text;

            Console.WriteLine(username);


            if (password == passwordCheck)
            {
                Account newAcc = new Account(username, password, firstName, lastName, dateOfBirth, userType);
                accountList.Add(newAcc);

                FileManager fileManager = new FileManager();
                fileManager.addToFile(newAcc);

                this.Close();

            }
            Label errorLabel = new Label();
            errorLabel.Location = new Point(40, 40);
            errorLabel.Text = "Error. Password doesn't match";
            this.Controls.Add(errorLabel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
    class Account
    {
        string username;
        string password;
        string firstName;
        string lastName;
        string dob;
        string userType;
        public Account(string username, string password, string firstName, string lastName, string dob, string usertype)
        {
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dob = dob;
            this.userType = usertype;


            // fileName = accountNumber.ToString() + ".txt";
        }
        public string getUsername()
        {
            return this.username;
        }
        public string getPassword()
        {
            return this.password;
        }
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public string getDob()
        {
            return this.dob;
        }
        public string getUserType()
        {
            return this.userType;
        }
    }
}

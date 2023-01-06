using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewUser form2 = new NewUser();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {//read inputs
            string username = textBox1.Text;
            string password = textBox2.Text;
            FileManager fileManager = new FileManager();

            //store the permission to carry into editor
            string permission = fileManager.checkLogin(username, password);


            //check if log in details  are not correct. Throw error 
            if (!(permission == "edit" || permission == "view"))
            {
                //make new label showing error for user
                Label errorLabel = new Label();
                errorLabel.Location = new Point(300, 300);
                errorLabel.Size = new Size(300, 20);
                errorLabel.Text = "Error: Username or Password couldn't be found. Try again";
                this.Controls.Add(errorLabel);
            }
            else
            {
                
                Editor editor = new Editor();
                editor.setType(permission);
                editor.setUser(username);
                editor.ShowDialog();


            }




        }
    }
}

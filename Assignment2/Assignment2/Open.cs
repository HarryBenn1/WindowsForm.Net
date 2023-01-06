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
    public partial class Open : Form
    {
        string fileName;
        FileManager fileManager = new FileManager();
        public Open()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (fileManager.checkFileExists(textBox1.Text + ".txt"))
            {
                
                fileName = textBox1.Text;
                this.Close();
            }
            else
            {
                Label errorLabel = new Label();
                errorLabel.Location = new Point(10, 10);
                errorLabel.Size = new Size(300, 20);
                errorLabel.Text = "Error: File doesn't exist!";
                this.Controls.Add(errorLabel);
            }

            
        }

        public string getName()
        {
            return fileName + ".txt";
        }
        
    }
}

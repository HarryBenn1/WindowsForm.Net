using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment2
{
    public partial class Editor : Form
    {
        string userType;
        bool lastSaved;
        string name;
        FileManager fileManager = new FileManager();
        string fileName = " ";

        public Editor()
        {

            InitializeComponent();
           
           
        }
       
        //set permissions of files
        public void setType(string userType)
        {
            this.userType = userType;

        }
        public void setUser(string name)
        {
            this.name = name;
        }
        //textbox user uses
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(userType == "view")
            {
                richTextBox1.Undo();
                richTextBox1.ReadOnly = true;
            }
            lastSaved = false;
            toolStripLabel1.Text = "Username " + name;

        }



        /**********************************************************************/
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /********************************************************/
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        /***************************************************************************/
        private void newFile(){
            //check if saved before wiping
            if (!lastSaved == true)
            {
                Save newSave = new Save(fileName);
                newSave.ShowDialog();
                fileName = newSave.getName();
            }
            fileName = " ";
            richTextBox1.Text = "";
        }
        private void saveAs()
        {
            Save newSave = new Save(fileName);
            newSave.ShowDialog();
            fileName = newSave.getName();
            fileManager.saveFile(richTextBox1.Text, fileName);
            lastSaved = true;
        }
        private void save()
        {
            if (fileName == " ")
            {
                Save newSave = new Save(fileName);
                newSave.ShowDialog();
                fileName = newSave.getName();


            }
            fileManager.saveFile(richTextBox1.Text, fileName);
            lastSaved = true;
        }
        private void open()
        {
            Open newOpen = new Open();
            newOpen.ShowDialog();
            string OpenfileName = newOpen.getName();


            richTextBox1.Text = fileManager.openFile(OpenfileName);
            fileName = OpenfileName;
        }
        //new
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //check if saved before wiping
            newFile();
           
        }

        //open
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            open();
        }

        //save
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            save();
        }

        //save as
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        //bold
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            System.Drawing.Font currentFont = richTextBox1.SelectionFont;
            System.Drawing.FontStyle newFontStyle;

            if (richTextBox1.SelectionFont.Bold == true)
            {
                newFontStyle = FontStyle.Regular;
            }
            else
            {
                newFontStyle = FontStyle.Bold;
            }

            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);

        }

        //italics
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            System.Drawing.Font currentFont = richTextBox1.SelectionFont;
            System.Drawing.FontStyle newFontStyle;

            if (richTextBox1.SelectionFont.Italic == true)
            {
                newFontStyle = FontStyle.Regular;
            }
            else
            {
                newFontStyle = FontStyle.Italic;
            }

            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

        //underline
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            System.Drawing.Font currentFont = richTextBox1.SelectionFont;
            System.Drawing.FontStyle newFontStyle;

            if (richTextBox1.SelectionFont.Underline == true)
            {
                newFontStyle = FontStyle.Regular;
            }
            else
            {
                newFontStyle = FontStyle.Underline;
            }

            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

        //choosing font size
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            //update the text
            toolStripComboBox1.ComboBox.SelectionChangeCommitted += ComboBoxOnSelectionChangeCommitted;
        }
        //change font size
        private void ComboBoxOnSelectionChangeCommitted(object o, EventArgs eventArgs)
        {
            System.Drawing.Font currentFont = richTextBox1.SelectionFont;
            
           
            switch (toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, 10);
                    break;
                case 1:
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, 14);
                    break;
                case 2:
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, 18);
                    break;
                default:
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, 6);
                    break;
            }
        }
        //show username
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
            toolStripLabel1.Text = "Username: " + name;
        }
        /*******************************************************************/
        //cut side bar
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        //copy side bar
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        //help menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About newAbout = new About();
            newAbout.ShowDialog();
        }


       
    }
}

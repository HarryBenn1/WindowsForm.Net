﻿using System;
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
    public partial class Save : Form
    {
        string fileName;
        public Save(string name)
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileName = textBox1.Text;
            this.Close();
        }
        public string getName()
        {
            return fileName + ".txt";
        }
    }
}
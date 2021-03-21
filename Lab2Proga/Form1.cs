﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2Proga
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            MenuBulder menuBulder = new MenuBulder(openFileDialog1.FileName, this);
        }

        public void FirstMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Вызван метод 'FirstMethod'");
        }
        public void SecondMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Вызван метод 'SecondMethod'");
        }
        public void ThirdMethod(object sender, EventArgs e)
        {
            MessageBox.Show("Вызван метод 'ThirdMethod'");
        }
    }
}

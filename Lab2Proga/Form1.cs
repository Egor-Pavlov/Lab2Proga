using System;
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

        public void Method1(object sender, EventArgs e)
        {
            MessageBox.Show("Вызван метод 'Method1'");
        }
        public void Method2(object sender, EventArgs e)
        {
            MessageBox.Show("Вызван метод 'Method2'");
        }
        public void Method3(object sender, EventArgs e)
        {
            MessageBox.Show("Вызван метод 'Method3'");
        }
    }
}

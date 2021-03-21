using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection; //для позднего связывания
//using FBuilder; //для раннего связывания

namespace Lab2Proga
{
    public partial class Form1 : Form
    {
        //путь для позднего связывания
        string dllPath = @"C:\Users\EgorP\source\repos\Egor-Pavlov\Lab2Proga\FBuilder\bin\Debug\netcoreapp3.1\FBuilder.dll";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            //позднее связывание
            Assembly assembly = Assembly.LoadFrom(dllPath);
            Type type = assembly.GetType("FBuilder.Builder", true, true);
            object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod("Init");
            object res = methodInfo.Invoke(obj, new object[] { openFileDialog1.FileName, this });
            //конец позднего связывание


            //MenuBulder menuBulder = new MenuBulder(openFileDialog1.FileName, this);//вызов конструктора класса не через dll (2 лаб работа)


            //Builder fbulder = new Builder(openFileDialog1.FileName, this);//раннее связывание
        }

        //для 2 л.р
        //public void FirstMethod(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Вызван метод 'FirstMethod'");
        //}
        //public void SecondMethod(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Вызван метод 'SecondMethod'");
        //}
        //public void ThirdMethod(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Вызван метод 'ThirdMethod'");
        //}
    }
}

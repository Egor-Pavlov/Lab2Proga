using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2Proga
{
    class MenuBulder
    {
        private string FilePath;
        private string[] Lines;//содержимое файла
        Form1 form;
        ToolStrip Root = new ToolStrip();//корень дерева в иерархии - полоска меню

        public MenuBulder(string FilePath, Form1 form)
        {
            this.FilePath = FilePath;
            this.form = form;

            // Чтение файла
            using (StreamReader Reader = new StreamReader(FilePath))
                Lines = Reader.ReadToEnd().Split('\n');

            Build();
            form.Controls.Add(Root);
        }
        private int Build(int level = 0, ToolStripDropDownButton root = null, int index = 0)
        {
            
            //структура строки в файле:
            //Номер_уровня_в_иерархии Название_пункта Статус_пункта ИмяМетода

            //ЕСЛИ ЭЛЕМЕНТ В УЗЛЕ ИЕРАРХИИ - ТО ПОСЛЕ СТАТУСА ПРОБЕЛ И ВМЕСТО МЕТОДА ТОЖЕ ПРООБЕЛ!!!

            // Разделение строк на слова для извлечения параметров элемента управления
            int i = index;
            for (; i < Lines.Length; i++)
            {
                ToolStripDropDownButton button = new ToolStripDropDownButton();
                button.Size = new System.Drawing.Size(80, 22);
                string[] Param = Lines[i].Split(' ');

                button.Text = Param[1];
                
                //задаем видимость и доступность согласно статусу в файле
                if(Convert.ToInt32(Param[2]) == 0)
                {
                    button.Visible = true;
                    button.Enabled = true;
                }
                else if (Convert.ToInt32(Param[2]) == 1)
                {
                    button.Visible = true;
                    button.Enabled = false;
                }
                else if (Convert.ToInt32(Param[2]) == 2)
                {
                    button.Visible = false;
                    button.Enabled = false;
                }

                //прикручиваем вызываемый метод
                if (Param[3].Trim() == "Method1")
                    button.Click += form.Method1;
                if (Param[3].Trim() == "Method2")
                    button.Click += form.Method2;
                if (Param[3].Trim() == "Method3")
                    button.Click += form.Method3;

                if (level == 0)//добавляем в самый корень если уровень == 0
                {
                    Root.Items.Add(button);

                }
                else if(level == Convert.ToInt32(Param[0])) //если мы на нужном уровне добавляем в имеющийся корень
                {
                    root.DropDownItems.Add(button);

                }
                if(i + 1 != Lines.Length)
                {
                    //если уровень следующего элемента больше - рекурсивный вызов с повышением индекса и уровня
                    if (Convert.ToInt32(Lines[i + 1].Split(' ')[0]) > level && level == Convert.ToInt32(Param[0]))
                    {
                        i = Build(level + 1, button, i + 1);
                        
                    }
                    if (Convert.ToInt32(Lines[i + 1].Split(' ')[0]) < level && level == Convert.ToInt32(Param[0]))
                    {//выходим из рекурсии, уровень понижается так как спускаемся обратно по иерархии
                        level--;
                        return i;
                    }
                }  

                else return i;
            }
            return i;
        }

    }
}

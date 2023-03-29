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

namespace LINQ_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<Person> list = new List<Person>();
            StreamReader sr = File.OpenText("person.txt");
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] ss = s.Split(' ');
                string fam = ss[0];
                string name = ss[1];
                string otch = ss[2];
                int age = int.Parse(ss[3]);
                double weight = double.Parse(ss[4]);
                Person person = new Person(name, fam, otch, age, weight);
                list.Add(person);
            }
            var person40 = from Person in list where Person.Age < 40 select Person;
            foreach (Person pers in person40)
            {
                listBox1.Items.Add($"{pers.Fam} {pers.Name} {pers.Otch} {pers.Age} {pers.Weight}");
            }
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Departament> department = new List<Departament>()
            {
                new Departament { Name = "Отдел закупок", Reg = "Германия" },
                new Departament { Name = "Отдел продаж", Reg = "Испания" },
                new Departament { Name = "Отдел маркетинга", Reg = "Испания" }
            };

            List<Employ> employes = new List<Employ>()
            {
                new Employ {Name = "Иванов", Department = "Отдел закупок"},
                new Employ {Name = "Петров", Department = "Отдел закупок"},
                new Employ {Name = "Сидоров", Department = "Отдел продаж"},
                new Employ {Name = "Лямин", Department = "Отдел продаж"},
                new Employ {Name = "Сидоренко", Department = "Отдел маркетинга"},
                new Employ {Name = "Кривоносов", Department = "Отдел продаж"}
            };

            var resultOne = from emp in employes
                            join dep in department on emp.Department equals dep.Name
                            group emp by dep.Reg into g
                            select new { Reg = g.Key, Department = g.ToList() };
            foreach (var group in resultOne)
            {
                listBox2.Items.Add($"Регион: {group.Reg}");
                foreach (var dep in group.Department)
                {
                    listBox2.Items.Add(dep.Name);
                }
            }

            var resultTwo = from emp in employes
                            join dep in department on emp.Department equals dep.Name
                            where dep.Reg.StartsWith("И")
                            select emp;
            foreach (var emp in resultTwo)
            {
                listBox3.Items.Add($"{emp.Name} ({emp.Department})");
            }
        }
    }
}

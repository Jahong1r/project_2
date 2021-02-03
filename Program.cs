using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_2
{
    class Student
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Stud = new List<Student>()
            {
                new Student {Surname="Ололоев", Name="Ололо", Score=3},
                new Student {Surname="Зимаков", Name="Илья", Score=5},
                new Student {Surname="Рау", Name="Альберт", Score=2},
                new Student {Surname="Ноговицы", Name="Коля", Score=4},
                new Student {Surname="Сидоров", Name="Александр", Score=5}
            };

            Console.WriteLine();
            var spisok = from s in Stud orderby s.Surname ascending select s;
            foreach (var i in spisok) { Console.WriteLine("{0,-12}{1,-2}{2}", i.Surname, i.Name, ": " + i.Score); }

            Console.WriteLine();
            var otlichniki = from s in Stud where s.Score == 5 select s;
            foreach (var i in otlichniki) { Console.WriteLine("{0,-12}{1,-2}{2}", i.Surname, i.Name, ": " + i.Score); }

            Console.WriteLine();
            var reiting = from s in Stud orderby s.Score descending select s;
            foreach (var i in reiting) { Console.WriteLine("{0,-12}{1,-2}{2}", i.Surname, i.Name, ": " + i.Score); }

            Console.WriteLine();
            var dvoech = (from dva in Stud where dva.Score == 2 select dva).Count();
            var otlich = (from pyat in Stud where pyat.Score == 5 select pyat).Count();
            if (dvoech > otlich) { Console.WriteLine("Двоечников больше чем отличников"); }
            else if (otlich > dvoech) { Console.WriteLine("Отличников больше чем двоечников"); }
            else if (otlich == dvoech) { Console.WriteLine("Отличников и двоечников одинаковое количество"); }

            Console.WriteLine();
            var groups = from s in Stud
                         orderby s.Name ascending
                         group s by s.Name[0] into g
                         select new
                         {
                             Name = g.Key,
                             Alf = from p in g orderby p.Name ascending select p
                         };
            foreach (var group in groups)
            {
                Console.WriteLine("{0}:", group.Name);
                foreach (var s in group.Alf)
                    Console.WriteLine(s.Name);
            }

            Console.WriteLine();
            var raznost = (from s in Stud select s.Score).Max() - (from s in Stud select s.Score).Min();
            Console.WriteLine("Разность набранных баллов - {0}", raznost);

            Console.WriteLine();
            string Name1, Surname1;
            int Score1;
            Console.WriteLine("Введите фамилию студента:");
            Surname1 = Console.ReadLine();
            Console.WriteLine("Введите имя студента:");
            Name1 = Console.ReadLine();
            Console.WriteLine("Введите оценку студента:");
            Score1 = Convert.ToInt32(Console.ReadLine());
            Stud.Add(new Student { Name = Name1, Score = Score1, Surname = Surname1 });

            Console.WriteLine();
            var spisok2 = from s in Stud orderby s.Surname ascending select s;
            foreach (var i in spisok2) { Console.WriteLine("{0,-12}{1,-2}{2}", i.Surname, i.Name, ": " + i.Score); }

            Console.WriteLine();
            var gr = from s in Stud
                     orderby s.Surname ascending
                     group s by s.Surname into g
                     select new
                     {
                         Surname = g.Key,
                         bolshe = (from p in g select p.Score).Max()
                     };
            foreach (var i in gr)
            {
                Console.WriteLine("{0}", i.Surname);
                Console.WriteLine("{0}", i.bolshe);
            }

            Console.WriteLine();
        }
    }
}

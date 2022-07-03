using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Barracks barracks = new Barracks();
            barracks.ShowSoldierData();
        }
    }

    class Barracks
    {
        private string[] _nameBase = { "Нестер", "Самиров"
                , "Рязанцев", "Геннадьевич", "Ксения"
                , "Романович", "Николай", "Петухина", "Вадим"
                , "Маргарита", "Точилкина", "Батраков", "Вязмитинова"
                , "Индейкина", "Колосюк", "Михаил", "Хорошилова"
                , "Павел", "Вероника", "Дмитрий", "Тельпугова"
                , "Биушкина", "Николай", "Александр", "Вероника"
                , "Ирина", "Тактаров", "Борис", "Полина"
                , "Спиридонов", "Лоринова", "Ряхин", "Юльева"
                , "Олег", "Глеб", "Тимофей", "Артур"};

        private List<Soldier> _soldiersOne = new List<Soldier>();
        private List<Soldier> _soldiersTwo = new List<Soldier>();

        public Barracks()
        {
            GenerateBarracks();
        }

        internal void ShowSoldierData()
        {
            Console.WriteLine("Весь список солдат первой роты");
            ShowSoldier(_soldiersOne);
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("список солдат второй роты после перевода");

            int firstSymbol = 0;
            var soldierPlatoonTwo = from soldier in _soldiersOne where soldier.Name[firstSymbol] == 'Б' select soldier;
           soldierPlatoonTwo= _soldiersTwo.Union(soldierPlatoonTwo);
            _soldiersTwo = soldierPlatoonTwo.ToList();
            var soldierPlatoonOne = _soldiersOne.Except(soldierPlatoonTwo);
            _soldiersOne = soldierPlatoonOne.ToList();


           // AddSoldierTwo(soldierPlatoonTwo.ToList());
            ShowSoldier(_soldiersTwo);

            Console.WriteLine();
            Console.WriteLine("список солдат первой роты после перевода");
            Console.WriteLine();
            ShowSoldier(_soldiersOne);
            Console.ReadLine();
        }

        private void ShowSoldier(List<Soldier> soldiers)
        {
            foreach (Soldier soldier in soldiers)
            {
                Console.WriteLine($"Имя солдата - {soldier.Name}");
            }
        }

        private void AddSoldierTwo(List<Soldier> soldiers)
        {
            foreach (Soldier soldier in soldiers)
            {
                _soldiersTwo.Add(soldier);
            }
        }

        private void GenerateBarracks()
        {
            int quantitySoldiers = 25;

            for (int i = 0; i < quantitySoldiers; i++)
            {
                Soldier soldier = new Soldier(GenerateNameSoldier());
                _soldiersOne.Add(soldier);
            }
        }

        private string GenerateNameSoldier()
        {
            Random random = new Random();
            return _nameBase[random.Next(_nameBase.Length)];
        }
    }

    class Soldier
    {
        internal string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }
}

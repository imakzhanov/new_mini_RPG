using System;
using System.Collections.Generic;
using System.Text;

namespace new_mini_RPG
{
    class Teams
    {
        public string Name{ get; private set;}
        private List<HeroesBase> Heroes{ get; set;}//должен быть приватным
        public Teams(string name)
        {
            Name = name;
            Heroes = new List<HeroesBase>();
        }
        public bool HeroAdd(HeroesBase hero)
        {
            Type newHeroType = hero.GetType(); 
            for (int i = 0; i < Heroes.Count; i++)
            {
                Type HeroType = Heroes[i].GetType();
                if (newHeroType == HeroType)
                {
                    Console.WriteLine("Герой уже Выбран.");
                    return false;
                }
            }
            Heroes.Add(hero);
            return true;
        }
        public int GettingHeroesCount()
        {
            return Heroes.Count;
        }
        //-------------------------------------------------------------------------------------------атака
        public bool HeroLiveCheck(int hero)
        {
            return Heroes[hero].Life;
        }
        public bool TeamLiveCheck()
        {
            bool teamLive = false;
            for (int i = 0; i<Heroes.Count;i++)
            {
                if (HeroLiveCheck(i)) 
                {
                    teamLive = true;
                }
            }
            return teamLive;
        }
        public int GettingFullDamage(int attackingHero)
        {
            return Heroes[attackingHero].GetDamage();
        }
        public string GettingAttackingHeroName(int attackingHero)
        {
            return Heroes[attackingHero].Name;
        }
        
        
        //не вижу метода принятия урона
        public void GettingDamage(int target, int attackingHeroDamage, string attackingHeroName, string attackingTeamName)
        {
            Heroes[target].SettingLiveAndHP(attackingHeroDamage);
            Console.WriteLine($"{attackingHeroName}({attackingTeamName}) нанес {attackingHeroDamage} урона {Heroes[target].Name}у({Name}).");
        }
        //-------------------------------------------------------------------------------------------атака
        public void ShowInfo()
        {
            Console.WriteLine("----------");
            Console.WriteLine($"Команда:{Name}");
            for (int i = 0; i < Heroes.Count; i++)
            {
                Console.Write($"{i + 1})");
                Heroes[i].ShowInfo();
            }
            Console.WriteLine("----------");
        }
    }
}

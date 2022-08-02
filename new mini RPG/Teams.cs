using System;
using System.Collections.Generic;
using System.Text;

namespace new_mini_RPG
{
    class Teams
    {
        public string Name{ get; set;}
        public List<HeroesBase> Heroes{ get; private set;}//должен быть приватным
        public Teams()
        {
            Heroes = new List<HeroesBase>();
        }
        public bool HeroAdd(HeroesBase hero)
        {
            Type t = hero.GetType();
            for (int i = 0; i < Heroes.Count; i++)
            {
                Type t1 = Heroes[i].GetType();
                if (t == t1)
                {
                    Console.WriteLine("Герой уже Выбран.");
                    return false;
                }
            }
            Heroes.Add(hero);
            return true;
        }

        //-------------------------------------------------------------------------------------------атака
        public bool HeroLiveCheck(int hero)
        {
            bool life = Heroes[hero].GetLife();
            return life;
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
        public int GettingAttackingHeroDamage(int attackingHero)
        {
            return Heroes[attackingHero].Damage;
        }
        public string GettingAttackingHeroName(int attackingHero)
        {
            return Heroes[attackingHero].Name;
        }
        //не вижу метода принятия урона
        public void Damaging(int target, int attackingHeroDamage, string attackingHeroName, string attackingTeamName)
        {
            int allDamage = Heroes[target].Damaging(attackingHeroDamage);
            Console.WriteLine($"{attackingHeroName}({attackingTeamName}) нанес {allDamage} урона {Heroes[target].Name}у({Name}).");
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

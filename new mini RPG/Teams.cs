using System;
using System.Collections.Generic;
using System.Text;

namespace new_mini_RPG
{
    /// <summary>
    ///responsible for the teams of player and computer
    /// </summary>
    class Teams
    {
        /// <summary>
        /// stores team name
        /// </summary>
        public string Name{ get; private set;}
        /// <summary>
        /// stores all heroes in team, their HP and damage
        /// </summary>
        private List<HeroesBase> Heroes{ get; set;}
        public Teams(string name)
        {
            Name = name;
            Heroes = new List<HeroesBase>();
        }
        /// <summary>
        ///adds heroes to team (heroes cannot be repeated)
        /// </summary>
        /// <param name="hero">hero that the method will either add or not</param>
        /// <returns>returns true if hero was added and false if hero had already been in team</returns>
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
        /// <summary>
        ///gives number of heroes in team (Heroes.Count )
        /// </summary>
        /// <returns> returns number of heroes in team</returns>
        public int GettingHeroesCount()
        {
            return Heroes.Count;
        }
        /// <summary>
        ///check if hero is alive or not
        /// </summary>
        /// <param name="hero">accepts hero which method should check</param>
        /// <returns>returns bool variable that tells if hero is alive</returns>
        public bool HeroLiveCheck(int hero)
        {
            return Heroes[hero].Life;
        }
        /// <summary>
        ///check if all heroes in team are alife or not
        /// </summary>
        /// <returns>if all heroes are dead method returns false</returns>
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
        /// <summary>
        ///gives damage with damage spread
        /// </summary>
        /// <param name="attackingHero"></param>
        /// <returns>returns damage with damage spread</returns>
        public int GettingFullDamage(int attackingHero)
        {
            return Heroes[attackingHero].GetDamage();
        }

        /// <summary>
        /// returns heroes HP
        /// </summary>
        /// <param name="hero">variable that means number of the hero in the class Teams</param>
        /// <returns>heroes HP</returns>
        public int GettingHP(int hero)
        {
            return Heroes[hero].HP;
        }
        /// <summary>
        /// gives attacking hero name
        /// </summary>
        /// <param name="attackingHero">variable that means number of attacking hero in team</param>
        /// <returns>atacking hero name</returns>
        public string GettingAttackingHeroName(int attackingHero)
        {
            return Heroes[attackingHero].Name;
        }

        /// <summary>
        ///changes HP of hero that was attacked and displays information about attack
        /// </summary>
        /// <param name="target">hero id in class, that was attacked</param>
        /// <param name="attackingHeroDamage">damage to target</param>
        /// <param name="attackingHeroName"> name of attacking hero</param>
        /// <param name="attackingTeamName">team name of attacking hero</param>
        public void GettingDamage(int target, int attackingHeroDamage, string attackingHeroName, string attackingTeamName)
        {
            Heroes[target].SettingLiveAndHP(attackingHeroDamage);
            Console.WriteLine($"{attackingHeroName}({attackingTeamName}) нанес {attackingHeroDamage} урона {Heroes[target].Name}у({Name}).");
        }

        /// <summary>
        /// show information about team(team name; heroes name, hp and damage)
        /// </summary>
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

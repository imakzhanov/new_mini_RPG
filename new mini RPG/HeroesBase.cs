using System;
using System.Collections.Generic;
using System.Text;

namespace new_mini_RPG
{
    class HeroesBase
    {
        public int HP { get; private set; }
        public int Damage { get; private set; }
        public string Name { get; private set; }
        public bool Life{get; private set;}
        Random randomGenerator = new Random();
        public HeroesBase( int hp, int damage, string name)
        {            
            HP = hp;
            Damage = damage;
            Name = name;
            Life = true;
        }

        /// <summary>
        /// creates damage spread and adds it to main damage
        /// </summary>
        /// <returns>returns damage with spread</returns>
        public int GetDamage()
        {
            return Damage + randomGenerator.Next(-Damage / 3, Damage / 3);
        }

        /// <summary>
        /// reducts HP 
        /// </summary>
        /// <param name="damage">param that takes part in changing HP</param>
        private void ReductionHP(int damage) 
        {
            if (damage >= HP)
            {
                HP = 0;
            }
            else
            {
                HP = HP - damage;
            }
        }
        /// <summary>
        /// set life (HP <= 0 - false)(HP > 0 - true)
        /// </summary>
        private void SetLife()
        {
            if (HP <= 0) 
            {
                Life = false;
            }
            else
            {
                Life = true;
            }  
        }
        /// <summary>
        /// appeales to ReductionHP and SetLife
        /// </summary>
        /// <param name="damage">takes part in ReductionHP</param>
        public void SettingLiveAndHP(int damage)
        {
            ReductionHP(damage);
            SetLife();
        }
        /// <summary>
        /// shows info of 1 hero (Name, Damage, present HP)
        /// </summary>
        public void ShowInfo()   
        {
            Console.WriteLine($"Герой:{Name}|Урон:{Damage}|Здоровье:{HP}");
        }


        
    }
}

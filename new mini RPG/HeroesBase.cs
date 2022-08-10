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
        public int GetHP()
        {
            return HP;
        }
        public int GetDamage()
        {
            return Damage + randomGenerator.Next(-Damage / 3, Damage / 3);
        }
        private void SetHP(int damage) 
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
        public void SettingLiveAndHP(int damage)
        {
            SetHP(damage);
            SetLife();
        }
        public void ShowInfo()   
        {
            Console.WriteLine($"Герой:{Name}|Урон:{Damage}|Здоровье:{GetHP()}");
        }


        
    }
}

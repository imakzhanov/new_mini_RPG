using System;
using System.Collections.Generic;
using System.Text;

namespace new_mini_RPG
{
    class HeroesBase
    {
        public int HP { get; private set; } //сет публичный так нельзя и нет ограничений
        public int Damage { get; private set; }
        public string Name { get; set; }
        private bool _life{get; set;}//getset
        Random randomGenerator = new Random();
        public HeroesBase( int hp, int damage, string name, bool life)
        {            
            HP = hp;
            Damage = damage;
            Name = name;
            _life = true;
        }
        public bool GetLife()
        {
            return _life;
        }
        private void SetLife()
        {
            if (HP <= 0) 
            {
                HP = 0;
                _life = false;
            }
            else
            {
                _life = true;
            }  
        }
        public int GettingInaccuracy(int damage)//где применяется?
        {
            int inaccuracy = randomGenerator.Next(-damage / 3, damage / 3);
            return inaccuracy;
        }
        public int Damaging(int damage)//зачем принимать разброс?
        {
            int inaccuracy = randomGenerator.Next(-damage / 3, damage / 3);
            HP = HP - (damage + inaccuracy);
            SetLife();
            return damage + inaccuracy;
        }
        public void ShowInfo()   
        {
            Console.WriteLine($"Герой:{Name}|Урон:{Damage}|Здоровье:{HP}");
        }


        
    }
}

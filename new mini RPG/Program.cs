using System;

namespace new_mini_RPG
{
    class Program
    {
        /// <summary>
        /// gets number from user from 1 to 3 or 4
        /// </summary>
        /// <param name="maxCount">max count that user can enter(3 or 4)</param>
        /// <returns>number that user entered</returns>
        public static int GetNumber(int maxCount = 4)
        {
            int number = 0;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out number) || number <= 0 || number > maxCount)
            {
                Console.WriteLine("Неправильный ввод:");
                input = Console.ReadLine();
            }
            number = number - 1;
            return number;
        }

        static void Main(string[] args)
        {
            Random randomGenerator = new Random();

            Console.Write("Придумай название своей команде: ");//-------------------------------Выбор названий команд
            Teams yourTeam = new Teams(Console.ReadLine());//Создание команды игрока 
            string computerName;
            if (randomGenerator.Next(2) == 0)
            {
                computerName = "Доминаторы";
            }
            else
            {
                computerName = "Непобедимые";
            }
            Teams computerTeam = new Teams(computerName);
            Console.WriteLine($"Компьютер выбрал название {computerName}.");
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            
            for (int i = 0; i < 3; i++)//-----------------------------------------Выбор перснажей Игроком
            {
                bool access = false;
                Console.WriteLine("Выберите персонажа:");
                Console.WriteLine("1 - Орк");
                Console.WriteLine("2 - Шаман");
                Console.WriteLine("3 - Воин");
                Console.WriteLine("4 - Маг");
                while (!access)
                {
                    HeroesBase hero;
                    switch (GetNumber())
                    {
                        case 0:
                            hero = new Ork();
                            access = yourTeam.HeroAdd(hero);
                            break;
                        case 1:
                            hero = new Shaman();
                            access = yourTeam.HeroAdd(hero);
                            break;
                        case 2:
                            hero = new Knight();
                            access = yourTeam.HeroAdd(hero);
                            break;
                        case 3:
                            hero = new Mag();
                            access = yourTeam.HeroAdd(hero);
                            break;
                        default:
                            Console.WriteLine("Ошибка!!!");
                            break;
                    }
                    if (access)
                    {
                        Console.WriteLine("Вы добавили персонажа");
                        Console.Clear();
                    }
                }
            }
            Console.Clear();

            for (int i = 0; i < 3; i++)//--------------------------------------Выбор персонажей компьютером
            {
                bool access = false;
                while (!access)
                {
                    int number = randomGenerator.Next(4);
                    HeroesBase hero;
                    switch (number)
                    {
                        case 0:
                            hero = new Ork();
                            access = computerTeam.HeroAdd(hero);
                            break;
                        case 1:
                            hero = new Shaman();
                            access = computerTeam.HeroAdd(hero);
                            break;
                        case 2:
                            hero = new Knight();
                            access = computerTeam.HeroAdd(hero);
                            break;
                        case 3:
                            hero = new Mag();
                            access = computerTeam.HeroAdd(hero);
                            break;
                        default:
                            Console.WriteLine("Ошибка!!!");
                            break;
                    }
                }
            }
            bool winCheck = true;
            while (winCheck)//---------------------------------------------------------------основной цикл
            {
                Console.Clear();
                yourTeam.ShowInfo();
                computerTeam.ShowInfo();

                Console.WriteLine("Выбери, кем атаковать:");
                int attackingPlayerHero = GetNumber(yourTeam.GettingHeroesCount());
                while (!yourTeam.HeroLiveCheck(attackingPlayerHero))
                {
                    Console.WriteLine("Ваш герой уже мертв.");
                    Console.WriteLine("Выбери, кем атаковать:");
                    attackingPlayerHero = GetNumber(yourTeam.GettingHeroesCount());
                }
                
                Console.WriteLine("Выбери, кого атаковать:");
                int playerTarget = GetNumber(yourTeam.GettingHeroesCount());
                while (!computerTeam.HeroLiveCheck(playerTarget))
                {
                    Console.WriteLine("Цель уже мертва.");
                    Console.WriteLine("Выбери, кого атаковать:");
                    playerTarget = GetNumber(yourTeam.GettingHeroesCount());
                }
                Console.Clear();
                
                computerTeam.GettingDamage(playerTarget, yourTeam.GettingFullDamage(attackingPlayerHero),
                    yourTeam.GettingAttackingHeroName(attackingPlayerHero), yourTeam.Name);//атака игрока
                Console.WriteLine("Для продолжения нажмите Enter...");
                Console.ReadLine();
                Console.Clear();
                
                if (computerTeam.TeamLiveCheck())
                {
                    int attackingComputerHero = randomGenerator.Next(computerTeam.GettingHeroesCount());
                    computerTeam.HeroLiveCheck(attackingComputerHero);
                    while (!computerTeam.HeroLiveCheck(attackingComputerHero))
                    {
                        attackingComputerHero = randomGenerator.Next(computerTeam.GettingHeroesCount());
                    }

                    int computerTarget = randomGenerator.Next(computerTeam.GettingHeroesCount());
                    while (!yourTeam.HeroLiveCheck(computerTarget))
                    {
                        computerTarget = randomGenerator.Next(computerTeam.GettingHeroesCount());
                    }

                    string computerAttackingHeroName = computerTeam.GettingAttackingHeroName(attackingComputerHero);
                    Console.Clear();
                    yourTeam.GettingDamage(computerTarget, computerTeam.GettingFullDamage(attackingComputerHero), computerAttackingHeroName, computerTeam.Name);//атака компьютера
                    Console.WriteLine("Для продолжения нажмите Enter...");
                    Console.ReadLine();
                }

                if (!yourTeam.TeamLiveCheck() || !computerTeam.TeamLiveCheck())//проверка команд
                {
                    winCheck = false;
                }
            }
            if (!yourTeam.TeamLiveCheck())
            {
                Console.WriteLine($"Победила команда {computerTeam.Name}");
            }
            else
            {
                Console.WriteLine($"Победила команда {yourTeam.Name}");
            }

            Console.WriteLine("Игра окончена.");


        }
    }
}

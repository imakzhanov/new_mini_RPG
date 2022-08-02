﻿using System;

namespace new_mini_RPG
{
    class Program
    {
        public static int GetNumber(int maxCount)
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
            Teams yourTeam = new Teams();
            Teams computerTeam = new Teams();

            Console.Write("Придумай название своей команде: ");//-------------------------------Выбор названий команд
            yourTeam.Name = Console.ReadLine();
            computerTeam.Name = "Компьютер";//нужно из списка выбирать
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < 3; i++)//-----------------------------------------Выбор Игрока
            {
                bool flag = false;
                Console.WriteLine("Выберите персонажа:");
                Console.WriteLine("1 - Орк");
                Console.WriteLine("2 - Шаман");
                Console.WriteLine("3 - Воин");
                Console.WriteLine("4 - Маг");
                while (!flag)
                {
                    HeroesBase hero;
                    switch (GetNumber(4))
                    {
                        case 0: //можно так
                            hero = new Ork();//но тогда переменную объявить раньше
                            flag = yourTeam.HeroAdd(hero);
                            break;
                        case 1:
                            hero = new Shaman();
                            flag = yourTeam.HeroAdd(hero);
                            break;
                        case 2:
                            hero = new Knight();
                            flag = yourTeam.HeroAdd(hero);
                            break;
                        case 3:
                            hero = new Mag();
                            flag = yourTeam.HeroAdd(hero);
                            break;
                        default:
                            Console.WriteLine("Ошибка!!!");
                            break;

                    }
                    if (flag)
                    {
                        Console.WriteLine("Вы добавили персонажа");
                        Console.Clear();
                    }
                }
            }
            Console.Clear();

            for (int i = 0; i < 3; i++)//--------------------------------------Выбор компьютера
            {
                bool access = false;
                while (!access)
                {
                    int number = randomGenerator.Next(4);
                    switch (number)
                    {
                        case 0:
                            {
                                HeroesBase Ork = new Ork();
                                access = computerTeam.HeroAdd(Ork);
                                break;
                            }
                        case 1:
                            {
                                HeroesBase Shaman = new Shaman();
                                access = computerTeam.HeroAdd(Shaman);
                                break;
                            }
                        case 2:
                            {
                                HeroesBase Knight = new Knight();
                                access = computerTeam.HeroAdd(Knight);
                                break;
                            }
                        case 3:
                            {
                                HeroesBase Mag = new Mag();
                                access = computerTeam.HeroAdd(Mag);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Ошибка!!!");
                                break;
                            }
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
                int attackingPlayerHero = GetNumber(3);
                while (!yourTeam.HeroLiveCheck(attackingPlayerHero))//можно чуть лучше
                {
                    Console.WriteLine("Ваш герой уже мертв.");
                    Console.WriteLine("Выбери, кем атаковать:");
                    attackingPlayerHero = GetNumber(3);
                }

                Console.WriteLine("Выбери, кого атаковать:");
                int playerTarget = GetNumber(3);
                while (!computerTeam.HeroLiveCheck(playerTarget))
                {
                    Console.WriteLine("Цель уже мертва.");
                    Console.WriteLine("Выбери, кого атаковать:");
                    playerTarget = GetNumber(3);
                }

                //не забывай разделять
                int yourAttackingHeroDamage = yourTeam.GettingAttackingHeroDamage(attackingPlayerHero);
                string yourAttackingHeroName = yourTeam.GettingAttackingHeroName(attackingPlayerHero);
                Console.Clear();

                computerTeam.Damaging(playerTarget, yourAttackingHeroDamage, yourAttackingHeroName, yourTeam.Name);//-------------атака игрока
                Console.WriteLine("Для продолжения нажмите Enter...");
                Console.ReadLine();
                Console.Clear();

                if (computerTeam.TeamLiveCheck()) 
                {
                    int attackingComputerHero = randomGenerator.Next(3);
                    computerTeam.HeroLiveCheck(attackingComputerHero);
                    while (!computerTeam.HeroLiveCheck(attackingComputerHero))
                    {
                        attackingComputerHero = randomGenerator.Next(3);
                    }

                    int computerTarget = randomGenerator.Next(3);
                    while (!yourTeam.HeroLiveCheck(computerTarget))
                    {
                        computerTarget = randomGenerator.Next(3);
                    }

                    int computerAttackingHeroDamage = computerTeam.GettingAttackingHeroDamage(attackingComputerHero);
                    string computerAttackingHeroName = computerTeam.GettingAttackingHeroName(attackingComputerHero);
                    Console.Clear();
                    yourTeam.Damaging(computerTarget, computerAttackingHeroDamage, computerAttackingHeroName, computerTeam.Name);//-------------атака компьютера
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
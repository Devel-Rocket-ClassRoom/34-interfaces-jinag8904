using System;

Character hero = new Character("용사", 100, 20);
Monster monster1 = new Monster("슬라임", 30, 5);
Monster monster2 = new Monster("고블린", 50, 10);

Console.WriteLine("=== 전투 시작 ===\n");

ProcessBattle(hero, monster1);
ProcessBattle(monster1, hero);
ProcessBattle(hero, monster1);

Console.WriteLine("\n=== 고블린 등장 ===\n");

ProcessBattle(hero, monster2);
ProcessBattle(monster2, hero);
ProcessBattle(hero, monster2);
ProcessBattle(hero, monster2);

void ProcessBattle(IAttacker attacker, IDefender defender)
{
    attacker.Attack(defender);
}
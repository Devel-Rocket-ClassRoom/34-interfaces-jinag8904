
using System;

interface IAttacker
{
    int AttackPower { get; }

    void Attack(IDefender target);
}

interface IDefender
{
    int CurrentHp { get; }
    int MaxHp { get; }
    bool IsDead { get; }

    void TakeDamage(int damage);
}

class Character : IAttacker, IDefender
{
    public string Name;

    public int MaxHp { get; set; }

    public int AttackPower { get; set; }

    private int _currentHp;

    public int CurrentHp
    {
        get => _currentHp;
        private set
        {
            if (value < 0)
            {
                _currentHp = 0;
            }
            else if (value > 100)
            {
                _currentHp = 100;
            }
            else
            {
                _currentHp = value;
            }
        }
    }

    public bool IsDead { get; set; }

    public Character(string name, int maxHp, int attackPower)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp;
        AttackPower = attackPower;
    }

    public void Attack(IDefender target)
    {
        target.TakeDamage(AttackPower);
        Console.WriteLine($"{Name}(이)가 {((Monster)target).Name}에게 {AttackPower} 대미지! ({((Monster)target).Name} HP: {target.CurrentHp}/{target.MaxHp})");
        if (target.IsDead == true) Console.WriteLine($"{((Monster)target).Name}(이)가 쓰러졌습니다!");
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (_currentHp == 0) IsDead = true;
    }
}

class Monster : IAttacker, IDefender
{
    public string Name;

    public int MaxHp { get; set; }

    public int AttackPower { get; set; }

    private int _currentHp;

    public int CurrentHp
    {
        get => _currentHp;
        private set
        {
            if (value < 0)
            {
                _currentHp = 0;
            }
            else if (value > 100)
            {
                _currentHp = 100;
            }
            else
            {
                _currentHp = value;
            }
        }
    }

    public bool IsDead { get; set; }


    public Monster(string name, int maxHp, int attackPower)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp;
        AttackPower = attackPower;
    }

    public void Attack(IDefender target)
    {
        target.TakeDamage(AttackPower);
        Console.WriteLine($"{Name}(이)가 {((Character)target).Name}에게 {AttackPower} 대미지! ({((Character)target).Name} HP: {target.CurrentHp}/{target.MaxHp})");
        if (target.IsDead == true) Console.WriteLine($"{((Character)target).Name}(이)가 쓰러졌습니다!");
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if(_currentHp == 0) IsDead = true;
    }
}
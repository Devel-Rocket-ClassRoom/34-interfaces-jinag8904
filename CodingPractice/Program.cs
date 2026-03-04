using System;

// 1-1.
{
    Car car = new Car();
    car.Go();
}
Console.WriteLine();

// 1-2.
{
    IRepository repository = new Repository();
    repository.Get();
}
Console.WriteLine();

// 1-3.
{
    Person person = new Person();
    person.Work();
    person.Rest();
}
Console.WriteLine();

// 2.
{
    Car2 car1 = new Car2(new GoodBattery());
    Car2 car2 = new Car2(new NormalBattery());

    car1.Run();
    car2.Run();
}
Console.WriteLine();

// 3-1.
{
    Dog dog = new Dog();
    dog.Eat();
    dog.Bark();
}
Console.WriteLine();

// 3-2.
{
    Bird bird = new Bird();
    bird.Breathe();
    bird.Fly();
}
Console.WriteLine();

// 4-1.
{
    Pet pet = new Pet();
    
    ((IDog4)pet).Eat();
    ((ICat4)pet).Eat();

    IDog4 dog = new Pet();
    dog.Eat();

    ICat4 cat = new Pet();
    cat.Eat();
}
Console.WriteLine();

// 4-2.
{
    IExample example = new Example();
    example.DoWork();
}
Console.WriteLine();

// 5.
{
    TextEditor textEditor = new TextEditor();
    textEditor.Undo();
    textEditor.Redo();
}
Console.WriteLine();

// 6.
{
    Car6 car = new Car6();
    car.Run();
    car.Left();
    car.Back();
}
Console.WriteLine();

// 7-1.
{
    Attack(new Player(), 20);
    Attack(new Enemy(), 30);
    Attack(new Building(), 100);

    void Attack(IDamageable target, int damage)
    {
        target.TakeDamage(damage);
    }
}
Console.WriteLine();

// 7-2.
{
    Hero hero = new Hero();
    hero.Move();
    hero.Attack();

    new Turret().Attack();
}
Console.WriteLine();

// 7-2.
interface IMovable
{
    void Move();
}

interface IAttackable
{
    void Attack();
}

class Hero : IMovable, IAttackable
{
    public void Move() => Console.WriteLine("영웅이 이동합니다.");
    public void Attack() => Console.WriteLine("영웅이 공격합니다.");
}

class Turret : IAttackable
{
    public void Attack() => Console.WriteLine("터렛이 발사합니다.");
}

// 7-1.
interface IDamageable
{
    int Health { get; set; }

    void TakeDamage(int damage);
}

class Player : IDamageable
{
    public int Health { get; set; } = 100;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"플레이어가 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}

class Enemy : IDamageable
{
    public int Health { get; set; } = 50;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"적이 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}

class Building : IDamageable
{
    public int Health { get; set; } = 500;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"건물이 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}

// 6.
interface IStandard
{
    void Run();
}

abstract class Vehicle
{
    public abstract void Back();

    public void Left() => Console.WriteLine("좌회전");
}

class Car6 : Vehicle, IStandard
{
    public void Run() => Console.WriteLine("전진");

    public override void Back() => Console.WriteLine("후진");
}

// 5.
interface IUndoable
{
    void Undo();
}

interface IRedoable : IUndoable
{
    void Redo();
}

class TextEditor : IRedoable
{
    public void Undo() => Console.WriteLine("실행 취소");
    public void Redo() => Console.WriteLine("다시 실행"); 
}

// 4-2.
interface IExample
{
    void DoWork();
}

class Example : IExample
{
    public void DoWork() => Console.WriteLine("작업 수행");
}

// 4-1.
interface IDog4
{
    void Eat();
}

interface ICat4
{
    void Eat();
}

class Pet : IDog4, ICat4
{
    void IDog4.Eat()
    {
        Console.WriteLine("개처럼 먹습니다.");
    }
    void ICat4.Eat()
    {
        Console.WriteLine("고양이처럼 먹습니다.");
    }
}

// 3-2.
interface IFlyable
{
    void Fly();
}

class Animal
{
    public void Breathe() => Console.WriteLine("숨을 쉽니다.");
}

class Bird : Animal, IFlyable
{
    public void Fly() => Console.WriteLine("날아갑니다.");
}

// 3-1.
interface IAnimal
{
    void Eat();
}

interface IDog
{
    void Bark();
}

class Dog : IAnimal, IDog
{
    public void Eat() => Console.WriteLine("먹습니다.");

    public void Bark() => Console.WriteLine("짖습니다.");
}

// 2.
interface IBattery
{
    string GetName();
}

class GoodBattery : IBattery
{
    public string GetName() => "고급 배터리";
}

class NormalBattery : IBattery
{
    public string GetName() => "일반 배터리";
}

class Car2
{
    IBattery _battery;

    public Car2(IBattery battery)
    {
        _battery = battery;
    }

    public void Run() => Console.WriteLine($"{_battery.GetName()}를 장착한 자동차가 달립니다.");
}

// 1-3.
interface IPerson
{
    void Work();
    void Rest();
}

class Person : IPerson
{
    public void Work() => Console.WriteLine("일을 합니다.");
    public void Rest() => Console.WriteLine("휴식을 취합니다.");
}

// 1-2.
interface IRepository
{
    void Get();
}

class Repository : IRepository
{
    public void Get() => Console.WriteLine("데이터를 가져옵니다.");
}

// 1-1.
interface ICar
{
    void Go();
}

class Car : ICar
{
    public void Go() => Console.WriteLine("자동차가 달립니다.");
}
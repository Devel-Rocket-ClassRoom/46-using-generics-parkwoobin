using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

// README.md를 읽고 코드를 작성하세요.


Stack stack = new Stack();
stack.Push(100);
stack.Push(200);

int num1 = (int)stack.Pop();
int num2 = (int)stack.Pop();
Console.WriteLine($"값1: {num1}");
Console.WriteLine($"값2: {num2}");


Stack<int> genericStack = new Stack<int>();
genericStack.Push(100);
genericStack.Push(200);

int num3 = genericStack.Pop();
int num4 = genericStack.Pop();

Console.WriteLine($"값1: {num3}");
Console.WriteLine($"값2: {num4}");


Cup<string> stringCup = new Cup<string>();
stringCup.Content = "커피";

Cup<int> intCup = new Cup<int>();
intCup.Content = 500;

Console.WriteLine($"음료: {stringCup.Content}");
Console.WriteLine($"용량: {intCup.Content}ml");


Pair<string, int> pair1 = new Pair<string, int>();
Pair<int, double> pair2 = new Pair<int, double>();

pair1.First = "용사";
pair1.Second = 100;

pair2.First = 1;
pair2.Second = 95.5;

Console.WriteLine($"이름: {pair1.First}, HP: {pair1.Second}");
Console.WriteLine($"순위: {pair2.First}등, 점수: {pair2.Second}");

void Swap<T>(ref T a, ref T b)
{
    T temp = a;
    a = b;
    b = temp;
}
int a = 10;
int b = 20;
Console.WriteLine($"교환 전: x = {a}, y = {b}");

Swap(ref a, ref b);
Console.WriteLine($"교환 후: x = {a}, y = {b}");

string str1 = "사과";
string str2 = "바나나";
Console.WriteLine($"교환 전: first = {str1}, second = {str2}");

Swap(ref str1, ref str2);
Console.WriteLine($"교환 후: first = {str1}, second = {str2}");

var intContainer = new NumberContainer<int>();
intContainer.Number = 100;
Console.WriteLine($"정수 값: {intContainer.Number}");

var floatContainer = new NumberContainer<float>();
floatContainer.Number = 3.14f;
Console.WriteLine($"실수 값: {floatContainer.Number}");


T CreateInstance<T>() where T : new()
{
    return new T();
}

var monster = CreateInstance<Monster>();
Console.WriteLine($"생성된 몬스터: {monster.Name}, HP: {monster.HP}");


T GetMax<T>(T a, T b) where T : IComparable<T>
{
    return a.CompareTo(b) > 0 ? a : b;
}

int maxInt = GetMax(10, 20);
Console.WriteLine($"더 큰 정수: {maxInt}");

string maxString = GetMax("apple", "banana");
Console.WriteLine($"사전순 뒤: {maxString}");


T GetDefaultValue<T>()
{
    return default(T);
}

int defaultInt = GetDefaultValue<int>();
bool defaultBool = GetDefaultValue<bool>();
string defaultString = GetDefaultValue<string>();

Console.WriteLine($"int 기본값: {defaultInt}");
Console.WriteLine($"bool 기본값: {defaultBool}");
Console.WriteLine($"string 기본값: {defaultString ?? "(null)"}");

List<string> names = new List<string>();
names.Add("철수");
names.Add("영희");
names.Add("민수");

Console.WriteLine("이름 목록:");
foreach (string name in names)
{
    Console.WriteLine($"  - {name}");
}

Console.WriteLine("점수:");

Dictionary<string, int> scores = new Dictionary<string, int>();
scores["철수"] = 95;
scores["영희"] = 88;
scores["민수"] = 92;

foreach (var score in scores)
{
    Console.WriteLine($"  {score.Key}: {score.Value}점");
}

var special = new SpecialContainer<string>();
special.item = "특별한 아이템";
special.Description = "레어 등급";
Console.WriteLine($"{special.item} ({special.Description})");

var intContainer2 = new IntContainer();
intContainer2.item = 50;
Console.WriteLine($"값: {intContainer2.item}, 두 배: {intContainer2.Double()}");

Counter<int> counter1 = new Counter<int>();
Counter<string> counter2 = new Counter<string>();
Counter<int>.Count++;
Counter<int>.Count++;
Counter<string>.Count++;
Console.WriteLine($"Counter<int> Count: {Counter<int>.Count}");
Console.WriteLine($"Counter<string> Count: {Counter<string>.Count}");








public class Cup<T>
{
    public T Content { get; set; }
}

public class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }
}

public class NumberContainer<T> where T : struct
{
    public T Number { get; set; }
}

public class Monster
{
    public string Name { get; set; } = "슬라임";
    public int HP { get; set; } = 50;
}

class Container<T>
{
    public T item { get; set; }
}

class SpecialContainer<T> : Container<T>
{
    public string Description { get; set; }
}

class IntContainer : Container<int>
{
    public int Double() => item * 2;
}

public class Counter<T>
{
    public static int Count = 0;
}
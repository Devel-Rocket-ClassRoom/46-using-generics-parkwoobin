using System;

// README.md를 읽고 코드를 작성하세요.

var intStack = new MyStack<int>(5);
intStack.Push(10);
intStack.Push(20);
intStack.Push(30);

Console.WriteLine("=== 정수 스택 테스트 ===");
Console.WriteLine($"Count: {intStack.Count}");
Console.WriteLine($"Peek: {intStack.Peek()}");
Console.WriteLine($"Pop: {intStack.Pop()}");
Console.WriteLine($"Pop: {intStack.Pop()}");
Console.WriteLine($"Count: {intStack.Count}");

// 문자열 스택 테스트
var stringStack = new MyStack<string>(5);
stringStack.Push("첫번째");
stringStack.Push("두번째");
stringStack.Push("세번째");

Console.WriteLine("\n=== 문자열 스택 테스트 ===");
Console.WriteLine($"Count: {stringStack.Count}");
Console.WriteLine($"Peek: {stringStack.Peek()}");
Console.WriteLine($"Pop: {stringStack.Pop()}");
Console.WriteLine($"IsEmpty: {stringStack.IsEmpty}");




class MyStack<T>
{
    private T[] items;
    private int top;
    private int _count;

    public int Count => _count;

    public bool IsEmpty => _count == 0;

    public MyStack(int capacity)
    {
        items = new T[capacity];
        top = -1;
        _count = 0;
    }

    public T Push(T item)
    {
        items[++top] = item;
        _count++;
        return item;
    }
    public T Pop()
    {
        T item = items[top];
        top--;
        _count--;
        return item;
    }
    public T Peek()
    {
        return items[top];
    }


}
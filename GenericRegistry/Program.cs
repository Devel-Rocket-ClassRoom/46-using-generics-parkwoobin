using System;

// README.md를 읽고 아래에 코드를 작성하세요.

var scoreBoard = new Registry<string, int>(10);

// 점수 등록
scoreBoard.Register("철수", 1500);
scoreBoard.Register("영희", 2300);
scoreBoard.Register("민수", 1800);

Console.WriteLine("=== 점수 등록 완료 ===");
Console.WriteLine($"등록된 플레이어 수: {scoreBoard.Count}");
scoreBoard.PrintAll();

// 점수 조회
Console.WriteLine($"\n영희의 점수: {scoreBoard.Find("영희")}");
Console.WriteLine($"철수의 점수: {scoreBoard.Find("철수")}");

// 존재하지 않는 키 조회
Console.WriteLine($"존재하지 않는 키 조회: {scoreBoard.Find("길동")}");

// 키 존재 여부 확인
Console.WriteLine($"\n영희 존재 여부: {scoreBoard.Contains("영희")}");
Console.WriteLine($"길동 존재 여부: {scoreBoard.Contains("길동")}");

// 점수 갱신 (덮어쓰기)
scoreBoard.Register("철수", 2000);
Console.WriteLine($"\n철수 점수 갱신 후: {scoreBoard.Find("철수")}");
Console.WriteLine($"등록된 플레이어 수: {scoreBoard.Count}");




public class Registry<TKey, TValue> where TKey : IEquatable<TKey>
{
    private TKey[] keys;
    private TValue[] values;
    private int _count;
    public int Count => _count;

    public Registry(int capacity)
    {
        keys = new TKey[capacity];
        values = new TValue[capacity];
        _count = 0;
    }

    public void Register(TKey key, TValue value)
    {
        for (int i = 0; i < _count; i++)
        {
            if (keys[i].Equals(key))
            {
                values[i] = value; // 기존 키가 있으면 값 갱신을 하면 count가 안올라감
                return;
            }
        }

        if (_count >= keys.Length)
            throw new InvalidOperationException("Registry is full");

        keys[_count] = key;
        values[_count] = value;
        _count++;
    }

    public bool Contains(TKey key)
    {
        for (int i = 0; i < _count; i++)
        {
            if (keys[i].Equals(key))
                return true;
        }
        return false;
    }

    public void PrintAll()
    {
        for (int i = 0; i < _count; i++)
        {
            Console.WriteLine($"{keys[i]}: {values[i]}");
        }
    }

    internal TValue Find(TKey key)
    {
        for (int i = 0; i < _count; i++)
        {
            if (keys[i].Equals(key))
                return values[i];
        }

        return default(TValue);
    }
}
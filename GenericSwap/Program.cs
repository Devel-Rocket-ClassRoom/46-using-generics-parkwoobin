using System;
using System.Collections.Generic;
using System.Net;

// README.md를 읽고 코드를 작성하세요.

int x = 10, y = 20;
Console.WriteLine($"교환 전: x={x}, y={y}");
Utils.Swap(ref x, ref y);
Console.WriteLine($"교환 후: x={x}, y={y}");

string a = "Hello", b = "World";
Console.WriteLine($"\n교환 전: a={a}, b={b}");
Utils.Swap(ref a, ref b);
Console.WriteLine($"교환 후: a={a}, b={b}");

// SwapInArray 테스트
int[] numbers = { 1, 2, 3, 4, 5 };
Console.WriteLine($"\n배열 교환 전: [{string.Join(", ", numbers)}]");
Utils.SwapInArray(numbers, 0, 4);
Console.WriteLine($"배열 교환 후: [{string.Join(", ", numbers)}]");

// FindMin, FindMax 테스트
int[] scores = { 85, 92, 78, 95, 88 };
Console.WriteLine($"\n점수: [{string.Join(", ", scores)}]");
Console.WriteLine($"최소값: {Utils.FindMin(scores)}");
Console.WriteLine($"최대값: {Utils.FindMax(scores)}");

string[] words = { "banana", "apple", "cherry" };
Console.WriteLine($"\n단어: [{string.Join(", ", words)}]");
Console.WriteLine($"사전순 첫 단어: {Utils.FindMin(words)}");
Console.WriteLine($"사전순 끝 단어: {Utils.FindMax(words)}");

// Reverse 테스트
int[] data = { 1, 2, 3, 4, 5 };
Console.WriteLine($"\n뒤집기 전: [{string.Join(", ", data)}]");
Utils.Reverse(data);
Console.WriteLine($"뒤집기 후: [{string.Join(", ", data)}]");





class Utils
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    public static void SwapInArray<T>(T[] array, int index1, int index2)
    {
        Utils.Swap(ref array[index1], ref array[index2]);
    }

    public static string FindMin<T>(T[] array)
    {
        int minIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (Comparer<T>.Default.Compare(array[i], array[minIndex]) < 0)
            {
                minIndex = i;
            }
        }
        return array[minIndex].ToString();
    }

    public static string FindMax<T>(T[] array)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (Comparer<T>.Default.Compare(array[i], array[maxIndex]) > 0)
            {
                maxIndex = i;
            }
        }
        return array[maxIndex].ToString();
    }

    public static void Reverse<T>(T[] array)
    {
        int left = 0;
        int right = array.Length - 1;
        while (left < right)
        {
            Swap(ref array[left], ref array[right]);
            left++;
            right--;
        }
    }
}


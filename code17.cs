using System;

class Ex_2_17
{
    static void Main()
    {
        int[] intArray = new int[10000];
        int counter = 0, max = int.MinValue, maxi = -1, maxj = -1;
        Random rnd = new Random();
        for (int i = 0; i < intArray.Length; i++) intArray[i] = rnd.Next(10000);
        
        for (int i = 0; i < intArray.Length; i++)
            for (int j = 0; j < intArray.Length; j++)
                if (intArray[i] != intArray[j])
                {
                    int tempInt = intArray[i] - intArray[j];
                    if (tempInt % 60 == 0)
                    {
                        counter++;
                        if (tempInt > max) { max = tempInt; maxi = i; maxj = j; }
                    }
                }
        Console.WriteLine("Количество пар с разностью кратной 60: " + counter.ToString());
        Console.WriteLine("Максимальная разница у чисел " + intArray[maxi] + " и " + intArray[maxj] + ": " + max);
    }
}
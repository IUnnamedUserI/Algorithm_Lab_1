using System;

class Ex_1_13
{
  static void Main()
  {
    Console.WriteLine("Введите первое натуральное число: "); int number1 = Convert.ToInt32(Console.ReadLine());
    if (number1 < 1) Console.WriteLine("Вы ввели ненатуральное число");
    Console.WriteLine("Введите второе натуральное число: "); int number2 = Convert.ToInt32(Console.ReadLine());
    if (number2 < 1) Console.WriteLine("Вы ввели ненатуральное число");
    int result = Rec(number1) - Rec(number2);
    Console.WriteLine("Разница: " + result.ToString());
  }
  
  static int Rec(int Number)
  {
      if (Number == 1) return 1;
      else if (Number > 1) return Number - 2 + Rec(Number - 1);
      return -1;
  }
}
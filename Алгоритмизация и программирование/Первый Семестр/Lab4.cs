using System;
class Programm {
  static void Main() {
      //Лабораторная работа 4 10.10.2024
        Console.WriteLine("Введите положительный целый элемент который хотите преобразовать");
        int n = int.Parse(Console.ReadLine());
        int s = 0;
        while(n>0){
            while (n!=0){
                if ((n % 10) % 2 == 1){
                    s = s * 10 + (n % 10);
                }
                n = n / 10;
            }
            if (s == 0){
                Console.WriteLine("Нет нечетных");
            }
            else{
                Console.WriteLine("Преобразованный элемент: "+s);
            }
            n = int.Parse(Console.ReadLine());
            s = 0;
        }
  }
}

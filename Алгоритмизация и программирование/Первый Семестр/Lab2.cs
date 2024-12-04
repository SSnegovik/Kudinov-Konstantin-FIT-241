using System;
class Programm 
{
  static void Main() 
  {
    //Задание 1
    
        Console.WriteLine("Нахождение локальных минимумов");
        Console.WriteLine("Введите количество элементов:");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите элементы:");
        int prev = int.Parse(Console.ReadLine());
        int current = int.Parse(Console.ReadLine());

        int LocalMin=0;

        for (int i=2; i<number; i++)
        {
            int next = int.Parse(Console.ReadLine());
            if (current<prev && current<next)
            {
                LocalMin++;
            }
            prev=current;
            current=next;
        }
        Console.WriteLine("Количество локальных минимумов: " + LocalMin);
        
    //Задание 2
    
        Console.WriteLine("Определение четности последовательности");
        Console.WriteLine("Введите количество элементов:");
        int numb = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите элементы:");
        
        int chet = 0;

        for (int i=0; i<numb; i++){
            int curren = int.Parse(Console.ReadLine());
            if (curren % 2==0)
            {
                chet++;
            }
        }
        if(chet == number){
            Console.WriteLine("Все элементы четны");
        }
        else if(chet == 0){
            Console.WriteLine("Все элементы нечетны");
        }
        else{
            Console.WriteLine("Не все элементы четны");
        }
        
        //Задание 3
        
        Console.WriteLine("Нахождение двух максимумов");
        Console.WriteLine("Введите количество элементов:");
        int numbe = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите элементы:");
        int a = int.Parse(Console.ReadLine());

        int max1=0;
        int max2=0;

        for (int i=1; i<numbe; i++)
        {
            int b = int.Parse(Console.ReadLine());
            if (a>=b && a>=max1){
                max1 = a;
            }
            if (b>=max1){
                max2 = max1;
                max1 = b;
            }
            a = b;
        }
        Console.WriteLine("max1 = " + max1);
        Console.WriteLine("max2 = " + max2);
    }
}
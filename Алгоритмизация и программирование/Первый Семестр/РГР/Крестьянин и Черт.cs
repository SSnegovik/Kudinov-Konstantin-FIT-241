using System;

class Program{
            static void Main(){
            int count = 0;
            Console.WriteLine("Введите максимальное количество монет:");
            int maxN = int.Parse(Console.ReadLine());

            for (int n = 1; n <= maxN; n++){
                for (int k = 1; k <= n*2; k++){
                    int x = n;
                    x = x * 2 - k;
                    if(x==0){
                        count++;
                        break;
                    }
                    for (int z = 2; z <= 10; z++){
                        
                        x = x * 2 - k;
                        if (x == 0){
                            count++;
                            break;
                        }
                        if (x < 0){
                            break;
                        }
                    }
                }
            }
            Console.Write("Всего вариантов");
            Console.WriteLine(count);
        }
}
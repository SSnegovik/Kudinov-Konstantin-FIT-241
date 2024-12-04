using System;
class HelloWorld {
  static void Main() {
      //Лабораторная работа 3 02.10.2024
      //Задание 3
      
      Console.WriteLine("Нахождение максимального размера подпоследовательности из одинаковых элементов");
      Console.WriteLine("Введите количество элементво");
      int n = int.Parse(Console.ReadLine());
      
      Console.WriteLine("ВВедите элементы");
      int prev = int.Parse(Console.ReadLine());
      
      int currsize = 1;
      int maxsize = 1;
      
      for(int i = 1; i<n; i++){
		int curr = int.Parse(Console.ReadLine());
		    if(curr == prev){
		        currsize++;
		        maxsize = Math.Max(maxsize, currsize);
		    }
		    else{
		        maxsize = Math.Max(maxsize, currsize);
		        currsize = 1;
		    }
		    prev = curr;
      }
      Console.WriteLine("Максимальный размер подпоследовательности из одинаковых элементов = "+maxsize);
      
      //Задание 2
      
      Console.WriteLine("Нахождение минимального размера подпоследовательности из четных элементов");
      Console.WriteLine("Введите количество элементов:");
      int num = int.Parse(Console.ReadLine());
      
      int minsize = n;
      int currsiz = 0;
      
      Console.WriteLine("Введите элементы");
      int o = 0;
      int nechet = 0;
      
      for(int i = 0; i<num; i++){
          int curre = int.Parse(Console.ReadLine());
          if(curre % 2 == 0){
              currsiz++;
          }
              else{
                  if(currsize>0 && currsize<=minsize){
                      minsize = currsize;
                  }
                  currsize = 0;
              }
              if(curre%2==1){
                  nechet++;
              }
              o = curre;
          } 
      if(o%2==0 && currsiz<minsize && currsiz>0){
          minsize = currsiz;
      }
      if(nechet==n){
          minsize = 0;
      }
      Console.WriteLine("Минимальный размер подпоследовательности из четных элементов = "+minsize);
      
      //Задание 3
      
      Console.WriteLine("Нахождение максимальной суммы подпоследовательности из четных элементов");
      Console.WriteLine("Введите количество элементов:");
      int number = int.Parse(Console.ReadLine());
      
      int currSum = 0;
      int maxSum = 0;

      Console.WriteLine("Введите элементы");
      int p = 0;
      
      for(int i = 0; i<number; i++){
		int curre = int.Parse(Console.ReadLine());
		    if(curre%2==0){
		        currSum += curre;
		    }
		    else{
		        maxSum = Math.Max(maxSum, currSum);
		        currSum = 0;
		    }
		    p = curre;
      }
      if(p%2==0){
          maxSum = Math.Max(maxSum, currSum);
      }
      Console.WriteLine("Максимальная сумма подпоследовательности из четных элементов = "+ maxSum);
  }
}

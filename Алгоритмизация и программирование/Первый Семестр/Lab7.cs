using System;
class HelloWorld {
  static void Main() {
      //Лабараторная работа 7 30.10.2024
      int[][] jaggedArray = new int[4][];
      for(int i = 0; i<4; i++){
          Console.Write($"Введите количество элементов в строке {i + 1}:");
          int n = int.Parse(Console.ReadLine());
          jaggedArray[i] = new int[n];
          Console.WriteLine($"Введите элементы строки {i + 1} по одному:");
              for(int j = 0; j<n; j++){
              jaggedArray[i][j] = int.Parse(Console.ReadLine());
              }
      }
      Console.WriteLine("Полученный ступенчатый массив");
      for (int i = 0; i < jaggedArray.Length; i++){
            for (int j = 0; j < jaggedArray[i].Length; j++){
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
      }
      //Задание 1
      for (int i = 0; i < jaggedArray.Length; i++){
            int evenCount = 0;  
            int oddCount = 0;   
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                if (jaggedArray[i][j] % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
            Console.WriteLine($"Строка {i + 1}: Четных = {evenCount}, Нечетных = {oddCount}");
      }
      //Задание 2
      for (int i = 0; i < jaggedArray.Length; i++){
            int sum = 0;
            for (int j = 0; j < jaggedArray[i].Length; j++){
                sum += jaggedArray[i][j];
            }
            int u = -1;
            for (int j = 0; j < jaggedArray[i].Length; j++){
                if (jaggedArray[i][j] > sum - jaggedArray[i][j]){
                    u = j;
                    break;
                    }
            }
            if(u != -1){
                Console.WriteLine($"В строке {i + 1} элемент {jaggedArray[i][u]} на позиции {u + 1} больше суммы остальных элементов.");
            }
            else{
                Console.WriteLine($"В строке {i + 1} нет элемента, который больше суммы остальных элементов.");
            }
        }
  }
}







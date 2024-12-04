using System;
class HelloWorld {
  static void Main() {
      //Лабараторная работа 6 24.10.2024
      Console.WriteLine("Введите количество строк и стобцов поэлементно:");
      int rows = int.Parse(Console.ReadLine());
      int cols = int.Parse(Console.ReadLine());
      int[,] array = new int[rows, cols];
      Console.WriteLine("Введите элементы по одному:")
      for(int i = 0; i<rows; i++){
          for(int j = 0; j<cols; j++){
              array[i, j] = int.Parse(Console.ReadLine());
          }
      }
      Console.WriteLine("Начальный массив:");
      for(int i = 0; i<rows; i++){
          for(int j = 0; j<cols; j++){
              Console.Write(array[i, j] + "\t");
          }
          Console.WriteLine();
      }
      Console.WriteLine();
      //Задание 1 
      //Нахождение суммы столбцов
      int[] columnSums = new int[cols];
      for (int col = 0; col < cols; col++){
          for (int row = 0; row < rows; row++){
                columnSums[col] += array[row, col];
            }
      }
      int[,] sortcolumn = new int[rows, cols];
      for (int i = 0; i < rows; i++){
          for (int j = 0; j < cols; j++){
              sortcolumn[i, j] = array[i, j];
          }
      }
      //Сортировка столбцов
      for (int i = 0; i < cols - 1; i++){
            for (int j = i + 1; j < cols; j++){
                if (columnSums[i] > columnSums[j]){
                    for (int row = 0; row < rows; row++){
                        int temp = sortcolumn[row, i];
                        sortcolumn[row, i] = sortcolumn[row, j];
                        sortcolumn[row, j] = temp;
                    }
                    int tempSum = columnSums[i];
                    columnSums[i] = columnSums[j];
                    columnSums[j] = tempSum;
                }
            }
        }
        //Вывод массива
      Console.WriteLine("Полученный массив с отсортированными столбцами:");
      for(int i = 0; i<rows; i++){
          for(int j = 0; j<cols; j++){
              Console.Write(sortcolumn[i, j] + "\t");
          }
          Console.WriteLine();
  }
      //Задание 2 
      for(int i = 0; i<rows; i++){
          int sum1 = 0;
          int mul1 = 1;
          int nul1 = 0;
          for(int j = 0; j<cols; j++){
              sum1 += array[i, j];
              mul1 *= array[i, j];
              if(array[i, j] == 0){
                  nul1++;
              }
              for(int p = i + 1; p<rows; p++){
                  int sum2 = 0;
                  int mul2 = 1;
                  int nul2 = 0;
                  for(int o = 0; o<cols; o++){
                  sum2 += array[p, o];
                  mul2 *= array[p, o];
                  if(array[p, o] == 0){
                     nul2++;
              }
              }
              if(sum1 == sum2 && mul1 == mul2 && nul1 == nul2){
              Console.WriteLine($"В Строке {i+1} и Строке {p+1} одинаковые элементы");
              }
          }
          }
          
      }
      //Задание 3
      //Определение положения мин-макса
      for (int i = 0; i < rows; i++){
           for (int j = 0; j<cols; j++){
                int el = array[i, j];
                int minelrows = 10000;
                int maxelrows = -10000;
                int minelcols = 10000;
                int maxelcols = -10000;
                for (int o = 0; o<rows; o++){
                    if (array[o, j]<minelrows){
                        minelrows = array[o, j];
                    }
                    if (array[o, j]>maxelrows){
                        maxelrows = array[o, j];
                    }
                }
                for (int p = 0; p<cols; p++){
                    if (array[i, p]<minelcols){
                        minelcols = array[i, p];
                    }
                    if (array[i, p] > maxelcols){
                        maxelcols = array[i, p];
                    }
                }
                if ((el==minelrows && el==maxelcols)||(el==minelcols && el==maxelrows)){
                Console.WriteLine($"Положение мин-макс элемента: Строка {i + 1} и Столбец {j + 1}");
                    }
                }
        }
  }
}











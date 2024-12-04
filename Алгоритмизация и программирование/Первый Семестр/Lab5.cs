using System;
class Programm {
  static void Main() {
      //Лабораторная работа 5 10.10.2024
      //Задание 1
      
      int result = 0;
      int time = 0;
      int o = 0;
      int fig = 0;
      
      Console.WriteLine("Введите количество элементов в массиве");
      int n = int.Parse(Console.ReadLine());
      int[] arr = new int[n];
      
      Console.WriteLine("Введите элементы");
      for(int i = 0; i<n; i++){
          o = 0;
          time = 0;
          arr[i] = int.Parse(Console.ReadLine());
          while(arr[i]>0){
              fig = arr[i] % 10;
              if(fig%2==0) {
                  o++;
              }
              arr[i] = arr[i]/10;
              time++;
          }
          if(o == time){
              result++;
          }
      }
      Console.WriteLine("Количество элементов в котором все цифры четные = "+result);
      
      //Задание 2
      
      Console.WriteLine("ВВедите количество элементов массива");
      int n = int.Parse(Console.ReadLine());
      int[] arr = new int[n];
      
      Console.WriteLine("ВВедите элементы массива");
      for(int i = 0; i<n; i++){
          arr[i] = int.Parse(Console.ReadLine());
          if(arr[i]%2==0){
              arr[i] = 0;
          }
          else{
              arr[i] = 1;
          }
      }
      Console.WriteLine("Полученный массив:")
      var str = string.Join(" ", arr);
      Console.WriteLine(str);
      
      //Задание 3
      
      Console.WriteLine("Введите количество элементов массива");
      int n = int.Parse(Console.ReadLine());
      int[] arr = new int[n];
      int[] result = new int[n];
      
      int evenCount = 0;
      
      Console.WriteLine("Введите элементы массива")
      for(int i = 0; i<n; i++){
          arr[i] = int.Parse(Console.ReadLine());
          if(arr[i] % 2 == 0){
              evenCount++;
          }
      }
      int evenIndex = 0;
      int oddIndex = evenCount;

      for(int i = 0; i<n; i++){
          if(arr[i]%2==0){
              result[evenIndex++] = arr[i];
          }
          else{
              result[oddIndex++] = arr[i];
          }
          
        }
        
      Console.WriteLine("Полученный массив:");
      var str = string.Join(" ", result);
      Console.WriteLine(str);
  }
}














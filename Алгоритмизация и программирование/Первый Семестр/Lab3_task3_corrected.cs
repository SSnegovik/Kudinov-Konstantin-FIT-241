using System;
class HelloWorld {
  static void Main() {
      //Задание 3 Исправленное
      Console.WriteLine("Нахождение максимальной суммы подпоследовательности из четных элементов");
      Console.WriteLine("Введите количество элементов:");
      int number = int.Parse(Console.ReadLine());
      
      int currSum = 0;
      int maxSum = int.MinValue;
      int nechetn = 0;
      int pr = 0;

      Console.WriteLine("Введите элементы");
      
      for(int i = 0; i<number; i++){
		int curre = int.Parse(Console.ReadLine());
		    if(curre%2==0){
		        currSum += curre;
		        if(number - 1 == i){
		            maxSum = Math.Max(maxSum, currSum);
		        }
		    }
		    else if(pr % 2 == 0 && curre % 2 != 0){
		        maxSum = Math.Max(maxSum, currSum);
		        currSum = 0;
		        nechetn++;
		    }
		    pr = curre;
      }
      if(nechetn == number){
          Console.WriteLine("Нет четных");
      }
      Console.WriteLine("Максимальная сумма подпоследовательности из четных элементов = "+ maxSum);
  }
}
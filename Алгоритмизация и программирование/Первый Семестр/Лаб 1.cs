using System;
class HelloWorld {
  static void Main() {
      // Лаб 1
      // Задание 1
      int a, b;
      a = Convert.ToInt32(Console.ReadLine());
      b = Convert.ToInt32(Console.ReadLine());
      a = a+b;
      b = a-b;
      a = a-b;
      Console.WriteLine(a);
      Console.WriteLine(b);
      
      //Задание 2 
      int c, d;
      c = Convert.ToInt32(Console.ReadLine());
      d = Convert.ToInt32(Console.ReadLine());
      int max = (c+d+Math.Abs(c-d)) / 2;
      Console.WriteLine(max);
      
      //Задание 3 
      
      int P,l,m,N,S;
      P = Convert.ToInt32(Console.ReadLine());
      l = Convert.ToInt32(Console.ReadLine());
      m = Convert.ToInt32(Console.ReadLine());
      N = Convert.ToInt32(Console.ReadLine());
      S = ((l+m)*2+P*2+l*(N - 1))*N;
      Console.WriteLine(S);
      
  }
}
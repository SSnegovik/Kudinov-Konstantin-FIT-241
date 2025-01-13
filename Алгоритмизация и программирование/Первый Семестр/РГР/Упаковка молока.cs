using System;
class Programm {
  static void Main() {
      int n = int.Parse(Console.ReadLine());
      double min = double.MaxValue;
      int number = 0;
      for (int i = 1; i <= n; i++){
                string String = Console.ReadLine();
                string[] arr = String.Split(' ');
                
                int x1 = int.Parse(arr[0]);
                int y1 = int.Parse(arr[1]);
                int z1 = int.Parse(arr[2]);
                int x2 = int.Parse(arr[3]);
                int y2 = int.Parse(arr[4]);
                int z2 = int.Parse(arr[5]);
                
                double c1 = double.Parse(arr[6]);
                double c2 = double.Parse(arr[7]);

                int s1 = (x1 * y1 + y1 * z1 + z1 * x1) * 2;
                int s2 = (x2 * y2 + y2 * z2 + z2 * x2) * 2;
                
                int v1 = (x1 * y1 * z1);
                int v2 = (x2 * y2 * z2);
                
                double b = 10 * (c2 - c1 * s2 / s1) / (v2 - v1 * s2 / s1);
                b = Math.Round(b, 2);
                
                if (b<min){
                    min = b;
                    number = i;
                }
            }
            Console.WriteLine($"Номер фирмы: {number} Стоимость молока: {min}");

  }
}